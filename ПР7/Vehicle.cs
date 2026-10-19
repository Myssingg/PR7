using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПР7
{
    public abstract class Vehicle
    {
        private string _model;
        private int _year;
        private double _maxSpeed;

        public Vehicle(string model, int year, double maxSpeed)
        {
            this.Model = model;
            this.Year = year;
            this.MaxSpeed = maxSpeed;
        }

        public string Model
        {
            get { return _model; }
            set { if (_model == null) _model = value; }
        }
        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public double MaxSpeed
        {
            get { return _maxSpeed; }
            set { _maxSpeed = value; }
        }

        public virtual string Drive()
        {
            return $"{Model} движется с максимальной скоростью {MaxSpeed} км/ч";
        }

    }
}
