using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Estacionamiento
    {
        public Vehiculo Vehiculo { get; set; }
        public DateTime Hora { get; set; }
        public int Pago { get; set; }
        public Estacionamiento(Vehiculo vehiculo, DateTime date, int pago)
        {
            this.Vehiculo = vehiculo;
            this.Hora = date;
            Pago = pago;
        }

        public void AsignarEspacio(List<Estacionamiento> listaEstacionamiento, int tamañoEstacionamiento) 
        {
            string placa, marca, modelo, color;
            if (ComprobarEspacios(listaEstacionamiento, tamañoEstacionamiento))
            {
                Console.WriteLine();
                Console.Write("Ingrese la placa del vehiculo: ");
                placa = Utilidades.LlenarString();
                Console.Write("Ingrese la marca del vehiculo: ");
                marca = Utilidades.LlenarString();
                Console.Write("Ingrese el modelo del vehiculo: ");
                modelo = Utilidades.LlenarString();
                Console.Write("Ingrese el color del vehiculo: ");
                color = Utilidades.LlenarString();


            }
            else
            {
                Console.WriteLine("Estacionamiento completamente lleno...");
            }
        }
        public bool ComprobarEspacios(List<Estacionamiento> listaEspacios, int tamañoEstacionamiento) 
        {
            if (listaEspacios.Count <= tamañoEstacionamiento)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void SeleccionarTipoVehiculo(string placa, string marca, string modelo, string color) 
        {
            Console.WriteLine("1. Automovil");
            Console.WriteLine("2. Motocicleta");
            Console.WriteLine("3. Camion");

            int opcion;
            switch (opcion = Utilidades.LlenarNumeroEntero()) 
            {
                case 1:
                    Console.WriteLine("");
                break;
                case 2:
                break;
                case 3:
                break;
            }
        }



    }
}
