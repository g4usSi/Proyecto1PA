using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Pago
    {
        public int Cuota { get; set; }
        //este se le hereda a tarjeta... solo son sus atributos privados de verificacion
        public Pago(int cuota)
        {
            this.Cuota = cuota;
        }
        public virtual void Cobrar(int cambio) { }
        public virtual int CalcularCambio() 
        {
        return 0;
        }
    }

    public class Efectivo : Pago 
    {
        public int MontoIngresado { get; set; }
        public Efectivo(int montoIngresado, int cuota)
            : base(cuota)
        {
            this.MontoIngresado = montoIngresado;
        }
        private int[] DenomSystem = { 200, 100, 50, 20, 10, 5, 1};
        private string[] BilleSystem = { "Billete(s) de Q200", "Billete(s) de Q100", "Billete(s) de Q50", "Billete(s) de Q20", "Billete(s) de Q10", "Billete(s) de Q5", "Moneda(s) de Q1" };
        public override void Cobrar(int cambio)
        {
            if (cambio != 0)
            {
                for (int i = 0; i < DenomSystem.Length; i++)
                {
                    int cantidad = cambio / DenomSystem[i];
                    if (cantidad > 0)
                    {
                        Console.WriteLine(cantidad + " " + BilleSystem[i]);
                        cambio %= DenomSystem[i];
                    }
                }
            }
            else
            {
                Console.WriteLine("Feliz dia");
            }
        }
        public override int CalcularCambio()
        {
            while (MontoIngresado < Cuota)
            {
                Console.WriteLine($"El monto ingresado ({MontoIngresado}) es insuficiente para cubrir la cuota de Q{Cuota}.");
                Console.WriteLine("Se le ha multado con Q5 adicionales.");
                Cuota += 5;
                Console.WriteLine($"Nueva cuota: Q{Cuota}");
                Console.WriteLine();
                Console.Write("> Vuelva a ingresar el monto: ");
                this.MontoIngresado = Utilidades.LlenarNumeroEntero();
            }
            return MontoIngresado - Cuota;
        }

    }

    public class Tarjeta : Pago 
    { 
        private string NumeroTarjeta { get; set; }
        private string NombreTitular { get; set; }
        private DateOnly FechaVencimiento { get; set; }
        private int CVV { get; set; }

        public Tarjeta(int cuota, string numeroTarjeta, string nombreTitular, DateOnly fechaVencimiento, int cVV)
            : base(cuota)
        {
            NumeroTarjeta = ValidarNumeroTarjeta(numeroTarjeta);
            NombreTitular = ValidarNombreTitular(nombreTitular);
            FechaVencimiento = ValidarFechaVencimiento(fechaVencimiento);
            CVV = ValidarCVV(cVV);
        }
        public override void Cobrar(int cambio = 0) 
        {
            EmitirFactura();
            Utilidades.EsperaConfirmacion();
            Console.WriteLine();
        }
        public void EmitirFactura() 
        {
            Console.WriteLine("Datos de Factura");
            Console.WriteLine($"Numero de tarjeta: {NumeroTarjeta}");
            Console.WriteLine($"Nombre: {NombreTitular}");
            Console.WriteLine($"Total: Q{Cuota}");
            Console.WriteLine($"Fecha de emision: {DateTime.Now}");
        }
        private string ValidarNumeroTarjeta(string numeroTarjeta)
        {
            if (numeroTarjeta.Length != 16 || !numeroTarjeta.All(char.IsDigit))
            {
                Console.WriteLine("Número de tarjeta inválido. Ingrese nuevamente:");
                return ValidarNumeroTarjeta(Utilidades.LlenarString());
            }
            return numeroTarjeta;
        }

        private string ValidarNombreTitular(string nombreTitular)
        {
            if (string.IsNullOrWhiteSpace(nombreTitular))
            {
                Console.WriteLine("Nombre del titular inválido. Ingrese nuevamente:");
                return ValidarNombreTitular(Utilidades.LlenarString());
            }
            return nombreTitular;
        }

        private DateOnly ValidarFechaVencimiento(DateOnly fechaVencimiento)
        {
            if (fechaVencimiento <= DateOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Fecha de vencimiento inválida. Ingrese nuevamente:");
                return ValidarFechaVencimiento(Utilidades.LlenarFecha());
            }
            return fechaVencimiento;
        }

        private int ValidarCVV(int cVV)
        {
            if (cVV.ToString().Length != 3)
            {
                Console.WriteLine("CVV inválido. Ingrese nuevamente:");
                return ValidarCVV(Utilidades.LlenarNumeroEntero());
            }
            return cVV;
        }
    }
}
