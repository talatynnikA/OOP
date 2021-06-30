using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Models
{
    //Шаблон MVVM имеет три основных компонента: 
    //модель, которая представляет бизнес-логику приложения, 
    //представление пользовательского интерфейса XAML, 
    //и представление-модель, в котором содержится вся логика построения графического интерфейса и ссылка на модель, 
    //поэтому он выступает в качестве модели для представления.
    //Основная особенность MVVM заключается в том, что все поведение 
    //выносится из представления(view) в модель представления(view model).
    //Связывание представления и модели представления осуществляется декларативными байндингами в XAML разметке.Это позволяет тестировать
 // все детали интерфейса не используя сложных инструментальных средств.
    class Course
    {
        public string Title { get; set; }
        public string Lector { get; set; }
        public int Left { get; set; }
        public int ListenersMax { get; set; }
        public int Hours { get; set; }
        public Course(string title, string lector, int listeners, int hours, int listenersMax)
        {
            this.Title = title;
            this.Lector = lector;
            this.Left = listeners;
            this.Hours = hours;
            this.ListenersMax = listenersMax;
        }
    }
}
