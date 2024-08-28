public static class Utilidades
{
    public static int LlenarNumeroEntero()
    {
        int numeroEntero = 0;
        bool valido = false;

        while (!valido)
        {
            try
            {
                Console.Write("> Ingrese un número entero positivo: ");
                numeroEntero = Convert.ToInt32(Console.ReadLine());

                if (numeroEntero > 0)
                {
                    valido = true;
                }
                else
                {
                    Console.WriteLine("No puede ingresar números negativos o cero. Intente de nuevo:");
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Error: no puede ingresar letras. Intente de nuevo:");
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

        return numeroEntero;
    }
    public static bool ObtenerBooleanoNatural(int numero)
    {
        return numero > 0;
    }
    public static string Enmascarado(bool estado) {
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
                Console.WriteLine("[!] No puede ingresar datos vacíos...");
                Console.Write("Intente de nuevo: ");
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
                Console.WriteLine("[!] Error: formato de fecha inválido. Intente de nuevo.");
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