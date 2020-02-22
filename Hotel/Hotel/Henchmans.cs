using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    //Те, кто принимает груз (паж)
    class Henchmans : Personal
    {
        public static readonly double Salary = 30500;
        public Henchmans(string Name, string Surname, string LastName, int Age, DateTime dB, char Sex, int WorkExp, string Address)
        {
            Console.WriteLine($"Паж {this.Name} успешно добавлен(а)!");
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
