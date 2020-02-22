using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class ClientsList
    {
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string DateBithday { get; set; }
        public char Sex { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public string dateOfArrivalAtHotel { get; set; }
        public string departureDate { get; set; }
        public double deposit { get; set; } = 0;
        public double salaryRoom { get; set; }
    }
}
