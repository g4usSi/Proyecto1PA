using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Camion : Vehiculo
    {
        public Camion()
        {
            this.Cuota = 15;
            this.Tipo = "Camion";
        }
        public override int ObtenerCuota()
        {
            return this.Cuota;
        }
    }
}
