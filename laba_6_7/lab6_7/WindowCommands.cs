using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
//впф  представляет собой подсистему для построения графических интерфейсов.
//xaml -  язык разметки, используемый для инициализации объектов в технологиях на платформе .NET.
//(конт компоновкі)грид - напоминающий обычную таблицу. Он содержит столбцы и строки, количество которых задает разработчик.
//Для определения строк используется свойство RowDefinitions, а для определения столбцов - свойство ColumnDefinitions
//стэк панель - Он располагает все элементы в ряд либо по горизонтали, либо по вертикали в зависимости от ориентации

namespace lab6_7
{
    public class WindowCommands
    {
        static WindowCommands()
        {
            Add = new RoutedCommand("Exit", typeof(MainWindow)); //В данном случае команда называется Exit и представляет собой объект RoutedCommand.
        }
        public static RoutedCommand Add { get; set; }
    }
}
