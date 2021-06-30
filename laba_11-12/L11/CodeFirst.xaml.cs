using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace L11
{
    public class ColumnFamilyRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == string.Empty)
                return new ValidationResult(false, "Введите фамилию.");
            return ValidationResult.ValidResult;
        }
    }
    /// <summary>
    /// Логика взаимодействия для CodeFirst.xaml
    /// </summary>
    public partial class CodeFirst : Window
    {
        StaffContext staff;
        public CodeFirst()
        {
            InitializeComponent();
            staff = new StaffContext();
            dataGridStaff.ItemsSource = new ListCollectionView(staff.Employees.ToList());
            dataGridPost.ItemsSource = staff.Posts.ToList();
            dataGridColumnPost.ItemsSource = staff.Posts.ToList();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dockPanelMenu.Width = dockPanelMenu.Width.CompareTo(double.NaN) == 0 ? 50.0 : double.NaN;
        }

        void ChangeActiveTab(object panel) => Canvas.SetTop(rectActive, 45 * (dockPanelMenu.Children.IndexOf(panel as UIElement) - 1) + 5);

        private void stackEmployees_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeActiveTab(sender);
            gridMain.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Collapsed;
            dataGridStaff.Visibility = Visibility.Visible;
            dataGridPost.Visibility = Visibility.Collapsed;
            buttRemove.IsEnabled = false;
        }

        private void stackPost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeActiveTab(sender);
            gridMain.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Collapsed;
            dataGridStaff.Visibility = Visibility.Collapsed;
            dataGridPost.Visibility = Visibility.Visible;
            buttRemove.IsEnabled = false;
        }

        private void dataGridStaff_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // FIXME не работает selecteditem, добавить при lostfocus
            // todo через e.row, а не selecteditem
            if (e.Row.Item == null)
                return;
            dataGridStaff.RowEditEnding -= dataGridStaff_RowEditEnding;
            dataGridStaff.CommitEdit();
            dataGridStaff.RowEditEnding += dataGridStaff_RowEditEnding;
            var empl = e.Row.Item as Employee;
            if (empl.ID_сотрудника == 0)
                if (string.IsNullOrWhiteSpace(empl.Имя) || string.IsNullOrWhiteSpace(empl.Фамилия))
                {
                    MessageBox.Show("Фамилия и имя  должны иметь непустые значения.");
                    e.Cancel = true;
                    return;
                }
                else
                    staff.Employees.Add(empl);
            staff.SaveChanges();
            dataGridStaff.ItemsSource = staff.Employees.ToList();
        }

        private void dataGridStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttRemove.IsEnabled = dataGridStaff.SelectedIndex != -1 && dataGridStaff.SelectedIndex != dataGridStaff.Items.Count - 1;
        }

        private void buttRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStaff.Visibility == Visibility.Visible)
            {
                staff.Employees.Remove(dataGridStaff.SelectedItem as Employee);
                staff.SaveChanges();
                dataGridStaff.ItemsSource = staff.Employees.ToList();
            }
            else if (dataGridPost.Visibility == Visibility.Visible)
            {
                staff.Posts.Remove(dataGridPost.SelectedItem as Post);
                staff.SaveChanges();
                dataGridPost.ItemsSource = staff.Posts.ToList();
                dataGridColumnPost.ItemsSource = staff.Posts.ToList();
            }
        }

        private void dataGridStaff_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                e.Handled = false;
                buttRemove_Click(null, null);
            }
        }

        private void dataGridPost_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (dataGridPost.SelectedItem == null)
                return;
            if ((dataGridPost.SelectedItem as Post).Name != null)
            {
                using (var tran = staff.Database.BeginTransaction())
                {
                    try
                    {
                        //staff.Posts.Remove(dataGridPost.SelectedItem as Post);
                        staff.Database.ExecuteSqlCommand($"delete from Posts where Name = '{(dataGridPost.SelectedItem as Post).Name}'");
                        var t = staff.SaveChangesAsync();
                        t.Wait();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
            }
            dataGridPost.RowEditEnding -= dataGridPost_RowEditEnding;
            dataGridPost.CommitEdit();
            dataGridPost.RowEditEnding += dataGridPost_RowEditEnding;
            //staff.Posts.Add(dataGridPost.SelectedItem as Post);
            staff.Database.ExecuteSqlCommand($"insert Posts values ('{(dataGridPost.SelectedItem as Post).Name}', {(dataGridPost.SelectedItem as Post).Salary})");
            //staff.SaveChanges();
            dataGridPost.Items.Refresh();
            dataGridColumnPost.ItemsSource = staff.Posts.ToList();
        }

        private void dataGridPost_SelectionChanged(object sender, SelectionChangedEventArgs e) => buttRemove.IsEnabled = dataGridPost.SelectedIndex != -1 && dataGridPost.SelectedIndex != dataGridPost.Items.Count - 1;

        private void stackEmployeeSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeActiveTab(sender);
            gridMain.Visibility = Visibility.Collapsed;
            gridSearch.Visibility = Visibility.Visible;

        }

        private void textBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = staff.Employees.AsEnumerable().Where(p => Regex.IsMatch(p.Фамилия, $@"^{textBoxSurname.Text}\w*", RegexOptions.IgnoreCase) && Regex.IsMatch(p.Должность?.Name, $@"^{textBoxPost.Text}\w*", RegexOptions.IgnoreCase));
            dataGridSearch.ItemsSource = search.ToList();
        }

        private void dataGridStaff_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (Validation.GetHasError(e.EditingElement))
            {
                (e.EditingElement as TextBox).Text = beforeEditValue == null ? string.Empty : beforeEditValue;
            }
        }

        string beforeEditValue;

        private void dataGridStaff_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var ex = (e.Row.Item as Employee);
            switch (e.Column.DisplayIndex)
            {
                case 1:
                    beforeEditValue = ex.Фамилия;
                    break;
            }
        }

        private void dataGridStaff_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridStaff_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            Employee emp = (e.Row.Item as Employee).Clone() as Employee;
            e.DetailsElement.DataContext = emp;
            var box = e.DetailsElement.FindName("dataGridStaffPostBox") as ComboBox;
            box.ItemsSource = staff.Posts.ToList();
        }

        private void dataGridStaff_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
