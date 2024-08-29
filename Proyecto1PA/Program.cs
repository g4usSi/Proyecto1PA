﻿using Proyecto1PA;

List<Vehiculos> listaVehiculos = new List<Vehiculos>();

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
            //imprimir los vehiculos
            Utilidades.Titulo("// REGISTRAR VEHICULO //");

            break;
        case 2:
            Console.Clear();
            //imprimir los vehiculos
            Utilidades.Titulo("// RETIRAR VEHICULO //");

            break;
        case 3:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Utilidades.Titulo("// MOSTRAR VEHICULOS ESTACIONADOS //");
            Console.ResetColor();

            break;
        case 4:
            Console.Clear();
            Utilidades.Titulo("// MOSTRAR ESPACIOS DISPONIBLES //");

            break;
        case 5:
            Console.Clear();
            Console.WriteLine("// SALIR//");
            salir = Utilidades.TerminarEjecucion();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Opcion Incorrecta...\nRegresando al menu...\n");
        break;
    }
} while (!salir);

static void Menu()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\t\t\tPARQUEO XYZ");
    Console.WriteLine("\t\t##### Menu Principal #####");
    Console.ResetColor();
    Console.WriteLine("\n1. Registrar vehiculo");
    Console.WriteLine("2. Retirar vehiculo");
    Console.WriteLine("3. Mostrar vehiculos estacionados");
    Console.WriteLine("4. Mostrar espacios disponibles");
    Console.WriteLine("5. Salir");
}