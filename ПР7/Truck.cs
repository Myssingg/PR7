using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7
{
    internal class Truck : Vehicle
    {
        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public Truck(int year, int maxSpeed, double weight) : base("Грузовик", year, maxSpeed)
        {
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Model} {Year} года выпуска с максимальной скоростью {MaxSpeed} и максимальной грузоподъемностью {Weight} кг";
        }
    }
}
