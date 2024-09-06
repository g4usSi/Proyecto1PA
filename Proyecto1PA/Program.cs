//Version de solo 1 lista
namespace Proyecto1PA
{ 
    public class Program
    {
        public static int tamañoEstacionamiento = 20;
        public static void main(string[] args)
        {
            // Programa Base
            Estacionamiento estacionamiento = new Estacionamiento();
            List<Estacionamiento> listaAutos = new List<Estacionamiento>();
            List<Estacionamiento> listaMotocicletas = new List<Estacionamiento>();
            List<Estacionamiento> listaCamiones = new List<Estacionamiento>();

            int opcion = 0;
            bool salir = false;
            do
            {
                Menu();
                Console.Write("\n  > Ingrese una opcion: ");
                switch (opcion = Utilidades.LlenarNumeroEntero())
                {
                    case 1:
                        Console.Clear();
                        Utilidades.TituloMensaje("▓▓▓▓▓▓ REGISTRAR VEHICULO ▓▓▓▓▓▓");
                        estacionamiento.AsignarEspacio(listaAutos, listaMotocicletas, listaCamiones, tamañoEstacionamiento);
                        Utilidades.EsperaConfirmacion();
                        break;
                    case 2:
                        Console.Clear();
                        Utilidades.TituloMensaje("▓▓▓▓▓▓ RETIRAR VEHICULO ▓▓▓▓▓▓");
                        estacionamiento.MostrarInformacionLista(listaVehiculos);
                        Console.WriteLine("──────────────────────────────────────────────────────────────────────────────────────────");
                        estacionamiento.RetirarVehiculo(listaVehiculos);
                        break;
                    case 3:
                        Console.Clear();
                        Utilidades.TituloMensaje("▓▓▓▓▓▓ MOSTRAR VEHICULOS ESTACIONADOS ▓▓▓▓▓▓");
                        estacionamiento.MostrarInformacionLista(listaVehiculos);
                        Console.WriteLine();
                        Utilidades.EsperaConfirmacion();
                        break;
                    case 4:
                        Console.Clear();
                        Utilidades.TituloMensaje("▓▓▓▓▓▓ MOSTRAR ESPACIOS DISPONIBLES ▓▓▓▓▓▓");
                        estacionamiento.EspaciosDisponibles(listaVehiculos, tamañoEstacionamiento);
                        Console.WriteLine();
                        Utilidades.EsperaConfirmacion();
                        break;
                    case 5:
                        Console.Clear();
                        Utilidades.TituloMensaje("▓▓▓▓▓▓ SALIR ▓▓▓▓▓▓");
                        Console.WriteLine("[!] Los datos del programa se eliminaran...");
                        salir = Utilidades.TerminarEjecucion();
                        break;
                    default:
                        Console.Clear();
                        Utilidades.ErrorMensaje("Opcion Incorrecta...\n> > > Regresando al menu...\n");
                        break;
                }
            } while (!salir);
            
            static void Menu()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\tPARQUEO XYZ");
                Console.WriteLine("\t  ▓▓▓▓▓▓▓▓▓▓▓▓ Menu Principal ▓▓▓▓▓▓▓▓▓▓▓▓");
                Console.ResetColor();
                Console.WriteLine("\n1. Registrar vehiculo");
                Console.WriteLine("2. Retirar vehiculo");
                Console.WriteLine("3. Mostrar vehiculos estacionados");
                Console.WriteLine("4. Mostrar espacios disponibles");
                Console.WriteLine("5. Salir");
            }
        }
    }
}