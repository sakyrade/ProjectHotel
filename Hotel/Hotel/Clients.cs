using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Hotel
{
    // Клиенты отеля
    class Clients : Hostel
    {
        // Паспортные данные клиентов
        private string Name { get; set; }
        private string Surname { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }
        private DateTime DateBithday { get; set; }
        private char Sex { get; set; }
        // Номер этажа и самого номера
        private int FloorNumber { get; set; }
        private int RoomNumber { get; set; }
        private string Address { get; set; }
        // Стоимость номера
        private double SalaryRoom { get; set; }
        // Тип выбранного номера
        private RoomCathegories RoomCathegories { get; set; }
        // Дата заезда и выезда
        public DateTime DateOfArrivalAtHotel { get; set; }
        public DateTime DepartureDate { get; set; }

        public Clients(int FloorNumber, int RoomNumber)
        {
            this.FloorNumber = FloorNumber;
            this.RoomNumber = RoomNumber;
        }

        public Clients(string Name, string Surname, string LastName, int Age, DateTime dB, char Sex, string Address, double salary, RoomCathegories roomCathegories)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.LastName = LastName;
            this.Age = Age;
            this.DateBithday = dB;
            this.Sex = Sex;
            this.Address = Address;
            this.SalaryRoom = salary;
            this.RoomCathegories = roomCathegories;
        }

        //Удаление этажа и номера из массива
        public void DeleteFloorAndRoom(int floor, int room)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if ((floor - 1) == i && (room - 1) == j)
                    {
                        hotel[i, j] = 0;
                        this.FloorNumber = 0;
                        this.RoomNumber = 0;
                        break;
                    }
                }
            }
        }

        //Чтение этажа и номера из файла и занесение в массив
        public void ReadFloorAndRoom(int floor, int room)
        {
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if ((floor - 1) == i && (room - 1) == j)
                    {
                        hotel[i, j] = 1;
                        this.FloorNumber = i + 1;
                        this.RoomNumber = j + 1;
                        break;
                    }
                }
            }
        }

        //Бронирование номера
        public bool ReservationRoom(int FloorNumber, int RoomNumber)
        {
            bool reservationComplete = false;
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if ((FloorNumber - 1) == i && (RoomNumber - 1) == j)
                    {
                        if (hotel[i, j] == 0)
                        {
                            reservationComplete = true;
                            hotel[i, j] = 1;
                            this.FloorNumber = i + 1;
                            this.RoomNumber = j + 1;
                            break;

                        }
                        else
                        {
                            reservationComplete = false;
                            WriteLine("Этот номер уже занят.");
                        }
                    }
                }
            }
            return reservationComplete;
        }
    }
}
