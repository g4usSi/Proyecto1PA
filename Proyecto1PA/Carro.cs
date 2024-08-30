using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Carro : Vehiculos
    {
        public Carro()
        {
            this.Cuota = 10;
            this.Tipo = "Carro";
        }
        public override void AgregarVehiculo()
        {
            base.AgregarVehiculo();
        }



    }
}
