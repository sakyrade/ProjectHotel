using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Personal
    {
        // Паспортные данные всего персонала и стаж работы
        protected string Name { get; set; }
        protected string Surname { get; set; }
        protected string LastName { get; set; }
        protected int Age { get; set; } 
        protected DateTime DateBithday { get; set; }
        protected char Sex { get; set; }
        protected string Address { get; set; }
        protected int WorkExp { get; set; }
    }
}
