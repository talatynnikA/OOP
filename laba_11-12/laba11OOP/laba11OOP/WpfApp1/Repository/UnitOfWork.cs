using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Repository
{//упростить //все репозитории будут использовать один контекст 
    //Паттерн Unit of Work позволяет упростить работу с различными репозиториями и дает уверенность, 
    //что все репозитории будут использовать один и тот же контекст данных.
    class UnitOfWork : IDisposable
    {
        private ShopBase db = new ShopBase();
        private CustomerRepository customerRepository;
        private OrderReprository orderRepository;

        public CustomerRepository Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }
        //доступ через отдельные свойства 
        public OrderReprository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderReprository(db);
                return orderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
        //инкапсуляции логики работы с источником данных
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
