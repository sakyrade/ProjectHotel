using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    // Горничные
    class Maids : Personal
    {
        public static readonly double Salary = 20000;
        public Maids(string Name, string Surname, string LastName, int Age, DateTime dB, char Sex, int WorkExp, string Address)
        {
            Console.WriteLine($"Горничный(ая) {this.Name} успешно добавлен(а)!");
            this.Name = Name;
            this.Surname = Surname;
            this.LastName = LastName;
            this.Age = Age;
            this.DateBithday = dB;
            this.Sex = Sex;
            this.Address = Address;
            this.WorkExp = WorkExp;
        }
    }
}
