using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona(string nombre, string documento, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Documento = documento;
            FechaNacimiento = fechaNacimiento;
        }

        public int GetEdad()
        {
            return (DateTime.Now - FechaNacimiento).Days / 365;
        }
    }
}
