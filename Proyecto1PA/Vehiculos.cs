﻿using System;
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
        //modificables en la heredacion
        public int Cuota { get; set; }
        public string Tipo { get; set; }

        public Vehiculos(string placa, string marca, string modelo, string color, int cuota)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Color = color;
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
            RegistrarVehiculo(placa, marca, modelo, color);
        }
        protected virtual void RegistrarVehiculo(string placa, string marca, string modelo, string color)
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
                Console.WriteLine("[!] Datos incorrectos, no se ha registrado el vehiculo.");
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
        public void MostrarVehiculos(List<Vehiculos> listaVehiculos)
        {
            foreach (var vehiculo in listaVehiculos)
            {
                vehiculo.MostrarVehiculo();
            }
        }
        //polimorf
        public virtual int ObtenerCuota()
        {
            return Cuota;
        }



    }
}
