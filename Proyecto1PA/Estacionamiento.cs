using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Estacionamiento
    {
        public Vehiculo Vehiculo { get; set; }
        public DateTime Hora { get; set; }
        public Pago Pago { get; set; }
        public Estacionamiento(Vehiculo vehiculo, DateTime date)
        {
            this.Vehiculo = vehiculo;
            this.Hora = date;
        }
        public Estacionamiento() { }
        //Agregacion opcion 1
        public void AsignarEspacio(List<Estacionamiento> listaEstacionamiento, int tamañoEstacionamiento) 
        {
            string placa, marca, modelo, color;
            if (ComprobarEspacios(listaEstacionamiento, tamañoEstacionamiento))
            {
                Console.WriteLine();
                Console.Write("Ingrese la placa del vehiculo: ");
                placa = Utilidades.LlenarString().ToUpper();
                Console.Write("Ingrese la marca del vehiculo: ");
                marca = Utilidades.LlenarString();
                Console.Write("Ingrese el modelo del vehiculo: ");
                modelo = Utilidades.LlenarString();
                Console.Write("Ingrese el color del vehiculo: ");
                color = Utilidades.LlenarString();
                Console.WriteLine();
                RegistrarTipoVehiculo(placa, marca, modelo, color, listaEstacionamiento);
            }
            else
            {
                Utilidades.ErrorMensaje("Estacionamiento completamente lleno...");
            }
        }
        public bool ComprobarEspacios(List<Estacionamiento> listaEspacios, int tamañoEstacionamiento) 
        {
            if (listaEspacios.Count < tamañoEstacionamiento)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void RegistrarTipoVehiculo(string placa, string marca, string modelo, string color, List<Estacionamiento> listaEspacios) 
        {
            if (placa.Length < 6 || PlacaRepetida(listaEspacios, placa))
            {
                Utilidades.ErrorMensaje("Datos incorrectos, no se ha registrado el vehiculo.");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■ Seleccione el tipo de vehiculo");
            Console.ResetColor();
            Console.WriteLine("   1. Automovil");
            Console.WriteLine("   2. Motocicleta");
            Console.WriteLine("   3. Camion");
            Console.Write(" > Ingrese una opcion: ");
            int opcion = Utilidades.LlenarNumeroEntero();
            Console.WriteLine();

            switch (opcion) 
            {
                case 1:
                    Console.WriteLine("\t\t\t » Automovil « \n\t■ Cuota: Q 10/hra");
                    Auto nuevoAutomovil = new Auto(placa, marca, modelo, color);
                    listaEspacios.Add(new Estacionamiento(nuevoAutomovil, DateTime.Now));
                    Console.WriteLine("[!] Se ha registrado su parking: " + DateTime.Now);
                    break;
                case 2:
                    Console.WriteLine("\t\t\t » Motocicleta « \n\t■ Cuota: Q5/hra");
                    Motocicleta nuevaMotocicleta = new Motocicleta(placa, marca, modelo, color);
                    listaEspacios.Add(new Estacionamiento(nuevaMotocicleta, DateTime.Now));
                    Console.WriteLine("[!] Se ha registrado su parking...: " + DateTime.Now);
                    break;
                case 3:
                    Console.WriteLine("\t\t » Camion « \n\t■ Cuota: Q15/hra");
                    Camion nuevoCamion = new Camion(placa, marca, modelo, color);
                    listaEspacios.Add(new Estacionamiento(nuevoCamion, DateTime.Now));
                    Console.WriteLine("[!] Se ha registrado su parking...: "+DateTime.Now);
                    break;
                default:
                    Utilidades.ErrorMensaje("Opcion incorrecta, regresando al menu principal...");
                    Utilidades.EsperaConfirmacion();
                return;
            }
        }
        private bool PlacaRepetida(List<Estacionamiento> listaEstacionamiento, string placa) 
        {
            foreach (var vehiculoActual in listaEstacionamiento) 
            {
                if (vehiculoActual.Vehiculo.Placa.ToLower() == placa.ToLower()) 
                {
                    Utilidades.ErrorMensaje("\t\tPlaca repetida");
                    return true;
                }
            }
            return false;
        }
        //Retirar vehiculo opcion 2
        public void RetirarVehiculo(List<Estacionamiento> listaEstacionamiento) 
        {
            Console.WriteLine();
            Console.Write("Ingrese placa del vehiculo a retirar: ");
            string placaActual = Utilidades.LlenarString();
            Estacionamiento vehiculoRetirar = BuscarVehiculo(listaEstacionamiento, placaActual);
            if (vehiculoRetirar != null)
            {
                Console.WriteLine();
                Utilidades.TituloMensaje("INFORMACION DEL VEHICULO");
                vehiculoRetirar.Vehiculo.MostrarVehiculo();
                int cuotaEstacionamiento = vehiculoRetirar.CalcularCuotaEstacionamiento(vehiculoRetirar.CalcularTiempo());
                Console.WriteLine($"Hora de registro: {vehiculoRetirar.Hora}");
                Console.WriteLine("Hora actual: " + DateTime.Now);
                Console.WriteLine("Su cuota de estacionamiento es: Q"+cuotaEstacionamiento);
                Console.WriteLine();
                if (EfectuarPago(cuotaEstacionamiento))
                {
                    listaEstacionamiento.Remove(vehiculoRetirar);
                    Console.WriteLine("Puede retirar el vehiculo...");
                    Console.WriteLine("Feliz Dia :)");
                    Utilidades.EsperaConfirmacion();
                }
                else
                {
                    Console.WriteLine("Su vehiculo sigue en el estacionamiento...");
                    Console.WriteLine();
                return;
                }
            }
            else
            {
                Utilidades.ErrorMensaje("No hay ninguna placa que coincida\n\tRegresando al menu...");
                Utilidades.EsperaConfirmacion();
            }
        }
        //funcion busqueda
        private Estacionamiento BuscarVehiculo(List<Estacionamiento> listaEstacionamiento, string placaActual) 
        {
            foreach (var estacionamientoActual in listaEstacionamiento)
            {
                if (estacionamientoActual.Vehiculo.Placa.ToLower().Equals(placaActual, StringComparison.CurrentCultureIgnoreCase))
                {
                    return estacionamientoActual;
                }
            }
            return null;
        }
        public int CalcularTiempo()
        {
            DateTime fechaHoraSalida = DateTime.Now;
            TimeSpan tiempoTranscurrido = fechaHoraSalida - Hora;
            double minutosTotales = tiempoTranscurrido.TotalMinutes;
            int horasRedondeadas = (int)Math.Ceiling(minutosTotales / 60);
            return horasRedondeadas;
        }
        public int CalcularCuotaEstacionamiento(int tiempoTranscurrido) 
        {
            return tiempoTranscurrido * Vehiculo.ObtenerCuota();
        }
        public bool EfectuarPago(int cuota) 
        {
            string numTarjeta, nombreTitular;
            int cvv;
            DateOnly fechaTarjeta;

            bool entradaIncorrecta = false;
            int opcion;
            while (!entradaIncorrecta)
            {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■ Seleccione el metodo de pago:");
            Console.ResetColor();
            Console.WriteLine("   1. Efectivo");
            Console.WriteLine("   2. Tarjeta");
            Console.WriteLine("   3. Cancelar");
            Console.Write(" > Ingrese una opcion: ");
            opcion = Utilidades.LlenarNumeroEntero();
                switch (opcion)
                {
                    case 1:
                        Utilidades.TituloMensaje("PAGO CON EFECTIVO");
                        Console.Write("Ingrese el monto del cliente: ");
                        int montoCliente = Utilidades.LlenarNumeroEntero();
                        this.Pago = new Efectivo(montoCliente, cuota);
                        Pago.Cobrar(Pago.CalcularCambio());
                        Console.WriteLine();
                        return true;
                    case 2:
                        Utilidades.TituloMensaje("PAGO CON TARJETA");
                        Console.Write($"Ingrese el numero de tarjeta:");
                        numTarjeta = Utilidades.LlenarString();
                        Console.Write($"Ingrese el nombre del titular:");
                        nombreTitular = Utilidades.LlenarString();
                        Console.Write($"Ingrese la fecha de vencimiento (dd/MM/yyyy): ");
                        fechaTarjeta = Utilidades.ObtenerFecha();
                        Console.Write($"Ingrese el numero CVV: ");
                        cvv = Utilidades.LlenarNumeroEntero();
                        this.Pago = new Tarjeta(cuota, numTarjeta, nombreTitular, fechaTarjeta, cvv);
                        Pago.Cobrar(0);
                        return true;
                    case 3:
                        Console.WriteLine("> Regresando al Menu...");
                        Utilidades.EsperaConfirmacion();
                        return false;
                    default:
                        Console.WriteLine("Opcion incorrecta...");
                    break;
                }
            }
            return false;
        }

        //Mostrar opcion 3
        public void MostrarInformacion()
        {
            Vehiculo.MostrarVehiculo();
        }
        public void MostrarInformacionLista(List<Estacionamiento> listaEstacionamiento) 
        {
            if (listaEstacionamiento.Count > 0)
            {
                Utilidades.TituloMensaje("\t INFORMACION DE LOS VEHICULOS");
                Console.WriteLine();
                int posicion = 1;
                foreach (var vehiculo in listaEstacionamiento)
                {
                    Console.WriteLine("\t\t\tVehiculo #" + posicion);
                    vehiculo.MostrarInformacion();
                    Console.WriteLine($"Hora de registro: {vehiculo.Hora}");
                    posicion++;
                    Console.WriteLine();
                }
            }
            else
            {
                Utilidades.ErrorMensaje("Aun no hay vehiculos en el estacionamiento...");
                return;
            }
        }
        //Espacios Disponibles
        public void EspaciosDisponibles(List<Estacionamiento> listaEstacionamientos, int tamañoParqueo)
        {
            bool hayEspacio = ComprobarEspacios(listaEstacionamientos, tamañoParqueo);
            if (hayEspacio)
            {
                int espaciosOcupados = listaEstacionamientos.Count;
                int espaciosDisponibles = tamañoParqueo - espaciosOcupados;
                Console.WriteLine("Espacios disponibles: " + espaciosDisponibles);
            }
            else
            {
                Console.WriteLine("Estacionamiento lleno, no hay espacios disponibles...");
            }
        }


    }
}
