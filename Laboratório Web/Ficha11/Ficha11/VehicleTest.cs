using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha11
{
    internal class VehicleTest
    {
        private IVehicle vehi;

        public VehicleTest(IVehicle vehi)
        {
            this.vehi = vehi;
        }

        public IVehicle Vehi { get { return vehi; } }
    }
}
