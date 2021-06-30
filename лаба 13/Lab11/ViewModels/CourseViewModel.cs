using Lab10.Commands;//ViewModel или модель представления связывает модель и представление через механизм привязки данных.
using Lab10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab10.ViewModels
{
    class CourseViewModel : ViewModelBase 
    {
        public Course Course;
        public CourseViewModel(Course course)
        {
            this.Course = course;
        }
        public string Title
        {
            get { return Course.Title; }
            set
            {
                Course.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Lector
        {
            get { return Course.Lector; }
            set
            {
                Course.Lector = value;
                OnPropertyChanged("Lector");
            }
        }
        public int Left
        {
            get { return Course.Left; }
            set
            {
                Course.Left = value;
                OnPropertyChanged("Left");
            }
        }
        public int ListenersMax
        {
            get { return Course.ListenersMax; }
            set
            {
                Course.Left = value;
                OnPropertyChanged("ListenersMax");
            }
        }
        public int Hours
        {
            get { return Course.Hours; }
            set
            {
                Course.Hours = value;
                OnPropertyChanged("Hours");
            }
        }

        #region Commands //

        #region Забрать

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem, CanGetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        { 
            Left++;
        }
        private bool CanGetItem()
        {
            return Left < ListenersMax;
        }
        #endregion

        #region Записать

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get 
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Left--;
        }

        private bool CanGiveItem()
        {
            return Left > 0;
        }

        #endregion

        #endregion

    }
}
