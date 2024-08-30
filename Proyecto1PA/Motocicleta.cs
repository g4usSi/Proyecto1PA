using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta(string placa, string marca, string modelo, string color, int cuota)
            : base(placa, marca, modelo, color, cuota: 5)
        {
            this.Tipo = "Motocicleta";
        }
        public override int ObtenerCuota()
        {
            return this.Cuota;
        }

    }
}
