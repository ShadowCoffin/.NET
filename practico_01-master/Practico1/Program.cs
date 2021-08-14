using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mi Primera app C#");

            string nombre = "";
            string documento = "";
            string fnacimiento = "";
            string exit = "N";
            List<Persona> lista = new List<Persona>();

            while (exit == "N")
            {
                Console.WriteLine("Nombre:");
                nombre = Console.ReadLine();
                Console.WriteLine("Documento:");
                documento = Console.ReadLine();
                Console.WriteLine("Fecha Nacimiento (dd-mm-aaaa):");
                fnacimiento = Console.ReadLine();

                DateTime nacimiento = DateTime.ParseExact(fnacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Persona p = new Persona(nombre, documento, nacimiento);
                lista.Add(p);
                Console.WriteLine("Exit (Y/N):");
                exit = Console.ReadLine();
            }

            // Ordenamos la lista.
            lista = lista.OrderByDescending(x => x.GetEdad()).ToList();

            // Mapeamos a una lista de string.
            List<string> prueba = lista.Select(x => "Nombre: " + x.Nombre + ", Documento: " +
                    x.Documento + ", F. Nacimiento: " + x.FechaNacimiento.ToString("dd-MM-yyyy") +
                    ", Edad: " + x.GetEdad()).ToList();

            // Imprimimos
            prueba.ForEach(x =>
            {
                Console.WriteLine(x);
            });

            // Prueba Where
            lista = lista.Where(x => x.Nombre == "pepe" && x.GetEdad() > 50).ToList();
            Console.WriteLine();
            prueba.ForEach(x =>
            {
                Console.WriteLine(x);
            });

            Console.ReadLine();
        }
    }
}
