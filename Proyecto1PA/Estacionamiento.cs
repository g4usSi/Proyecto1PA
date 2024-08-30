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
        public Estacionamiento(Vehiculo vehiculo, DateTime date)
        {
            this.Vehiculo = vehiculo;
            this.Hora = date;
        }
        public Estacionamiento() { }

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
                SeleccionarTipoVehiculo(placa, marca, modelo, color, listaEstacionamiento);
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
        private void SeleccionarTipoVehiculo(string placa, string marca, string modelo, string color, List<Estacionamiento> listaEspacios) 
        {
            Console.WriteLine("Seleccione el tipo de vehiculo");
            Console.WriteLine("1. Automovil");
            Console.WriteLine("2. Motocicleta");
            Console.WriteLine("3. Camion");
            Console.Write("Ingrese una opcion: ");
            int opcion;
            switch (opcion = Utilidades.LlenarNumeroEntero()) 
            {
                case 1:
                    Console.WriteLine("Automovil\nCuota: Q10/hra");
                    Auto nuevoAutomovil = new Auto(placa, marca, modelo, color);
                    listaEspacios.Add(new Estacionamiento(nuevoAutomovil, DateTime.Now));
                    Console.WriteLine("> Se ha registrado su parking...");
                    break;
                case 2:
                    Console.WriteLine("Motocicleta\nCuota: Q5/hra");
                    Motocicleta nuevaMotocicleta = new Motocicleta(placa, marca, modelo, color);
                    listaEspacios.Add(new Estacionamiento(nuevaMotocicleta, DateTime.Now));
                    Console.WriteLine("> Se ha registrado su parking...");
                    break;
                case 3:
                    Console.WriteLine("Camion\nCuota: Q15/hra");
                    Camion nuevoCamion = new Camion(placa, marca, modelo, color);
                    listaEspacios.Add(new Estacionamiento(nuevoCamion, DateTime.Now));
                    Console.WriteLine("> Se ha registrado su parking...");
                    break;
                default:
                    Console.WriteLine("Opcion incorrecta, regresando al menu...");
                return;
            }
        }



    }
}
