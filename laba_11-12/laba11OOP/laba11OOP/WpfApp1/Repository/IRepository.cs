using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//интерфейс репозитория:

namespace WpfApp1
{
    interface IRepository<T> : IDisposable
         where T : class
    {
        IEnumerable<T> GetItemList(); // получение всех объектов
        T GetItem(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
// Репозиторий позволяет абстрагироваться от конкретных подключений к источникам данных, 
//с которыми работает программа, и является промежуточным звеном между классами, 
//непосредственно взаимодействующими с данными, и остальной программой.