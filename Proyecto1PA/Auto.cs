﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Auto : Vehiculo
    {
        public Auto(string placa, string marca, string modelo, string color, int cuota)
            :base(placa, marca, modelo, color, cuota : 10)
        {
            this.Tipo = "Automovil";
        }
        public override int ObtenerCuota()
        {
            return base.ObtenerCuota();
        }
    }
}
