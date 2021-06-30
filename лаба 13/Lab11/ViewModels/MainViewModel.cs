using Lab10.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.ViewModels
{
    class MainViewModel : ViewModelBase 
    {
        public ObservableCollection<CourseViewModel> CoursesList { get; set; }


        public MainViewModel(List<Course> courses)
        {
            CoursesList = new ObservableCollection<CourseViewModel>(courses.Select(b => new CourseViewModel(b)));
        }

    }
}
//ViewModel или модель представления связывает модель и представление через механизм привязки данных.
