using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Hotel
{
    // Типы номеров в отеле
    public enum RoomCathegories { Standart, Economy, JuniorSuite, Luxe }

    class Hostel
    {
        // Название отеля
        private string HostelName { get; set; }
        // Количество звёзд
        private int Stars { get; set; }
        // Количество этажей и номеров на каждом этаже
        // Т.к. по условию задачи у меня не было сказано сколько точно этажей нужно, я предположил, что
        // в отеле будет 100 номеров по 25 на каждом этаже
        protected const int floors = 4;
        protected const int countRoomsOnEachFloor = 25;
        // Стоимость номера по умолчанию 
        private const double roomSalary = 1180;
        // НДС
        private const double NDS = 47.20;
        // Количество занятых и свободных номеров
        private int CountRoomFree { get; set; }
        private int CountOccupied { get; set; }
        private string Address { get; set; }
        // Матричное представление номеров в отеле
        protected static int[,] hotel = new int[floors, countRoomsOnEachFloor];

        public Hostel()
        {
        }

        public Hostel(string HostelName, int stars, string Address)
        {
            this.HostelName = HostelName;
            this.Stars = stars;
            this.Address = Address;
            for (int i = 0; i < floors; i++)
                for (int j = 0; j < countRoomsOnEachFloor; j++) hotel[i, j] = 0;
        }

        //Метод, расчитывающий количество свободных мест
        private int NumberOfFreePlaces(ref int[,] hotel)
        {
            CountRoomFree = 0;
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if (hotel[i, j] == 0) CountRoomFree++;
                }
            }
            return CountRoomFree;
        }

        //Метод, расчитывающий количество занятых мест
        private int NumberOfOccupiedRooms(ref int[,] hotel)
        {
            CountOccupied = 0;
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    if (hotel[i, j] == 1) CountOccupied++;
                }
            }
            return CountOccupied;
        }

        //Вывод информации о отеле
        public void OutputInfoAboutHotel()
        {
            WriteLine("Наименование: " + HostelName);
            WriteLine("Количество звёзд: " + Stars);
            WriteLine("Количество свободных номеров: " + NumberOfFreePlaces(ref hotel));
            WriteLine("Количество занятых номеров: " + NumberOfOccupiedRooms(ref hotel));
        }

        // Вывод всего отеля
        public void OutputInHotel()
        {
            for (int i = 0; i < floors; i++)
            {
                WriteLine("-------------------------------------------------------------------------------");
                Write($"{i + 1} этаж: ");
                for(int j = 0; j < countRoomsOnEachFloor; j++)
                {
                    Write($"{j + 1}: ");
                    if (hotel[i, j] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(String.Format("{0, 3}", hotel[i, j]));
                        Console.ResetColor();
                        Console.Write("; ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0, 3}", hotel[i, j]));
                        Console.ResetColor();
                        Console.Write("; ");
                    }
                }
                WriteLine();
                WriteLine();
            }
        }

        // Расчет стоимости проживания в номере
        public double RoomRate(DateTime dateOfArrivalAtHotel, DateTime departureDate)
        {
            int date = departureDate.Day - dateOfArrivalAtHotel.Day;
            return roomSalary * date + NDS;
        }
    }
}
