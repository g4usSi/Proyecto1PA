using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Vehiculos
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Cuota { get; set; }
        public string Tipo { get; set; }

        public Vehiculos(string placa, string marca, string modelo, string color, int cuota)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
            this.Cuota = cuota;
        }
        public Vehiculos() { }
        //Agregar un vehiculo
        public virtual void AgregarVehiculo()
        {
            string placa, marca, modelo, color;
            Console.Write("Ingrese la placa del vehiculo: ");
            placa = Utilidades.LlenarString();
            Console.Write("Ingrese la marca del vehiculo: ");
            marca = Utilidades.LlenarString();
            Console.Write("Ingrese la modelo del vehiculo: ");
            modelo = Utilidades.LlenarString();
            Console.Write("Ingrese la color del vehiculo: ");
            color = Utilidades.LlenarString();
            //Este metodo va despues, en cada clase hija
            RegistrarVehiculo(placa, marca, modelo, color);
        }
        protected virtual void RegistrarVehiculo(string placa, string marca, string modelo, string color) 
        {
            if (placa.Length >= 8)
            {
                this.Placa = placa;
                this.Marca = marca;
                this.Modelo = modelo;
                this.Color = color;
            }
            else
            {
                Console.WriteLine("[!] Datos incorrectos, no se ha registrado el vehiculo.");
                return;
            }
        }
        public void MostrarVehiculo()
        {
            Console.WriteLine("Placa: ");
            Console.WriteLine("Marca: ");
            Console.WriteLine("Modelo: ");
            Console.WriteLine("Color: ");
            Console.WriteLine("Cuota: ");
        }
        

    }
}
