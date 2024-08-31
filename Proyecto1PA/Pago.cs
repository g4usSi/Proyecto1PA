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
        public Pago(int MontoIngresado)
        {
            this.MontoIngresado = MontoIngresado;
        }
        public virtual void CalcularCambio(int tiempoTotal) 
        {

        }



    }

    public class Efectivo : Pago 
    {
        public Efectivo(int montoIngresado)
            : base(montoIngresado)
        {
            
        }
        private int[] DenomSystem = { 200, 100, 50, 20, 10, 5, 1};
        private string[] BilleSystem = { "Billete(s) de Q200", "Billete(s) de Q100", "Billete(s) de Q50", "Billete(s) de Q20", "Billete(s) de Q10", "Billete(s) de Q5", "Moneda(s) de Q1" };
        public override void CalcularCambio(int cuotaTotal)
        {

            for (int i = 0; i < DenomSystem.Length; i++) 
            {
                int cantidad = cambio / denominaciones[i];
                if (cantidad > 0)
                {
                    Console.WriteLine(cantidad + " " + [i]);
                    cambio %= BilleSystem[i];
                }
            }
        }
    }

    public class Tarjeta : Pago 
    { 
        private string NumeroTarjeta { get; set; }
        private string NombreTitular { get; set; }
        private DateOnly FechaVencimiento { get; set; }
        private int CVV { get; set; }

        public Tarjeta(int montoIngresado, string numeroTarjeta, string nombreTitular, DateOnly fechaVencimiento, int cVV)
            : base(montoIngresado)
        {
            //tirar excepciones o logica para repetir procesos
            NumeroTarjeta = numeroTarjeta;
            NombreTitular = nombreTitular;
            FechaVencimiento = fechaVencimiento;
            CVV = cVV;
        }
        public override void CalcularCambio(int tiempoTotal)
        {
            
        }


    }
}
