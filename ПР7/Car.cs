using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7
{
    internal class Car : Vehicle
    {
        private int _doorsCount;
        private string _fuelType;

        public Car(int year, int maxSpeed, int doorsCount, string fuelType) : base("Машина", year, maxSpeed)
        {
            DoorsCount = doorsCount;
            FuelType = fuelType;
        }
        public int DoorsCount
        {
            get { return _doorsCount; }
            set { _doorsCount = value; }
        }
        public string FuelType
        {
            get { return _fuelType; }
            set { _fuelType = value; }
        }



        public override string ToString()
        {
            return $"{Model} {Year} года выпуска с максимальной скоростью {MaxSpeed}, количеством дверей - {DoorsCount} и типом топлива - {FuelType}";
        }
    }
}
