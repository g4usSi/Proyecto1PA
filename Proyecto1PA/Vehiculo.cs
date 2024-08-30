using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        //modificables en la heredacion
        protected int Cuota { get; set; }
        public string Tipo { get; set; }

        public Vehiculo(string placa, string marca, string modelo, string color, int cuota)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
        }
        public Vehiculo() { }

        //Agregar un vehiculo
        public virtual void RegistrarVehiculo(string placa, string marca, string modelo, string color)
        {
            if (placa.Length >= 6)
            {
                this.Placa = placa;
                this.Marca = marca;
                this.Modelo = modelo;
                this.Color = color;
            }
            else
            {
                Console.WriteLine("\t[!] Datos incorrectos, no se ha registrado el vehiculo.");
                return;
            }
        }
        public virtual void MostrarVehiculo()
        {
            Console.WriteLine($"Tipo Vehiculo: {Tipo}");
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Cuota: {Cuota}");
            //Console.WriteLine($"Hora de Registro: {}");
            //va cuando lo llame en el administrador, parking
        }
        //este metodo no se usa...
        public void MostrarVehiculos(List<Vehiculo> listaVehiculos)
        {
            foreach (var vehiculo in listaVehiculos)
            {
                vehiculo.MostrarVehiculo();
            }
        }
        //polimorf
        public virtual int ObtenerCuota()
        {
            return this.Cuota;
        }



    }
}
