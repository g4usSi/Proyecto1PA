using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Pago
    {
        public int MontoIngresado { get; set; }
        //este se le hereda a tarjeta... solo son sus atributos privados de verificacion
        public virtual void CalcularCambio() 
        {

        }



    }

    public class Efectivo : Pago 
    {
        private int[] DenomSystem = { 200, 100, 50, 20, 10, 5, 1};
        private string[] BilletesSystem = { "Doscientos", "Cien", "Ciencunta", "Veinte", "Cinco", "Moneda" };
        public override void CalcularCambio()
        {
            
        }

    }

    public class Tarjeta : Pago 
    { 
        
    }
}
