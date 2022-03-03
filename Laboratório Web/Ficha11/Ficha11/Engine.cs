using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    public class Engine
    {
        public double torque;
        public double displacement;
        public double horsepower;

        public Engine(double torque, double displacement, double horsepower)
        {
            this.torque = torque;
            this.displacement = displacement;
            this.horsepower = horsepower;
        }

        public override string ToString()
        {
            return "Torque: " + torque + " Horsepower: " + horsepower;
        }
    }
}
