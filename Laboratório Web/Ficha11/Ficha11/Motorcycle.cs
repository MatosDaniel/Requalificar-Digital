using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    internal class Motorcycle : Vehicle, IVehicle
    {
        public enum Type{
            SPORT,
            CRUISER,
            ADVENTURE
        }
        public Type type;
        public int maxVelocity;

        public Motorcycle(Type type, int maxVelocity, Travel travel, string color, double weight, string brand, string model, 
            Engine engine) : base(travel, color, weight, brand, model, engine)
        {
            this.type = type;
            this.maxVelocity = maxVelocity;
        }

        public override string ToString()
        {
            string str = "Type: " + type + ". Max Velocity: " + maxVelocity;

            return base.ToString() + str;
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        public void Drive()
        {
            Console.WriteLine("Mãos no guiador");
        }
    }
}
