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

        public Vehiculos(string placa, string marca, string modelo, string color, int cuota)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
            this.Cuota = cuota;
        }
        public Vehiculos()
        { 
            
        }
        public virtual void RegistrarVehiculo()
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
        }
        

    }
}
