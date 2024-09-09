using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONSOLE_BD
{
    public class User
    {
        public User(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
