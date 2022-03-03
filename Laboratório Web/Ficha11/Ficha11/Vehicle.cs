using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    public abstract class Vehicle
    {
        public enum Travel
        {
            LAND,
            WATER,
            AIR
        }
        public Travel travel;
        public string color;
        public double weight;
        public string brand;
        public string model;
        public Engine engine;

        public Vehicle(Travel travel, string color, double weight, string brand, string model, Engine engine)
        {
            this.travel = travel;
            this.color = color;
            this.weight = weight;
            this.brand = brand;
            this.model = model;
            this.engine = engine;
        }

        public abstract void Start();

        public override string ToString()
        {
            return "Brand: " + brand + " Model: " + model + " Color: " + color + " ";
        }


    }
}
