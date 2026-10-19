using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ПР7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();

            while (true)
            {
                Console.Clear();
                print();

                int choose = -1;
                while (choose < 0 || choose > 4)
                {
                    try
                    {
                        choose = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Введите число выбора снова.");
                    }

                }

                switch (choose)
                {
                    case 1:
                        garage.AddVehicle();
                        Console.Clear();
                        print();
                        break;
                    case 2:
                        garage.RemoveVehicle();
                        Console.Clear();
                        print();
                        break;
                    case 3:
                        garage.GarageInfo();
                        Console.Clear();
                        print();
                        break;
                    case 4:
                        garage.DriveAll();
                        Console.Clear();
                        print();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такого выбора нет. Попробуйте снова.");
                        break;

                }
            }

        }

        private static void print()
        {
            Console.WriteLine("Выберите действие: \n1. Добавить траспортное средство \n2. Удалить транспортное средство " +
                "\n3. Вывести информацию о каждом транспортном средстве \n4. Вывести информацию о \"Drive\" каждого транспорта" +
                "\n0. Выйти");
        }
    }
}
