using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    internal class Car : Vehicle, IVehicle
    {
        public int numberOfDoors;
        public int seats;

        public Car(int numberOfDoors, int seats, Travel travel, string color, double weight, string brand, string model, 
            Engine engine) : base(travel, color, weight, brand, model, engine)
        {
            this.numberOfDoors = numberOfDoors;
            this.seats = seats;
        }

        public override string ToString()
        {
            string str = "Number of doors: " + numberOfDoors + ". Seats: " + seats + " " + engine.ToString();

            return base.ToString() + str;
        }
        public override void Start()
        {
            throw new NotImplementedException();
        }

        public void Drive()
        {
            Console.WriteLine("Mãos no volante e pés nos pedais");
        }
    }
}
