using Lab10.Models;
using Lab10.ViewModels;
using Lab10.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab10
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Course> courses = new List<Course>()
            {
                new Course("ООП", "Пацей", 60, 40,65),
                new Course("КСИС", "Романенко", 10, 30,20),
                new Course("WEB", "Жиляк", 5, 20,15)
            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(courses); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
