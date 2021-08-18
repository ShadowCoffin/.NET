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

            string option = "";
            List<Persona> lista = new List<Persona>();
            do
            {
                Menu();
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        lista = lista.Concat<Persona>(AgregarPersonas()).ToList();
                        break;
                    case "2":
                        ListarPersonas(lista, "", "");
                        break;
                    case "3":
                        Console.WriteLine("Filtrar por:");
                        Console.WriteLine("1- Nombre");
                        Console.WriteLine("2- CI");
                        string filtro = Console.ReadLine();
                        if (filtro == "1")
                        {
                            Console.WriteLine("Ingrese nombre a filtrar");
                            ListarPersonas(lista, Console.ReadLine(), "");
                        }
                        if (filtro == "2")
                        {
                            Console.WriteLine("Ingrese CI a filtrar");
                            ListarPersonas(lista, "", Console.ReadLine());
                        }
                        break;
                    case "4": break;
                    case null: break;

                }
                Console.Clear();

            } while (option != "4");

        }

        private static void ListarPersonas(List<Persona>lista, string filtroNom, string filtroCI)
        {
            if (filtroNom != "")
            {
                lista = lista.Where(x => x.Nombre.StartsWith(filtroNom)).ToList();
            }
            if (filtroCI != "")
            {
                lista = lista.Where(x => x.Documento.StartsWith(filtroCI)).ToList();
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
            Console.ReadLine();
        }

        private static List<Persona> AgregarPersonas()
        {
            string nombre = "";
            string documento = "";
            string fnacimiento = "";
            string exit = "";
            List<Persona> lista = new List<Persona>();
            do
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
            } while (exit != "y");
            return lista;

        }

        private static void Menu()
        {
            Console.WriteLine("Bienvenido");
            Console.WriteLine("1- Agregar Personas");
            Console.WriteLine("2- Listar Personas");
            Console.WriteLine("3- Filtrar Personas");
            Console.WriteLine("4- Salir");
        }
            
    }
}
