using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Camion : Vehiculo
    {
        public Camion(string placa, string marca, string modelo, string color)
            : base(placa, marca, modelo, color)
        {
            this.Cuota = 15;
            this.Tipo = "Camion";
        }
        public override int ObtenerCuota()
        {
            return this.Cuota;
        }
        public override void MostrarVehiculo()
        {
            base.MostrarVehiculo();
        }
    }
}
