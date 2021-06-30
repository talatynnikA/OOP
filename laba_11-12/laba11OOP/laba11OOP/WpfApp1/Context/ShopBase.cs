using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp1
{
    class ShopBase: DbContext
    {
        public ShopBase():base("ShopBase"){
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
        // Отражение таблиц базы данных на свойства с типом DbSet
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
//Database first: Entity Framework создает набор классов, которые отражают модель конкретной базы данных

//Model first: сначала разработчик создает модель базы данных, по которой затем Entity создает реальную базу данных на сервере.

//Code first: разработчик создает класс модели данных, которые будут храниться в бд, 
//а затем Entity Framework по этой модели генерирует базу данных и ее таблицы