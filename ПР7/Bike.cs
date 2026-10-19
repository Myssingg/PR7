using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7
{
    internal class Bike : Vehicle
    {
        private string _typeControl;

        public Bike(int year, int maxSpeed, string typeControl) : base("Велосипед", year, maxSpeed)
        {
            TypeControl = typeControl;
        }

        public string TypeControl
        {
            get { return _typeControl; }
            set { _typeControl = value; }
        }



        public override string ToString()
        {
            return $"{Model} {Year} года выпуска с максимальной скоростью {MaxSpeed} и типом рулевого управления - {TypeControl}";
        }
    }
}
