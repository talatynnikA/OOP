using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace L10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable staffTable;
        string connectionString = ConfigurationManager.ConnectionStrings["L10.Properties.Settings.CourseWorkConnectionString"].ConnectionString;

        public MainWindow()
        {
            InitializeComponent();
            staffTable = new DataTable("СотрудникиL10");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var dataAdapter = new SqlDataAdapter("select * from СотрудникиL10", connection);
                    connection.Open();
                    dataAdapter.Fill(staffTable);
                    connection.Close();
                }
            }
            catch (SqlException)
            {
                connectionString = @"Data Source=DESKTOP-7J4J8P2;Initial Catalog=BackupL10;Integrated Security=True";
                using (var connection = new SqlConnection(@"Data Source=DESKTOP-7J4J8P2;Initial Catalog=master;Integrated Security=True"))
                {
                    var createDbCommand = new SqlCommand("if not exists (select * from sys.databases where name='BackupL10') create database BackupL10", connection);
                    var createTableCommand = new SqlCommand("use BackupL10; if exists (select * from sysobjects where name='СотрудникиL10' and xtype='U') drop table СотрудникиL10; CREATE TABLE [dbo].[СотрудникиL10]([ID сотрудника][int] IDENTITY(1000, 1) NOT NULL, [Фамилия][nvarchar](10) NOT NULL, [Имя][nvarchar](20) NOT NULL, [Отчество][nvarchar](20) NULL, [Должность][nvarchar](50) NOT NULL, [Фото][image] NULL, CONSTRAINT [PK_СотрудникиL10] PRIMARY KEY ([ID сотрудника]))", connection);
                    connection.Open();
                    createDbCommand.ExecuteNonQuery();
                    createTableCommand.ExecuteNonQuery();
                    connection.Close();
                }
                FillDB();
            }
            dataGridStaff.ItemsSource = staffTable.DefaultView;
        }

        void FillDB()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var dataAdapter = new SqlDataAdapter("select * from СотрудникиL10", connection);
                    connection.Open();
                    dataAdapter.Fill(staffTable);
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                string errorMessage = string.Empty;
                foreach (SqlError er in ex.Errors)
                    errorMessage += $"{er.Message} (error: {er.Number})\n";
                MessageBox.Show(errorMessage);
            }
        }

        void UpdateDB()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var trans = connection.BeginTransaction();
                try
                {
                    var dataAdapter = new SqlDataAdapter("select * from СотрудникиL10", connection);
                    dataAdapter.SelectCommand.Transaction = trans;
                    dataAdapter.InsertCommand = new SqlCommand("insert СотрудникиL10 (Фамилия, Имя, Отчество, Должность, Фото) values (@surname, @name, @lastname, @post, @photo)", connection);
                    dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@surname", SqlDbType.NVarChar, 30, "Фамилия"));
                    dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 20, "Имя"));
                    dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@lastname", SqlDbType.NVarChar, 20, "Отчество"));
                    dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@post", SqlDbType.NVarChar, 50, "Должность"));
                    dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@photo", SqlDbType.Image, int.MaxValue, "Фото"));
                    dataAdapter.InsertCommand.Transaction = trans;
                    using (var builder = new SqlCommandBuilder(dataAdapter))
                    {
                        dataAdapter.Update(staffTable);
                        trans.Commit();
                        connection.Close();
                    }
                }
                catch (SqlException ex)
                {
                    trans.Rollback();
                    connection.Close();
                    string errorMessage = string.Empty;
                    foreach (SqlError er in ex.Errors)
                        errorMessage += $"{er.Message} (error: {er.Number})\n";
                    MessageBox.Show(errorMessage);
                }
            }
            staffTable.Clear();
            FillDB();
        }

        private void dataGridStaff_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (dataGridStaff.SelectedItems == null)
                return;
            dataGridStaff.RowEditEnding -= dataGridStaff_RowEditEnding;
            dataGridStaff.CommitEdit();
            dataGridStaff.RowEditEnding += dataGridStaff_RowEditEnding;
            UpdateDB();
        }

        private void buttRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStaff.SelectedItems != null)
                for (int i = 0; i < dataGridStaff.SelectedItems.Count; i++)
                    (dataGridStaff.SelectedItems[i] as DataRowView)?.Row.Delete();
            UpdateDB();
        }

        private void dataGridStaff_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                e.Handled = false;
                buttRemove_Click(sender, e);
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var file = new Microsoft.Win32.OpenFileDialog();
            if (file.ShowDialog() == true)
                staffTable.Rows[dataGridStaff.SelectedIndex]["Фото"] = File.ReadAllBytes(file.FileName);
            UpdateDB();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => Image_MouseDown(null, null);

        private void dataGridStaff_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            if (staffTable.Rows.Count <= dataGridStaff.SelectedIndex || staffTable.Rows[dataGridStaff.SelectedIndex]["Фото"] is DBNull)
                return;
            byte[] source = (byte[])staffTable.Rows[dataGridStaff.SelectedIndex]["Фото"];
            var image = new BitmapImage();
            using (var mem = new MemoryStream(source))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            (((e.DetailsElement as StackPanel).Children[0] as Border).Child as Image).Source = image;
            // можно var panel = dataGridStaff.RowDetailsTemplate.LoadContent(); (((panel as StackPanel).Children[0] as Border).Child as Image).Source = image;
        }

        private void buttNext_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStaff.SelectedIndex >= dataGridStaff.Items.Count - 1)
                dataGridStaff.SelectedIndex = 0;
            else
                dataGridStaff.SelectedIndex++;
        }

        private void buttPrev_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStaff.SelectedIndex <= 0)
                dataGridStaff.SelectedIndex = dataGridStaff.Items.Count - 1;
            else
                dataGridStaff.SelectedIndex--;
        }

        private void dataGridStaff_SelectionChanged(object sender, SelectionChangedEventArgs e) => buttRemove.IsEnabled = dataGridStaff.SelectedIndex != -1 && dataGridStaff.SelectedIndex != dataGridStaff.Items.Count - 1;
    }
}
