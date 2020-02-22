using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;
using static System.Convert;

namespace Hotel
{
    class Program
    {
        // Количество рабочих разных профессий
        private static int CountClients = 0;
        private static int CountMaids = 0;
        private static int CountHenchmans = 0;
        private static int CountWorkmans = 0;
        // Объявление переменных классов
        private static Hostel hostel;
        private static Clients client;
        private static Maids maid;
        private static Henchmans henchman;
        private static Workmans workman;

        // Функция вывода персонала
        static void OutputPersonal()
        {
            Clear();
            if (File.Exists(Environment.CurrentDirectory + "/henchmans.txt"))
            {
                using (StreamReader sr = new StreamReader("henchmans.txt"))
                {
                    WriteLine("Информация о пажах.");
                    WriteLine();
                    WriteLine("---------------------------------------------------");
                    WriteLine(sr.ReadToEnd());
                    WriteLine("---------------------------------------------------");
                    ReadLine();
                    sr.Close();
                }
                ReadLine();
                Clear();
            }
            else
            {
                WriteLine("Файла с пажами не существует.");
                ReadLine();
                Clear();
            }
            if (File.Exists(Environment.CurrentDirectory + "/maids.txt"))
            {
                using (StreamReader sr = new StreamReader("maids.txt"))
                {
                    WriteLine("Информация о горничных.");
                    WriteLine();
                    WriteLine("---------------------------------------------------");
                    WriteLine(sr.ReadToEnd());
                    WriteLine("---------------------------------------------------");
                    ReadLine();
                    sr.Close();
                }
                ReadLine();
                Clear();
            }
            else
            {
                WriteLine("Файла с горничными не существует.");
                ReadLine();
                Clear();
            }
            if (File.Exists(Environment.CurrentDirectory + "/workmans.txt"))
            {
                using (StreamReader sr = new StreamReader("workmans.txt"))
                {
                    WriteLine("Информация о рабочих.");
                    WriteLine();
                    WriteLine("---------------------------------------------------");
                    WriteLine(sr.ReadToEnd());
                    WriteLine("---------------------------------------------------");
                    ReadLine();
                    sr.Close();
                }
            }
            else
                WriteLine("Файла с рабочими не существует.");
            ReadLine();
            Clear();
            Menu();
        }

