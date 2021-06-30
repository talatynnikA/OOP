using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L11
{
    public class StaffContext : DbContext
    {
        public StaffContext() : base("name=CourseWorkConnectionString") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    public class Employee : ICloneable
    {
        public Employee()
        {
            Фамилия = string.Empty;
            Имя = string.Empty;
        }

        [Key]
        public int ID_сотрудника { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public Post Должность { get; set; }

        public object Clone() => new Employee() { ID_сотрудника = ID_сотрудника, Должность = Должность, Имя = Имя, Отчество = Отчество, Фамилия = Фамилия };
    }

    public class Post
    {
        [Key]
        public string Name { get; set; }
        public int Salary { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public override string ToString() => Name;
    }
}
