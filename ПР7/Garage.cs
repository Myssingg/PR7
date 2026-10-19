using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ПР7
{
    internal class Garage
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle()
        {
            if (vehicles.Count >= 10)
            {
                Console.Clear();
                Console.WriteLine("В гараже уже слишком много транспорта.");
                Thread.Sleep(1000);
                Console.WriteLine("Нажмите Enter чтобы продолжить");
                Console.ReadLine();
                return;
            }

            try
            {
                Console.Clear();
                Console.WriteLine("Выберите тип транспорта: \n1. Машина \n2. Велосипед \n3. Грузовик");
                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Выбран тип транспорта - Машина");
                        AddCar();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выбран тип транспорта - Велосипед");
                        AddBike();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выбран тип транспорта - Грузовик");
                        AddTruck();
                        break;
                    default:
                        Console.Clear();
                        AddVehicle();
                        Console.WriteLine("Вы ввели неверное значение, попробуйте снова.");
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("Enter - продолжить");
            Console.ReadLine();
        }

        public void RemoveVehicle()
        {
            Console.Clear();
            string model = "";

            while (String.IsNullOrWhiteSpace(model))
            {
                Console.WriteLine("Выберите тип транспорта, который хотите удалить: \n1. Машина \n2. Велосипед \n3. Грузовик");
                int choose = 0;
                try
                {
                    string tempAnswer = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(tempAnswer)) return;
                    choose = int.Parse(tempAnswer);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
               
                

                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Выбран тип транспорта - Машина");
                        model = "Машина";
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выбран тип транспорта - Велосипед");
                        model = "Велосипед";
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выбран тип транспорта - Грузовик");
                        model = "Грузовик";
                        break;
                    default:
                        Console.Clear();
                        RemoveVehicle();
                        Console.WriteLine("Вы ввели неверное значение, попробуйте снова.");
                        break;
                }
            }

            List<Vehicle> tempList = new List<Vehicle>();
            foreach (Vehicle v in vehicles)
            {
                if (v.Model == model)
                {
                    tempList.Add(v);
                }
            }

            Console.WriteLine($"Найдено выбранного транспорта - {tempList.Count}");

            if (tempList.Count == 0)
            {
                Console.WriteLine("Нажмите Enter чтобы продолжить");
                Console.ReadLine();
                return;
            }
            else
            {
                int i = 0;
                Console.WriteLine();
                while (i < tempList.Count)
                {
                    Console.WriteLine((i + 1) + ". " + tempList[i].ToString());
                    i++;
                }

                Console.WriteLine("\nВыберите транспорт, который хотите удалить (введите число):");

                int choose = 0;
                while (choose <= 0 || choose > tempList.Count)
                {
                    try
                    {
                        choose = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (choose == 0 || choose > tempList.Count) { Console.WriteLine("Нет такого транспорта. Введите число снова."); }
                }

                Console.Clear();
                Console.Write($"\nВы уверены, что хотите удалить транспорт \n****\n{tempList[choose - 1].ToString()}\n****\n");
                Console.Write("{Y / N} (По умолчанию - Y)");
                string answer = Console.ReadLine();
                if (answer == "N" || answer == "n") { return; }

                Console.WriteLine("Удаление...");
                Thread.Sleep(1000);

                var deleteVehicle = tempList[choose - 1];

                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.Equals(deleteVehicle)) { vehicles.Remove(vehicle); break; }
                }
                Console.WriteLine("Транспорт " + deleteVehicle.ToString() + "\nуспешно удален");
            }

            Console.WriteLine("Enter - продолжить");
            Console.ReadLine();
        }

        public void GarageInfo()
        {
            Console.Clear();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }

            Console.WriteLine("Enter - продолжить");
            Console.ReadLine();
        }

        public void DriveAll()
        {
            Console.Clear();
            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle.Drive());
            }

            Console.WriteLine("Enter - продолжить");
            Console.ReadLine();
        }

        private void AddCar()
        {
            int year = -1;
            int maxSpeed = -1;
            int doorsCount = -1;
            string fuelType = "";

            Console.WriteLine("Введите год выпуска вашей машины:");

            while (year <= 0 || !(year <= DateTime.Today.Year))
            {
                try
                {
                    year = int.Parse(Console.ReadLine());
                    if (year <= 0 || !(year <= DateTime.Today.Year)) { Console.WriteLine("Введите корректную дату!"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите максимальную скорость вашей машины:");

            while (maxSpeed <= 0 || maxSpeed > 200)
            {
                try
                {
                    maxSpeed = int.Parse(Console.ReadLine());
                    if (maxSpeed <= 0 || maxSpeed > 200) { Console.WriteLine("Введите корректную скорость! (от 0 до 200 км/ч)"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите количество дверей на вашем автомобиле:");

            while (doorsCount < 2 || doorsCount > 10)
            {
                try
                {
                    doorsCount = int.Parse(Console.ReadLine());
                    if (doorsCount < 2 || doorsCount > 10) { Console.WriteLine("Введите корректное количество дверей! (от 2 до 10)"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите тип топлива вашей машины: (строка)");

            while (String.IsNullOrWhiteSpace(fuelType))
            {
                try
                {
                    fuelType = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(fuelType)) { Console.WriteLine("Введите корректный тип топлива!"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            vehicles.Add(new Car(year, maxSpeed, doorsCount, fuelType));
            Console.WriteLine("Транспорт успешно добавлен");
        }

        private void AddBike()
        {
            int year = -1;
            int maxSpeed = -1;
            string typeControl = "";

            Console.WriteLine("Введите год выпуска вашего велосипеда:");

            while (year <= 0 || !(year <= DateTime.Today.Year))
            {
                try
                {
                    year = int.Parse(Console.ReadLine());
                    if (year <= 0 || !(year <= DateTime.Today.Year)) { Console.WriteLine("Введите корректную дату!"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите максимальную скорость вашго велосипеда:");

            while (maxSpeed <= 0 || maxSpeed > 100)
            {
                try
                {
                    maxSpeed = int.Parse(Console.ReadLine());
                    if (maxSpeed <= 0 || maxSpeed > 100) { Console.WriteLine("Введите корректную скорость! (от 0 до 100 км/ч"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите тип рулевого управления вашего велосипеда: (строка)");

            while (String.IsNullOrWhiteSpace(typeControl))
            {
                try
                {
                    typeControl = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(typeControl))
                    {
                        Console.WriteLine("Введите корректный тип рулевого управления!");
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            vehicles.Add(new Bike(year, maxSpeed, typeControl));
            Console.WriteLine("Транспорт успешно добавлен");
        }

        private void AddTruck()
        {
            int year = -1;
            int maxSpeed = -1;
            double weight = -1;

            Console.WriteLine("Введите год выпуска вашего грузовика:");

            while (year <= 0 || !(year <= DateTime.Today.Year))
            {
                try
                {
                    year = int.Parse(Console.ReadLine());
                    if (year <= 0 || !(year <= DateTime.Today.Year)) { Console.WriteLine("Введите корректную дату!"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите максимальную скорость вашго грузовика:");

            while (maxSpeed <= 0 || maxSpeed > 100)
            {
                try
                {
                    maxSpeed = int.Parse(Console.ReadLine());
                    if (maxSpeed <= 0 || maxSpeed > 100) { Console.WriteLine("Введите корректную скорость! (от 0 до 100 км/ч)"); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }


            Console.WriteLine("Введите максимальную грузоподъемность вашего грузовика:");

            while (weight <= 0 || weight > 1000)
            {
                try
                {
                    weight = double.Parse(Console.ReadLine());
                    if (weight <= 0 || weight > 1000)
                    {
                        Console.WriteLine("Введите корректную максимальную грузоподъемность (от 0 до 1000 кг)!");
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }



            vehicles.Add(new Truck(year, maxSpeed, weight));
            Console.WriteLine("Транспорт успешно добавлен");
        }
    }
}
