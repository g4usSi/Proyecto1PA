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
        public Vehiculo VehiculoEstacionado { get; set; }
        public DateTime HoraEntrada { get; set; }
        public Pago Pago { get; set; }
        public Estacionamiento(Vehiculo vehiculo, DateTime date)
        {
            this.VehiculoEstacionado = vehiculo;
            this.HoraEntrada = date;
        }
        public Estacionamiento() { }
        //Agregacion opcion 1
        public void AsignarEspacio(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones, int tamañoEstacionamiento) 
        {
            string placa, marca, modelo, color;
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
            RegistrarTipoVehiculo(placa, marca, modelo, color, autos, motocicletas, camiones, tamañoEstacionamiento);
        }
        //Comprobar espacios
        public bool ComprobarEspaciosAutos(List<Estacionamiento> autos, int tamañoEstacionamiento)
        {
            return autos.Count < tamañoEstacionamiento;
        }
        public bool ComprobarEspaciosMotocicletas(List<Estacionamiento> motocicletas, int tamañoEstacionamiento)
        {
            return motocicletas.Count < tamañoEstacionamiento;
        }
        public bool ComprobarEspaciosCamiones(List<Estacionamiento> camiones, int tamañoEstacionamiento)
        {
            return camiones.Count < tamañoEstacionamiento;
        }
        //Registrar Vehiculo a la lista
        private void RegistrarTipoVehiculo(string placa, string marca, string modelo, string color, List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones, int tamaño)
        {
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
                    RegistrarAutomovil(placa, marca, modelo, color, autos, tamaño);
                    break;
                case 2:
                    RegistrarMotocicleta(placa, marca, modelo, color, motocicletas, tamaño);
                    break;
                case 3:
                    RegistrarCamion(placa, marca, modelo, color, camiones, tamaño);
                    break;
                default:
                    Utilidades.ErrorMensaje("Opcion incorrecta, regresando al menu principal...");
                    Utilidades.EsperaConfirmacion();
                break;
            }
        }
        //Registrar cada vehiculo
        private void RegistrarAutomovil(string placa, string marca, string modelo, string color, List<Estacionamiento> autos, int tamaño)
        {
            if (ComprobarEspaciosAutos(autos, tamaño)) 
            {
                Console.WriteLine("\t\t\t » Automovil « \n\t\t■ Cuota: Q 10/hra");
                if (placa.Length < 6 || PlacaRepetidaEnAutos(autos, placa))
                {
                    Utilidades.ErrorMensaje("Datos incorrectos, no se ha registrado el vehiculo.");
                    return;
                }
                Auto nuevoAutomovil = new Auto(placa, marca, modelo, color);
                autos.Add(new Estacionamiento(nuevoAutomovil, DateTime.Now));
                Console.WriteLine("[!] Se ha registrado su parking: " + DateTime.Now);
            }
            else 
            {
                Utilidades.ErrorMensaje("Estacionamiento completamente lleno...");
            }
        }
        private void RegistrarMotocicleta(string placa, string marca, string modelo, string color, List<Estacionamiento> motocicletas, int tamaño)
        {
            if (ComprobarEspaciosMotocicletas(motocicletas, tamaño))
            {
                Console.WriteLine("\t\t\t » Motocicleta « \n\t■ Cuota: Q5/hra");
                if (placa.Length < 6 || PlacaRepetidaEnMotocicletas(motocicletas, placa))
                {
                    Utilidades.ErrorMensaje("Datos incorrectos, no se ha registrado el vehiculo.");
                    return;
                }
                Motocicleta nuevaMotocicleta = new Motocicleta(placa, marca, modelo, color);
                motocicletas.Add(new Estacionamiento(nuevaMotocicleta, DateTime.Now));
                Console.WriteLine("[!] Se ha registrado su parking...: " + DateTime.Now);
            }
            else
            {
                Utilidades.ErrorMensaje("Estacionamiento completamente lleno...");
            }
        }

        private void RegistrarCamion(string placa, string marca, string modelo, string color, List<Estacionamiento> camiones, int tamaño)
        {
            if (ComprobarEspaciosCamiones(camiones, tamaño))
            {
                Console.WriteLine("\t\t » Camion « \n\t■ Cuota: Q15/hra");
                if (placa.Length < 6 || PlacaRepetidaEnCamiones(camiones, placa))
                {
                    Utilidades.ErrorMensaje("Datos incorrectos, no se ha registrado el vehiculo.");
                    return;
                }
                Camion nuevoCamion = new Camion(placa, marca, modelo, color);
                camiones.Add(new Estacionamiento(nuevoCamion, DateTime.Now));
                Console.WriteLine("[!] Se ha registrado su parking...: " + DateTime.Now);
            }
            else 
            {
                Utilidades.ErrorMensaje("Estacionamiento completamente lleno...");
            }
        }
        //Comprobar placa
        private bool PlacaRepetidaEnAutos(List<Estacionamiento> autos, string placa)
        {
            foreach (var auto in autos)
            {
                if (auto.VehiculoEstacionado.Placa.ToLower() == placa.ToLower())
                {
                    Utilidades.ErrorMensaje("\t\tPlaca repetida...");
                    return true;
                }
            }
            return false;
        }
        private bool PlacaRepetidaEnMotocicletas(List<Estacionamiento> motocicletas, string placa)
        {
            foreach (var motocicleta in motocicletas)
            {
                if (motocicleta.VehiculoEstacionado.Placa.ToLower() == placa.ToLower())
                {
                    Utilidades.ErrorMensaje("\t\tPlaca repetida...");
                    return true;
                }
            }
            return false;
        }
        private bool PlacaRepetidaEnCamiones(List<Estacionamiento> camiones, string placa)
        {
            foreach (var camion in camiones)
            {
                if (camion.VehiculoEstacionado.Placa.ToLower() == placa.ToLower())
                {
                    Utilidades.ErrorMensaje("\t\tPlaca repetida...");
                    return true;
                }
            }
            return false;
        }

        //Retirar vehiculo opcion 2
        public void RetirarVehiculo(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones)
        {
            Console.WriteLine();
            Console.Write("Ingrese placa del vehiculo a retirar: ");
            string placaActual = Utilidades.LlenarString();
            Estacionamiento vehiculoRetirar = BuscarVehiculo(autos, motocicletas, camiones, placaActual);

            if (vehiculoRetirar != null)
            {
                Console.WriteLine();
                Utilidades.TituloMensaje("INFORMACION DEL VEHICULO");
                vehiculoRetirar.VehiculoEstacionado.MostrarVehiculo();
                int cuotaEstacionamiento = vehiculoRetirar.CalcularCuotaEstacionamiento(vehiculoRetirar.CalcularTiempo());
                Console.WriteLine($"Hora de registro: {vehiculoRetirar.HoraEntrada}");
                Console.WriteLine("Hora actual: " + DateTime.Now);
                Console.WriteLine("La cuota de estacionamiento es: Q" + cuotaEstacionamiento);
                Console.WriteLine();

                if (EfectuarPago(cuotaEstacionamiento))
                {
                    bool eliminado = EliminarVehiculoDeListas(autos, motocicletas, camiones, vehiculoRetirar);

                    if (eliminado)
                    {
                        Console.WriteLine("Puede retirar el vehiculo...");
                        Console.WriteLine("Feliz Dia :)");
                    }
                    else
                    {
                        Console.WriteLine("El vehiculo no se encontró en ninguna lista de estacionamiento.");
                    }

                    Utilidades.EsperaConfirmacion();
                }
                else
                {
                    Console.WriteLine("El vehiculo sigue en el estacionamiento...");
                    Console.WriteLine();
                }
            }
            else
            {
                Utilidades.ErrorMensaje("No hay ninguna placa que coincida\n> > > Regresando al menu...");
                Utilidades.EsperaConfirmacion();
            }
        }
        private Estacionamiento BuscarVehiculo(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones, string placaActual)
        {
            foreach (var estacionamientoActual in autos)
            {
                if (estacionamientoActual.VehiculoEstacionado.Placa.Equals(placaActual, StringComparison.CurrentCultureIgnoreCase))
                {
                    return estacionamientoActual;
                }
            }
            foreach (var estacionamientoActual in motocicletas)
            {
                if (estacionamientoActual.VehiculoEstacionado.Placa.Equals(placaActual, StringComparison.CurrentCultureIgnoreCase))
                {
                    return estacionamientoActual;
                }
            }
            foreach (var estacionamientoActual in camiones)
            {
                if (estacionamientoActual.VehiculoEstacionado.Placa.Equals(placaActual, StringComparison.CurrentCultureIgnoreCase))
                {
                    return estacionamientoActual;
                }
            }
            return null;
        }
        private bool EliminarVehiculoDeListas(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones, Estacionamiento vehiculo)
        {
            bool eliminado = false;
            if (autos.Remove(vehiculo))
            {
                eliminado = true;
            }
            else if (motocicletas.Remove(vehiculo))
            {
                eliminado = true;
            }
            else if (camiones.Remove(vehiculo))
            {
                eliminado = true;
            }
            return eliminado;
        }
        public int CalcularTiempo()
        {
            DateTime fechaHoraSalida = DateTime.Now;
            TimeSpan tiempoTranscurrido = fechaHoraSalida - HoraEntrada;
            double minutosTotales = tiempoTranscurrido.TotalMinutes;
            int horasRedondeadas = (int)Math.Ceiling(minutosTotales / 60);
            return horasRedondeadas;
        }
        public int CalcularCuotaEstacionamiento(int tiempoTranscurrido) 
        {
            return tiempoTranscurrido * VehiculoEstacionado.ObtenerCuota();
        }
        private bool EfectuarPago(int cuota) 
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
                        Console.Write($"Ingrese el numero de tarjeta: ");
                        numTarjeta = Utilidades.LlenarString();
                        Console.Write($"Ingrese el nombre del titular: ");
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
            VehiculoEstacionado.MostrarVehiculo();
        }
        private bool EstacionamientoOcupado(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones)
        {
            if (autos.Count > 0)
            {
                return true;
            }
            if (motocicletas.Count > 0)
            {
                return true;
            }
            if (camiones.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void MostrarInformacionLista(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones) 
        {
            if (EstacionamientoOcupado(autos, motocicletas, camiones))
            {
                Utilidades.TituloMensaje("\t INFORMACION DE LOS VEHICULOS");
                Console.WriteLine();
                int posicion = 1;
                foreach (var vehiculo in autos)
                {
                    Console.WriteLine("\t\t\tVehiculo #" + posicion);
                    vehiculo.MostrarInformacion();
                    Console.WriteLine($"Hora de registro: {vehiculo.HoraEntrada}");
                    posicion++;
                    Console.WriteLine();
                }
                foreach (var vehiculo in motocicletas)
                {
                    Console.WriteLine("\t\t\tVehiculo #" + posicion);
                    vehiculo.MostrarInformacion();
                    Console.WriteLine($"Hora de registro: {vehiculo.HoraEntrada}");
                    posicion++;
                    Console.WriteLine();
                }
                foreach (var vehiculo in camiones)
                {
                    Console.WriteLine("\t\t\tVehiculo #" + posicion);
                    vehiculo.MostrarInformacion();
                    Console.WriteLine($"Hora de registro: {vehiculo.HoraEntrada}");
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
        public void EspaciosDisponibles(List<Estacionamiento> autos, List<Estacionamiento> motocicletas, List<Estacionamiento> camiones, int tamañoParqueo)
        {
            if (Disponibilidad(autos, tamañoParqueo))
            {
                Utilidades.TituloMensaje("░░░ AUTOS ░░░");
                Console.WriteLine("Espacios disponibles: " + (autos.Count - tamañoParqueo));
                ImprimirEspacios(autos.Count, tamañoParqueo);
                Console.WriteLine();
            }
            else
            {
                Utilidades.ErrorMensaje("Estacionamiento  de autos lleno, no hay espacios disponibles...");
                Console.WriteLine();
            }

            if (Disponibilidad(motocicletas, tamañoParqueo))
            {
                Utilidades.TituloMensaje("░░░ MOTOS ░░░");
                Console.WriteLine("Espacios disponibles: " + (motocicletas.Count - tamañoParqueo));
                ImprimirEspacios(motocicletas.Count, tamañoParqueo);
                Console.WriteLine();
            }
            else
            {
                Utilidades.ErrorMensaje("Estacionamiento de motocicletas lleno, no hay espacios disponibles...");
                Console.WriteLine();
            }

            if (Disponibilidad(camiones, tamañoParqueo))
            {
                Utilidades.TituloMensaje("░░░ CAMIONES ░░░");
                Console.WriteLine("Espacios disponibles: " + (camiones.Count - tamañoParqueo));
                ImprimirEspacios(camiones.Count, tamañoParqueo);
                Console.WriteLine();
            }
            else
            {
                Utilidades.ErrorMensaje("Estacionamiento de camiones lleno, no hay espacios disponibles...");
                Console.WriteLine();
            }
        }
        private void ImprimirEspacios(int espaciosOcupados, int tamañoParqueo) 
        {
            for (int i = 1; i <= espaciosOcupados;i++) 
            {
                Console.WriteLine("\t#" + i + "   Espacio ocupado");
            }
            for (int i = (espaciosOcupados + 1); i <= tamañoParqueo; i++)
            {
                Console.WriteLine("\t#"+ i +"   Espacio disponible");
            }

        }
        private bool Disponibilidad(List<Estacionamiento> vehiculos, int tamaño)
        {
            if (vehiculos.Count >= tamaño) 
            {
                return false;
            }
            return true;
        }


    }
}
