using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab2
{//Паттерн представляет определенный способ построения программного кода для решения часто встречающихся проблем проектирования
    //При написании программ мы можем формализовать проблему в виде классов и объектов и связей между ними. 
    //И применить один из существующих паттернов для ее решения. В итоге нам не надо ничего придумывать. 
    //У нас уже есть готовый шаблон, и нам только надо его применить в конкретной программе.
    public class WhiteTheme : IUserConfig
    {
         public Color Background { get => Color.White; }
         public Font FontType { get => new Font("Arial", 10.0f); }
         public int FontSize { get => 12; }
    }

    public class DarkTheme : IUserConfig
    {
        public Color Background => Color.Gray;
        public Font FontType => new Font("Arial", 10.0f);
        public int FontSize => 12;
    }

    public class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public IUserConfig config;

        private Singleton()
        {
            config = new WhiteTheme();
        }
        //показывают, как объекты и классы объединяются для образования сложных структур.
        public static void ChangeTheme(IUserConfig sconfig)
        {
            lazy.Value.config = sconfig;
        }

        public static Singleton GetInstance()
        {
            return lazy.Value;
        }
    }
}