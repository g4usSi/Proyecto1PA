using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta()
        {
            this.Cuota = 5;
            this.Tipo = "Moto";
        }
        public override int ObtenerCuota()
        {
            return this.Cuota;
        }

    }
}
