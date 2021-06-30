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
using System.Windows.Shapes;

namespace L11
{
    /// <summary>
    /// Логика взаимодействия для DBFirst.xaml
    /// </summary>
    public partial class DBFirst : Window
    {
        public DBFirst()
        {
            InitializeComponent();
            dataGridStaff.ItemsSource = (new CourseWorkEntities()).СотрудникиL10.ToList();
        }
    }
}
