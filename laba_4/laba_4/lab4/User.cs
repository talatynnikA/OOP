using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab2
{//Паттерн представляет определенный способ построения программного кода //для решения часто встречающихся проблем проектирования
 //контролируют процесс создания и жизненный цикл объектов.
    public class User
    {
        public string Background { get; set; }
        public Font FontType { get; set; }
        public int FontSize { get; set; }

    }

    public class Singleton // Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует, 
        //что для определенного класса будет создан только один объект, а также предоставит к этому объекту точку доступа
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public User config;

        private Singleton()
        {
            config = new User
            {
                Background = "#FF033E",
                FontType = new Font("Arial", 9.0f),
                FontSize = 11
            };
        }

        public static Singleton GetInstance()
        {
            return lazy.Value;
        }
    }
}





//Гарантирует наличие единственного экземпляра класса
//Предоставляет глобальную точку доступа