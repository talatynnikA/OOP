using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Resources;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace lab6_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> Products = new List<Product>();
        public MainWindow()
        {
            InitializeComponent();

            Uri iconUri = new Uri(@"images\minecraft.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

        }
        //поднимающиеся bubling события
        // возникают на одном элементе, а потом передаются дальше к родителю - элементу-контейнеру и далее, 
        //пока не достигнет наивысшего родителя в дереве элементов
        public void Hello1(object sender, MouseButtonEventArgs e) //обработчик
        {
            MessageBox.Show("Hello from Ellipse");
            Hello2(sender, e);
        }
        public void Hello2(object sender, MouseButtonEventArgs e)//обработчик
        {
            MessageBox.Show("Hello from Button");
            Hello3(sender, e);
        }
        public void Hello3(object sender, MouseButtonEventArgs e)//обработчик
        {
            MessageBox.Show("Hello from StackPanel");
        }
        //туннельные события
        //начинает отрабатывать в корневом элементе окна приложения и идет далее по вложенным элементам,
        //пока не достигнет элемента, вызвавшего это событие
        public void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("sender: " + sender.ToString() + "\n" + "source: " + e.Source.ToString());
            txtBlock2.Text = txtBlock2.Text + "sender: " + sender.ToString() + "\n";
            txtBlock2.Text = txtBlock2.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string path = "products.xml";
            if (File.Exists(path))
            {
                //if(TB_NOP.Text == "" || TB_categoryList.Text == "" || TB_rating.Text == "" || TB_price.Text == "" || TB_number.Text == "" || TB_size.Text == "")
                //{
                //    MessageBox.Show("Заполните все поля");
                //    return;
                //}

                XmlSerializer XmlDeformatter = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Products = (List<Product>)XmlDeformatter.Deserialize(fs);
                }


                
                Product tempObjectForValidation = new Product(TB_NOP.Text, TB_categoryList.Text, TB_rating.Text, TB_price.Text, TB_number.Text, TB_size.Text);
                    
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
                var context = new ValidationContext(tempObjectForValidation);
                if (!Validator.TryValidateObject(tempObjectForValidation, context, results, true))
                {
                    foreach (var error in results)
                    {
                        string strWithError = error.ErrorMessage;
                        MessageBox.Show(strWithError);
                    }
                    return;
                }
                Products.Add(tempObjectForValidation);
                
                
                XmlSerializer Xmlformatter = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Xmlformatter.Serialize(fs, Products);
                    MessageBox.Show("Данные записаны в файл");
                }
            }
            else
            {


                Product tempObjectForValidation = new Product(TB_NOP.Text, TB_categoryList.Text, TB_rating.Text, TB_price.Text, TB_number.Text, TB_size.Text);
                var results = new List<System.ComponentModel.DataAnnotations.ValidationResult >();
                var context = new ValidationContext(tempObjectForValidation);
                if (!Validator.TryValidateObject(tempObjectForValidation, context, results, true))
                {
                    foreach (var error in results)
                    {
                        string strWithError = error.ErrorMessage;
                        MessageBox.Show(strWithError);
                    }
                    return;
                }
                Products.Add(tempObjectForValidation);

                XmlSerializer Xmlformatter = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Xmlformatter.Serialize(fs, Products);
                    MessageBox.Show("Данные записаны в файл");
                }
            }
            Products.Clear();
        }

        private void Output_Click(object sender, RoutedEventArgs e)
        {
            string path = "products.xml";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не существует");
                return;
            }

            FileInfo fi = new FileInfo(path);
            if (fi.Length == 0)
            {
                MessageBox.Show("Файл пуст!");
            }

            XmlSerializer Xmlformatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Product> ProductsNew = (List<Product>)Xmlformatter.Deserialize(fs);

                productsGrid.ItemsSource = ProductsNew;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TB_NOP.Clear();
            TB_categoryList.Text = "";
            TB_rating.Clear();
            TB_price.Clear();
            TB_number.Clear();
            TB_size.Clear();
            TB_delete_NOP.Clear();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(TB_delete_NOP.Text == "")
            {
                MessageBox.Show("Поле не заполнено");
                return;
            }

            string path = "products.xml";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не существует");
                return;
            }

            FileInfo fi = new FileInfo(path);
            if (fi.Length == 0)
            {
                MessageBox.Show("Файл пуст!");
            }

            XmlSerializer XmlDeformatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                 Products = (List<Product>)XmlDeformatter.Deserialize(fs);
            }

            //поиск
            List<Product> temp = new List<Product>();

            foreach (var x in Products)
            {
                if (!(TB_delete_NOP.Text == x.nameOfProduct))
                {
                    temp.Add(new Product(x.nameOfProduct, x.category, x.rating, x.price, x.number, x.size));
                }
            }
            if (temp.Count < Products.Count)
            {
                Products.Clear();
                Products.AddRange(temp);

                XmlSerializer Xmlformatter = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Xmlformatter.Serialize(fs, Products);
                    MessageBox.Show("Товар удален");
                }
            }
            else
            {
                MessageBox.Show("Такого товара не существует");
            }
            Products.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (productsGrid.ItemsSource == null)
            {
                MessageBox.Show("Выведите товары для их изменения");
                return;
            }
            else
            {
                List<Product> productsChange = new List<Product>();
                productsChange = (List<Product>)productsGrid.ItemsSource;

                string path = "products.xml";
                XmlSerializer Xmlformatter = new XmlSerializer(typeof(List<Product>));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Xmlformatter.Serialize(fs, productsChange);
                    MessageBox.Show("Изменено");
                }
            }
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            string path = "products.xml";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл уже удален");
                return;
            }
            else
            {
                File.Delete(path);
                Products.Clear();
                MessageBox.Show("Файл удален");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            if (CB_NOP_Sort.IsChecked == false && CB_rating_Sort.IsChecked == false && TB_startPrice_Sort.Text == "" && TB_finishPrice_Sort.Text == "")
            {
                MessageBox.Show("Поля не заполнены");
                return;
            }

            string path = "products.xml";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не существует");
                return;
            }

            FileInfo fi = new FileInfo(path);
            if (fi.Length == 0)
            {
                MessageBox.Show("Файл пуст!");
            }

            List<Product> productsForSort = new List<Product>();

            XmlSerializer XmlDeformatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                productsForSort = (List<Product>)XmlDeformatter.Deserialize(fs);
            }


            //сортировка
            List<Product> resultOfOrder = new List<Product>();

            if (CB_NOP_Sort.IsChecked == true)
            {
                resultOfOrder.Clear();

                var temp = from x in productsForSort
                           orderby x.nameOfProduct ascending
                           select x;

                foreach (var x in temp)
                {
                    resultOfOrder.Add(x);
                }
                productsForSort.Clear();
                productsForSort.AddRange(resultOfOrder);
            }

            if (CB_rating_Sort.IsChecked == true)
            {
                resultOfOrder.Clear();

                var temp = from x in productsForSort
                           orderby x.rating descending
                           select x;

                foreach (var x in temp)
                {
                    resultOfOrder.Add(x);
                }
                productsForSort.Clear();
                productsForSort.AddRange(resultOfOrder);
            }

            if(TB_startPrice_Sort.Text != "")
            {
                double check;
                string startPrice = TB_startPrice_Sort.Text;
                bool result = Double.TryParse(startPrice, out check);

                if(result == true)
                {
                    resultOfOrder.Clear();
                    var temp = from x in productsForSort
                               where Convert.ToDouble(x.price) > check
                               select x;

                    foreach (var x in temp)
                    {
                        resultOfOrder.Add(x);
                    }
                    productsForSort.Clear();
                    productsForSort.AddRange(resultOfOrder);
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный формат цены для сортировки");
                    return;
                }
            }

            if(TB_finishPrice_Sort.Text != "")
            {
                double check;
                string finishPrice = TB_finishPrice_Sort.Text;
                bool result = Double.TryParse(finishPrice, out check);

                if (result == true)
                {
                    resultOfOrder.Clear();
                    var temp = from x in productsForSort
                               where Convert.ToDouble(x.price) < check
                               select x;

                    foreach (var x in temp)
                    {
                        resultOfOrder.Add(x);
                    }
                    productsForSort.Clear();
                    productsForSort.AddRange(resultOfOrder);
                }
                else
                {
                    MessageBox.Show("Вы ввели неверный формат цены для сортировки");
                    return;
                }
            }

            //вывод
            productsGridForSort.ItemsSource = productsForSort;
        }

        private void ClearSort_Click(object sender, RoutedEventArgs e)
        {
            CB_NOP_Sort.IsChecked = false;
            CB_rating_Sort.IsChecked = false;
            TB_startPrice_Sort.Clear();
            TB_finishPrice_Sort.Clear();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (TB_NOP_Search.Text == "" && TB_category_Search.Text == "" && TB_number_Search.Text == "" && TB_size_Search.Text == "")
            {
                MessageBox.Show("Поля не заполнены");
                return;
            }

            string path = "products.xml";
            if (!File.Exists(path))
            {
                MessageBox.Show("Файл не существует");
                return;
            }

            FileInfo fi = new FileInfo(path);
            if (fi.Length == 0)
            {
                MessageBox.Show("Файл пуст!");
            }

            List<Product> productsForSearch = new List<Product>();

            XmlSerializer XmlDeformatter = new XmlSerializer(typeof(List<Product>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                productsForSearch = (List<Product>)XmlDeformatter.Deserialize(fs);
            }


            //поиск
            List<Product> temp = new List<Product>();


            if (TB_NOP_Search.Text != "")
            {
                temp.Clear();
                Regex regex = new Regex(TB_NOP_Search.Text, RegexOptions.IgnoreCase);
                foreach (var x in productsForSearch)
                {
                    MatchCollection matches = regex.Matches(x.nameOfProduct);
                    if (matches.Count > 0)
                    {
                        temp.Add(new Product(x.nameOfProduct, x.category, x.rating, x.price, x.number, x.size));
                    }
                }
                productsForSearch.Clear();
                productsForSearch.AddRange(temp);
            }

            if (TB_category_Search.Text != "")
            {
                temp.Clear();
                Regex regex = new Regex(TB_category_Search.Text, RegexOptions.IgnoreCase);
                foreach (var x in productsForSearch)
                {
                    MatchCollection matches = regex.Matches(x.category);
                    if (matches.Count > 0)
                    {
                        temp.Add(new Product(x.nameOfProduct, x.category, x.rating, x.price, x.number, x.size));
                    }
                }
                productsForSearch.Clear();
                productsForSearch.AddRange(temp);
            }

            if (TB_number_Search.Text != "")
            {
                temp.Clear();
                Regex regex = new Regex(TB_number_Search.Text, RegexOptions.IgnoreCase);
                foreach (var x in productsForSearch)
                {
                    MatchCollection matches = regex.Matches(x.number);
                    if (matches.Count > 0)
                    {
                        temp.Add(new Product(x.nameOfProduct, x.category, x.rating, x.price, x.number, x.size));
                    }
                }
                productsForSearch.Clear();
                productsForSearch.AddRange(temp);
            }

            if (TB_size_Search.Text != "")
            {
                temp.Clear();
                Regex regex = new Regex(TB_size_Search.Text, RegexOptions.IgnoreCase);
                foreach (var x in productsForSearch)
                {
                    MatchCollection matches = regex.Matches(x.size);
                    if (matches.Count > 0)
                    {
                        temp.Add(new Product(x.nameOfProduct, x.category, x.rating, x.price, x.number, x.size));
                    }
                }
                productsForSearch.Clear();
                productsForSearch.AddRange(temp);
            }


            //вывод
            productsGridForSearch.ItemsSource = productsForSearch;
        }

        private void ClearSearch_Click(object sender, RoutedEventArgs e)
        {
            TB_NOP_Search.Clear();
            TB_category_Search.Clear();
            TB_number_Search.Clear();
            TB_size_Search.Clear();
        }


        //языки
        private void Russian_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary_ru.xaml") };
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.Clear();
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary_en.xaml") };
        }

       
    }

    public class WindowCommands
    {
        static WindowCommands()
        {
            Exit = new RoutedUICommand("Exit_From_Application","Exit", typeof(MainWindow));
        }
        public static RoutedUICommand Exit { get; set; }
    }
    //позволяет добавлять пользовательские функции. команда exit. владелец mainwindow
    public abstract class ButtonBase:ContentControl
    {
        public static readonly RoutedEvent ClickEvent;

        static ButtonBase()
        {
            ButtonBase.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonBase));
        }

        public event RoutedEventHandler Click
        {
            add
            {
                base.AddHandler(ButtonBase.ClickEvent, value);
            }
            remove
            {
                base.RemoveHandler(ButtonBase.ClickEvent, value);
            }
        }
    }
    
    public class TextBlock : FrameworkElement, IContentHost, IAddChildInternal, IServiceProvider
    {
        // свойство зависимостей
        public static readonly DependencyProperty TextProperty;//св-ва зависимостей

        static TextBlock()
        {
            // Регистрация dependencyProperty
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            //делегат, который может подкорректировать уже существующее значение свойства, если оно вдруг не попадает в диапазон допустимых значений
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextBlock), metadata, new ValidateValueCallback(ValidateValue));
        }
        //делегат, который возвращает true, если значение проходит валидацию, и false - если не проходит
        // Обычное свойство .NET  - обертка над свойством зависимостей
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public IEnumerator<IInputElement> HostedElements => throw new NotImplementedException();

        private static object CorrectValue(DependencyObject d, object value)
        {
            string currentValue = (string)value;
            if (currentValue.Length > 5)
            {
                return "It's to much symbols";
            }
            return false;
        }
        private static bool ValidateValue(object value)
        {
            string currentValue = (string)value;
            if (currentValue.Length > 0)
            {
                return true;
            }
            return false;
        }


        public ReadOnlyCollection<Rect> GetRectangles(ContentElement child)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        ReadOnlyCollection<Rect> IContentHost.GetRectangles(ContentElement child)
        {
            throw new NotImplementedException();
        }

        void IContentHost.OnChildDesiredSizeChanged(UIElement child)
        {
            throw new NotImplementedException();
        }
        // остальной код
    }
}
