// -------------------------------------------------------------
// Autor(es): Geovanny Alcon g4usSi, Henry HDZaid
// Fecha: 8/30/2024
// Descripción: Clase de utilidades para manejar funciones comunes 
//              como validación de entradas, manejo de errores, y 
//              operaciones sobre listas.
// -------------------------------------------------------------

public static class Utilidades
{
    public static void TituloMensaje(string contenidoTitulo) 
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\t\t\t "+contenidoTitulo);
        Console.ResetColor();
    }
    public static void ErrorMensaje(string contenidoTitulo)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\t\t[!] " + contenidoTitulo);
        Console.ResetColor();
    }
    public static void EsperaConfirmacion() 
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("---------------------------------------------------------------------------------------------------");
        Console.WriteLine("\t\t\t\tPresione 'Enter' para continuar...");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
    public static DateOnly ObtenerFecha()
    {
        while (true)
        {
            string fechaIngresada = Console.ReadLine();

            if (DateOnly.TryParseExact(fechaIngresada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly fecha))
            {
                return fecha;
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("[!] Formato de fecha no válido.");
                Console.Write("Inténtelo de nuevo: ");
                Console.ResetColor();
            }
        }
    }
    public static int LlenarNumeroEntero()
    {
        int numeroEntero = 0;
        bool valido = false;

        while (!valido)
        {
            try
            {
                numeroEntero = Convert.ToInt32(Console.ReadLine());

                if (numeroEntero > 0)
                {
                    valido = true;
                }
                else
                {
                    Console.Write("No puede ingresar números negativos o cero. \nIntente de nuevo: ");
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[!] Error: no puede ingresar letras. \nIntente de nuevo: ");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[!] Error desconocido: " + ex.Message);
                Console.Write("Intente de nuevo: ");
            }
            finally
            {
                Console.ResetColor();
            }
        }
        return numeroEntero;
    }
    public static string Enmascarado(bool estado) 
    {
        if (estado)
        {
            return "Disponible";
        }
        else
        {
            return "No disponible";
        }
    }
    public static string LlenarString()
    {
        string cadena = string.Empty;
        bool valido = false;
        while (!valido)
        {
            cadena = Console.ReadLine();
            if (!string.IsNullOrEmpty(cadena))
            {
                valido = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] No puede ingresar datos vacíos...");
                Console.Write("Intente de nuevo: ");
                Console.ResetColor();
            }
        }
        return cadena;
    }
    public static DateOnly LlenarFecha()
    {
        DateOnly fecha = default;
        bool valido = false;

        while (!valido)
        {
            try
            {
                Console.Write("Ingrese la fecha (formato: dd/MM/yyyy): ");
                string input = Console.ReadLine();

                fecha = DateOnly.ParseExact(input, "dd/MM/yyyy", null);

                valido = true;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Error: formato de fecha inválido.");
                Console.Write("Intente de nuevo: ");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[!] Error desconocido: " + ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }

        return fecha;
    }
    public static double LlenarNumeroDouble()
    {
        double numeroDouble = 0;
        bool valido = false;
        while (!valido)
        {
            try
            {
                numeroDouble = Convert.ToDouble(Console.ReadLine());
                valido = true;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Error no puede ingresar letras...");
                Console.Write("> Intente de nuevo: ");
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[!] Error desconocido... ");
                Console.Write("> Intente de nuevo: ");
            }
            finally
            {
                Console.ResetColor();
            }
        }
        return numeroDouble;
    }
    public static bool TerminarEjecucion() 
    {
        bool salir = false;
        Console.Write("Seguro desea salir? (si/no): ");
        string terminarEjecucion = Console.ReadLine().ToLower();
        if (terminarEjecucion == "si" || terminarEjecucion == "s")
        {
            Console.Clear();
            Console.WriteLine("\t\t\tFELIZ DIA");
            return salir = true;
        }
        else 
        {
            Console.Clear();
            Console.WriteLine("  > > > Regresando al menu...");
            return false;
        }
    }
    //Pa mi en el futuro UwU
    //recibe un lambda
    public static T BuscarObjetoLista<T>(List<T> listaObjetos, Predicate<T> criterio)
    {
        T objetoBuscar = listaObjetos.Find(criterio);
        if (objetoBuscar != null)
        {
            return objetoBuscar;
        }
        else
        {
            Console.WriteLine("[!] Objeto no encontrado.");
            return default(T);
        }
    }
}