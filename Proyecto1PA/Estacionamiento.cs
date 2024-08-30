using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1PA
{
    public class Estacionamiento
    {
        public Vehiculo Vehiculo { get; set; }
        public DateTime Hora { get; set; }
        public int Pago { get; set; }
        public Estacionamiento(Vehiculo vehiculo, DateTime date, int pago)
        {
            this.Vehiculo = vehiculo;
            this.Hora = date;
            Pago = pago;
        }
        public void AsignarEspacio(List<Estacionamiento> listaEstacionamiento, int tamañoEstacionamiento) 
        {
            if (ComprobarEspacios(listaEstacionamiento, tamañoEstacionamiento))
            {
                
            }
            else
            {
                Console.WriteLine("Estacionamiento completamente lleno...");
            }
        }
        public bool ComprobarEspacios(List<Estacionamiento> listaEspacios, int tamañoEstacionamiento) 
        {
            if (listaEspacios.Count <= tamañoEstacionamiento)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
