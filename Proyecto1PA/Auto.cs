using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Auto : Vehiculo
    {
        public Auto()
        {
            this.Cuota = 10;
            this.Tipo = "Carro";
        }
        public override int ObtenerCuota()
        {
            return base.ObtenerCuota();
        }
    }
}
