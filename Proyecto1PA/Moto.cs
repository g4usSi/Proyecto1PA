using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Moto : Vehiculos
    {
        public Moto()
        {
            this.Cuota = 5;
            this.Tipo = "Moto";
        }
        public override void AgregarVehiculo()
        {
            base.AgregarVehiculo();
        }


    }
}