        // Регистрация персонала
        static void RegistrationPersonal()
        {
            try
            {
                Clear();
                int WorkExp = 0;
                if (hostel == null)
                {
                    WriteLine("Отель не создан!");
                    ReadLine();
                    Clear();
                    Menu();
                }
                Write("Введите имя: ");
                string name = ReadLine();
                Write("Введите фамилию: ");
                string surname = ReadLine();
                Write("Введите отчество: ");
                string lastName = ReadLine();
                restart:
                Write("Полных лет: ");
                int age = ToInt32(ReadLine());
                if (age < 18)
                {
                    WriteLine("Сотруднику меньше 18. Попробуйте снова.");
                    goto restart;
                }
                Write("Дата рождения: ");
                DateTime dB = ToDateTime(ReadLine());
                int temp = DateTime.Now.Year - dB.Year;
                if (temp != age)
                {
                    WriteLine("Год рождения не совпадает с датой. Попробуйте снова.");
                    goto restart;
                }
                Write("Введите адрес проживания: ");
                string address = ReadLine();
                restart2:
                WriteLine("Пол: Ж, М?");
                char sex = ToChar(ReadLine());
                if (sex != 1046 && sex != 1052 && sex != 1078 && sex != 1084)
                {
                    Write("Некорректно введён пол. Попробуйте снова.");
                    goto restart2;
                }
                if (name != null && surname != null && lastName != null && address != null)
                {
                restart3:
                    WriteLine("Вакансии:");
                    WriteLine($"1. Паж; - Осталось вакансий: {10 - CountHenchmans}");
                    WriteLine($"2. Горничная; - Осталось вакансий: {20 - CountMaids}");
                    WriteLine($"3. Рабочий; - Осталось вакансий: {5 - CountWorkmans}");
                    WriteLine("4. Выход в меню.");
                    Write("Выберите нужную вакансию: ");
                    char n = ToChar(ReadLine());
                    switch (n)
                    {
                        case '1':
                            Clear();
                            if (CountHenchmans != 10)
                            {
                                CountHenchmans++;
                                Write("Стаж работы: ");
                                WorkExp = ToInt32(ReadLine());
                                if (WorkExp == 0)
                                {
                                    WriteLine("Слишком маленький стаж работы. Попробуйте снова.");
                                    ReadLine();
                                    goto case '1';
                                }
                                henchman = new Henchmans(name, surname, lastName, age, dB, sex, WorkExp, address);
                                using (StreamWriter sw = new StreamWriter("henchmans.txt", true))
                                {
                                    string[] tmp = { "   Номер пажа: " + CountHenchmans + Environment.NewLine + '{' + Environment.NewLine + "   Имя: " + name + Environment.NewLine + "   Фамилия: " + surname + Environment.NewLine +
                                "   Отчество: " + lastName + Environment.NewLine + "   Возраст: " + age.ToString() + Environment.NewLine + "   Дата рождения: " + dB.ToShortDateString() + Environment.NewLine + "   Адрес проживания: " + address + Environment.NewLine +
                                "   Пол: " + sex.ToString() + Environment.NewLine + Environment.NewLine + "   Стаж: " + WorkExp + Environment.NewLine +
                                "   З/п: " + Henchmans.Salary + Environment.NewLine + '}' };
                                    foreach (string t in tmp)
                                        sw.WriteLine(t);
                                    sw.Close();
                                }
                                ReadLine();
                                Clear();
                                Menu();
                            }
                            else
                            {
                                WriteLine("Нет вакансий.");
                                ReadLine();
                                Clear();
                                goto restart3;
                            }
                            break;
                        case '2':
                            Clear();
                            if (CountMaids != 20)
                            {
                                CountMaids++;
                                Write("Стаж работы: ");
                                WorkExp = ToInt32(ReadLine());
                                if (WorkExp == 0)
                                {
                                    WriteLine("Слишком маленький стаж работы. Попробуйте снова.");
                                    ReadLine();
                                    goto case '2';
                                }
                                maid = new Maids(name, surname, lastName, age, dB, sex, WorkExp, address);
                                using (StreamWriter sw = new StreamWriter("maids.txt", true))
                                {
                                    string[] tmp = { "   Номер горничной(ого): " + CountMaids + Environment.NewLine + '{' + Environment.NewLine + "   Имя: " + name + Environment.NewLine + "   Фамилия: " + surname + Environment.NewLine +
                                "   Отчество: " + lastName + Environment.NewLine + "   Возраст: " + age.ToString() + Environment.NewLine + "   Дата рождения: " + dB.ToShortDateString() + Environment.NewLine + "   Адрес проживания: " + address + Environment.NewLine +
                                "   Пол: " + sex.ToString() + Environment.NewLine + Environment.NewLine + "   Стаж: " + WorkExp + Environment.NewLine +
                                "   З/п: " + Maids.Salary + Environment.NewLine + '}' };
                                    foreach (string t in tmp)
                                        sw.WriteLine(t);
                                    sw.Close();
                                }
                                ReadLine();
                                Clear();
                                Menu();
                            }
                            else
                            {
                                WriteLine("Нет вакансий.");
                                ReadLine();
                                Clear();
                                goto restart3;
                            }
                            break;
                        case '3':
                            Clear();
                            if (CountWorkmans != 5)
                            {
                                CountWorkmans++;
                                Write("Стаж работы: ");
                                WorkExp = ToInt32(ReadLine());
                                if (WorkExp == 0)
                                {
                                    WriteLine("Слишком маленький стаж работы. Попробуйте снова.");
                                    ReadLine();
                                    goto case '3';
                                }
                                workman = new Workmans(name, surname, lastName, age, dB, sex, WorkExp, address);
                                using (StreamWriter sw = new StreamWriter("henchmans.txt", true))
                                {
                                    string[] tmp = { "   Номер рабочего: " + CountWorkmans + Environment.NewLine + '{' + Environment.NewLine + "   Имя: " + name + Environment.NewLine + "   Фамилия: " + surname + Environment.NewLine +
                                "   Отчество: " + lastName + Environment.NewLine + "   Возраст: " + age.ToString() + Environment.NewLine + "   Дата рождения: " + dB.ToShortDateString() + Environment.NewLine + "   Адрес проживания: " + address + Environment.NewLine + 
                                "   Пол: " + sex.ToString() + Environment.NewLine + Environment.NewLine + "   Стаж: " + WorkExp + Environment.NewLine +
                                "   З/п: " + Workmans.Salary + Environment.NewLine + '}' };
                                    foreach (string t in tmp)
                                        sw.WriteLine(t);
                                    sw.Close();
                                }
                                ReadLine();
                                Clear();
                                Menu();
                            }
                            else
                            {
                                WriteLine("Нет вакансий.");
                                ReadLine();
                                Clear();
                                goto restart3;
                            }
                            break;
                        case '4':
                            Clear();
                            Menu();
                            break;
                        default:
                            WriteLine("Неверный пункт меню. Попробуйте снова.");
                            ReadLine();
                            Clear();
                            Menu();
                            break;
                    }
                }
                else
                {
                    WriteLine("Поля не могут быть пустыми. Попробуйте снова.");
                    ReadLine();
                    Clear();
                    RegistrationPersonal();
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Clear();
                Menu();
            }
        }

        // Контроль заезда и выезда клиентов
        static void ControlCheckInAndOut()
        {
            Clear();
            int t = 0;
            int ID = 0;
            string tmp;
            WriteLine("--------------Заезд и выезд клиентов--------------");
            WriteLine("1. Заезд клиентов;");
            WriteLine("2. Выезд клиентов;");
            WriteLine("3. Вернуться в меню.");
            WriteLine("--------------------------------------------------");
            Write("Введите пункт меню: ");
            char n = ToChar(ReadLine());
            switch (n)
            {
                case '1':
                    Clear();
                    if (File.Exists(Environment.CurrentDirectory + "/clients.txt"))
                    {
                        WriteLine("Клиенты, которые заедут сегодня.");
                        using (StreamReader sr = new StreamReader("clients.txt"))
                        {
                            do
                            {
                                t = 0;
                                tmp = sr.ReadLine();
                                if (tmp.Contains("   Номер клиента: "))
                                    ID = ToInt32(tmp.Remove(0, 18));
                                if (tmp.Contains("   Дата заезда: ") && tmp.Remove(0, 16) == DateTime.Now.ToShortDateString())
                                {
                                    using (StreamReader sr2 = new StreamReader("clients.txt"))
                                    {
                                        do
                                        {
                                            tmp = sr2.ReadLine();
                                            if (tmp.Contains("   Номер клиента: "))
                                                t = ToInt32(tmp.Remove(0, 18));
                                            if (t == ID)
                                                WriteLine(tmp);
                                        }
                                        while (sr2.EndOfStream != true);
                                        sr2.Close();
                                    }
                                }
                            } while (sr.EndOfStream != true);
                            sr.Close();
                        }
                        ReadLine();
                        Clear();
                        ControlCheckInAndOut();
                    }
                    else
                    {
                        WriteLine("Файла не существует.");
                        ReadLine();
                        Clear();
                        Menu();
                    }
                    break;
                case '2':
                    Clear();
                    List<string> str = new List<string>();
                    int floor = 0, room = 0;
                    int deleteCountClients = 0;
                    if (File.Exists(Environment.CurrentDirectory + "/clients.txt"))
                    {
                        WriteLine("Клиенты, которые выезжают сегодня. Они будут удалены из базы.");
                        using (StreamReader sr = new StreamReader("clients.txt"))
                        {
                            do
                            {
                                t = 0;
                                tmp = sr.ReadLine();
                                if (tmp.Contains("   Номер клиента: "))
                                    ID = ToInt32(tmp.Remove(0, 18));
                                if (tmp.Contains("   Дата выезда: ") && tmp.Remove(0, 16) == DateTime.Now.ToShortDateString())
                                {
                                    deleteCountClients++;
                                    using (StreamReader sr2 = new StreamReader("clients.txt"))
                                    {
                                        do
                                        {
                                            tmp = sr2.ReadLine();
                                            if (tmp.Contains("   Номер клиента: "))
                                                t = ToInt32(tmp.Remove(0, 18));
                                            if (t == ID)
                                            {
                                                WriteLine(tmp);
                                            }
                                            if (tmp.Contains("   Этаж: "))
                                            {
                                                floor = 0;
                                                tmp = tmp.Remove(0, 9);
                                                floor = ToInt32(tmp);
                                            }
                                            if (tmp.Contains("   Номер: "))
                                            {
                                                room = 0;
                                                tmp = tmp.Remove(0, 10);
                                                room = ToInt32(tmp);
                                            }
                                            if (floor != 0 && room != 0)
                                            {
                                                client.DeleteFloorAndRoom(floor, room);
                                            }
                                        }
                                        while (sr2.EndOfStream != true);
                                        sr2.Close();
                                    }
                                }
                                else if (tmp.Contains("   Дата выезда: ") && tmp.Remove(0, 16) != DateTime.Now.ToShortDateString())
                                {
                                    using (StreamReader sr2 = new StreamReader("clients.txt"))
                                    {
                                        do
                                        {
                                            tmp = sr2.ReadLine();
                                            if (tmp.Contains("   Номер клиента: "))
                                                t = ToInt32(tmp.Remove(0, 18));
                                            if (t == ID)
                                            {
                                                str.Add(tmp);
                                            }
                                        }
                                        while (sr2.EndOfStream != true);
                                        sr2.Close();
                                    }
                                }
                            } while (sr.EndOfStream != true);
                            sr.Close();
                        }
                        ReadLine();
                        Clear();
                        using (StreamWriter sw = new StreamWriter("clients.txt", false))
                        {
                            foreach (string s in str)
                                sw.WriteLine(s);
                            WriteLine("Файл успешно перезаписан!");
                            sw.Close();
                        }
                        CountClients -= deleteCountClients;
                        WriteLine($"Осталось клиентов: {CountClients}");
                        ReadLine();
                        Clear();
                        ControlCheckInAndOut();
                    }
                    else
                    {
                        WriteLine("Файла не существует.");
                        ReadLine();
                        Clear();
                        Menu();
                    }
                    break;
                case '3':
                    Clear();
                    Menu();
                    break;
                default:
                    WriteLine("Неверный пункт меню. Попробуйте снова.");
                    ReadLine();
                    Clear();
                    ControlCheckInAndOut();
                    break;
            }
        }

        // Регистрация отеля
        static void RegistrationHostel()
        {
            try
            {
                Clear();
                if (hostel != null)
                {
                    WriteLine("Отель уже создан!");
                    ReadLine();
                    Clear();
                    Menu();
                }
                Write("Введите название отеля: ");
                string nameHotel = ReadLine();
                Write("Введите количество звёзд: ");
                int stars = ToInt32(ReadLine());
                if (stars > 5)
                {
                    WriteLine("Количество звёзд не может быть больше 5!");
                    ReadLine();
                    Clear();
                    Menu();
                }
                Write("Введите адрес, на котором находится отель: ");
                string address = ReadLine();
                if (nameHotel != null && address != null)
                {
                    hostel = new Hostel(nameHotel, stars, address);
                    WriteLine("Отель успешно создан!");
                    using (StreamWriter sw = new StreamWriter("hotel.txt", true))
                    {
                        string[] tmp = {'{' + Environment.NewLine + "   Название отеля: " + nameHotel + Environment.NewLine + "   Адрес: " + address + Environment.NewLine +
                            "   Количество звёзд: " + stars + Environment.NewLine + '}' };
                        foreach (string t in tmp)
                            sw.WriteLine(t);
                        sw.Close();
                    }
                    ReadLine();
                    Clear();
                    Menu();
                }
                else
                {
                    WriteLine("Поля не заполнены. Попробуйте снова.");
                    ReadLine();
                    Clear();
                    RegistrationHostel();
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Clear();
                Menu();
            }
        }

        // Вывод информации о клиентах
        static void OutputInfoClients()
        {
            try
            {
                Clear();
                if (File.Exists(Environment.CurrentDirectory + "/clients.txt"))
                {
                    using (StreamReader sr = new StreamReader("clients.txt"))
                    {
                        WriteLine("Информация о клиентах.");
                        WriteLine();
                        WriteLine("---------------------------------------------------");
                        WriteLine(sr.ReadToEnd());
                        WriteLine("---------------------------------------------------");
                        ReadLine();
                        sr.Close();
                    }
                    Clear();
                    Menu();
                }
                else
                {
                    WriteLine("Файла не существует.");
                    ReadLine();
                    Clear();
                    Menu();
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Clear();
                Menu();
            }
        }

        // Регистрация клиентов
        static void RegistrationClients()
        {
            try
            {
                Clear();
                if (hostel == null)
                {
                    WriteLine("Отель не создан!");
                    ReadLine();
                    Clear();
                    Menu();
                }
                Write("Введите имя: ");
                string name = ReadLine();
                Write("Введите фамилию: ");
                string surname = ReadLine();
                Write("Введите отчество: ");
                string lastName = ReadLine();
                restart:
                Write("Полных лет: ");
                int age = ToInt32(ReadLine());
                if (age < 18)
                {
                    WriteLine("Клиенту меньше 18. Попробуйте снова.");
                    goto restart;
                }
                Write("Дата рождения: ");
                DateTime dB = ToDateTime(ReadLine());
                int temp = DateTime.Now.Year - dB.Year;
                if (temp != age)
                {
                    WriteLine("Год рождения не совпадает с датой. Попробуйте снова.");
                    goto restart;
                }
                Write("Введите адрес проживания: ");
                string address = ReadLine();
                restart2:
                WriteLine("Пол: Ж, М?");
                char sex = ToChar(ReadLine());
                if (sex != 1046 && sex != 1052 && sex != 1078 && sex != 1084)
                {
                    Write("Некорректно введён пол. Попробуйте снова.");
                    goto restart2;
                }
                restart3:
                Write("Введите дату заезда: ");
                DateTime dStayInHotel1 = ToDateTime(ReadLine());
                Write("Введите дату выезда: ");
                DateTime dStayInHotel2 = ToDateTime(ReadLine());
                if (DateTime.Now.Year > dStayInHotel1.Year && DateTime.Now.Year < dStayInHotel1.Year ||
                    DateTime.Now.Year > dStayInHotel2.Year && DateTime.Now.Year < dStayInHotel2.Year ||
                    dStayInHotel1 > dStayInHotel2)
                {
                    WriteLine("Введена некорректная дата заезда или выезда. Попробуйте снова.");
                    goto restart3;
                }
                if (dStayInHotel2.Day - dStayInHotel2.Day > 20)
                {
                    WriteLine("Нельзя останавливаться в отеле более чем на 20 дней. Попробуйте снова.");
                    goto restart3;
                }
                if (name != null && surname != null && lastName != null && address != null)
                {
                    if (CountClients != 100)
                    {
                        restart5:
                        Clear();
                        WriteLine("------------Типы номеров------------");
                        WriteLine("1. Standart;");
                        WriteLine("2. Economy;");
                        WriteLine("3. JuniorSuite;");
                        WriteLine("4. Luxe.");
                        WriteLine("В какой хотите поселиться?");
                        int tt = ToInt32(ReadLine());
                        RoomCathegories roomCathegories = RoomCathegories.Standart;
                        double salary = 0;
                        switch (tt)
                        {
                            case 1:
                                roomCathegories = RoomCathegories.Standart;
                                salary = hostel.RoomRate(dStayInHotel1, dStayInHotel2);
                                break;
                            case 2:
                                roomCathegories = RoomCathegories.Economy;
                                salary = hostel.RoomRate(dStayInHotel1, dStayInHotel2) - 800;
                                break;
                            case 3:
                                roomCathegories = RoomCathegories.JuniorSuite;
                                salary = hostel.RoomRate(dStayInHotel1, dStayInHotel2) + 1200;
                                break;
                            case 4:
                                roomCathegories = RoomCathegories.Luxe;
                                salary = hostel.RoomRate(dStayInHotel1, dStayInHotel2) + 2500;
                                break;
                            default:
                                WriteLine("Неверный пункт. Попробуйте снова.");
                                ReadLine();
                                goto restart5;
                        }
                        CountClients++;
                        Clients client = new Clients(name, surname, lastName, age, dB, sex, address, salary, roomCathegories);
                        WriteLine("Клиент успешно добавлен!");
                        restart4:
                        Clear();
                        WriteLine("Забронируйте номер.");
                        hostel.OutputInHotel();
                        Write("Какой номер выберите: ");
                        int numberRoom = ToInt32(ReadLine());
                        Write("Этаж: ");
                        int floor = ToInt32(ReadLine());
                        if (floor <= 4 || numberRoom <= 25)
                        {
                            if (roomCathegories == RoomCathegories.Standart && floor != 1)
                            {
                                WriteLine("1 этаж - Standart. Попробуйте снова.");
                                ReadLine();
                                Clear();
                                goto restart4;
                            }
                            if (roomCathegories == RoomCathegories.Economy && floor != 2)
                            {
                                WriteLine("2 этаж - Economy. Попробуйте снова.");
                                ReadLine();
                                Clear();
                                goto restart4;
                            }
                            if (roomCathegories == RoomCathegories.JuniorSuite && floor != 3)
                            {
                                WriteLine("3 этаж - JuniorSuite(Полулюкс). Попробуйте снова.");
                                ReadLine();
                                Clear();
                                goto restart4;
                            }
                            if (roomCathegories == RoomCathegories.Luxe && floor != 4)
                            {
                                WriteLine("4 этаж - Luxe. Попробуйте снова.");
                                ReadLine();
                                Clear();
                                goto restart4;
                            }
                            if (client.ReservationRoom(floor, numberRoom) == false)
                                goto restart4;
                            else WriteLine("Номер забронирован!");
                        }
                        else
                        {
                            WriteLine("Такого номера и этажа нет.");
                            goto restart4;
                        }
                        using (StreamWriter sw = new StreamWriter("clients.txt", true))
                        {
                            string[] tmp = { "   Номер клиента: " + CountClients + Environment.NewLine + '{' + Environment.NewLine + "   Имя: " + name + Environment.NewLine + "   Фамилия: " + surname + Environment.NewLine +
                                "   Отчество: " + lastName + Environment.NewLine + "   Возраст: " + age.ToString() + Environment.NewLine + "   Дата рождения: " + dB.ToShortDateString() + Environment.NewLine + "   Адрес проживания: " + address + Environment.NewLine +
                                "   Пол: " + sex.ToString() + Environment.NewLine +
                                "   Дата заезда: " + dStayInHotel1.ToShortDateString() + Environment.NewLine + "   Дата выезда: " + dStayInHotel2.ToShortDateString() + Environment.NewLine + "   Этаж: " + floor + Environment.NewLine +
                                "   Номер: " + numberRoom + Environment.NewLine +
                                "   Стоимость номера: " + salary + Environment.NewLine + "   Тип номера: " + roomCathegories.ToString() + Environment.NewLine + '}' };
                            foreach (string t in tmp)
                                sw.WriteLine(t);
                            sw.Close();
                        }
                        ReadLine();
                        Clear();
                        WriteLine("Какие действия будут дальше?");
                        WriteLine("1. Продолжить заполнение клиентов;");
                        WriteLine("2. Вернуться в меню.");
                        char n = ToChar(ReadLine());
                        switch (n)
                        {
                            case '1':
                                Clear();
                                RegistrationClients();
                                break;
                            case '2':
                                Clear();
                                Menu();
                                break;
                            default:
                                WriteLine("Неверный пункт меню. Попробуйте снова.");
                                ReadLine();
                                Clear();
                                Menu();
                                break;
                        }
                    }
                    else
                    {
                        WriteLine("Отель заполнен!");
                        ReadLine();
                        Clear();
                        Menu();
                    }
                }
                else
                {
                    WriteLine("Поля не могут быть пустыми. Попробуйте снова.");
                    ReadLine();
                    RegistrationClients();
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Clear();
                Menu();
            }
        }

        // Меню
        static void Menu()
        {
            WriteLine("-------------------------Меню-------------------------");
            WriteLine("1. Добавление персонала;");
            WriteLine("2. Ввод клиентов;");
            WriteLine("3. Ввод информации о гостиннице;");
            WriteLine("4. Вывод информации о гостиннице;");
            WriteLine("5. Вывод информации о клиентах;");
            WriteLine("6. Вывод информации о персонале;");
            WriteLine("7. Заезд и выезд клиентов;");
            WriteLine("0. Exit.");
            WriteLine("------------------------------------------------------");
            Write("Выберите пункт меню: ");

            try
            {
                char menuN = ToChar(ReadLine());

                switch (menuN)
                {
                    case '1': RegistrationPersonal(); break;
                    case '2': RegistrationClients(); break;
                    case '3': RegistrationHostel(); break;
                    case '4': Clear();
                        if (hostel == null)
                        {
                            WriteLine("Отель не создан!");
                            ReadLine();
                            Clear();
                            Menu();
                        }
                        hostel.OutputInfoAboutHotel();
                        hostel.OutputInHotel();
                        ReadLine();
                        Clear();
                        Menu();
                        break;
                    case '5': OutputInfoClients(); break;
                    case '6': OutputPersonal(); break;
                    case '7': ControlCheckInAndOut(); break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Неверный пункт меню. Попробуйте снова.");
                        ReadLine();
                        Clear();
                        Menu();
                        break;
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Clear();
                Menu();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Чтение данных о отеле сразу при запуске приложения
                if (File.Exists(Environment.CurrentDirectory + "/hotel.txt"))
                {
                    using (StreamReader sr = new StreamReader("hotel.txt"))
                    {
                        string tmp;
                        string hotelName = "";
                        string address = "";
                        int stars = 0;
                        do
                        {
                            tmp = sr.ReadLine();
                            if (tmp.Contains("   Название отеля: "))
                                hotelName = tmp.Remove(0, 19);
                            if (tmp.Contains("   Количество звёзд: "))
                                stars = ToInt32(tmp.Remove(0, 21));
                            if (tmp.Contains("   Адрес: "))
                                address = tmp.Remove(0, 10);
                        } while (sr.EndOfStream != true);
                        hostel = new Hostel(hotelName, stars, address);
                    }
                }
                // Чтение данных о клиенте сразу при запуске приложения
                if (File.Exists(Environment.CurrentDirectory + "/clients.txt"))
                {
                    using (StreamReader sr = new StreamReader("clients.txt"))
                    {
                        string tmp;
                        int floor = 0;
                        int room = 0;
                        do
                        {
                            tmp = sr.ReadLine();
                            if (tmp == "}") CountClients++;
                            if (tmp.Contains("   Этаж: "))
                            {
                                floor = 0;
                                tmp = tmp.Remove(0, 9);
                                floor = ToInt32(tmp);
                            }
                            if (tmp.Contains("   Номер: "))
                            {
                                room = 0;
                                tmp = tmp.Remove(0, 10);
                                room = ToInt32(tmp);
                            }
                            if (floor != 0 && room != 0)
                            {
                                client = new Clients(floor, room);
                                client.ReadFloorAndRoom(floor, room);
                            }
                        } while (sr.EndOfStream != true);
                        sr.Close();
                    }
                }
                Menu();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                ReadLine();
                Clear();
                Menu();
            }
        }
    }
}
