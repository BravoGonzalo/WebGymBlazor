using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoGym.Domain
{
    public enum Sexo
    {
        Masculino,
        Femenino,
        Indefinido
    }

    public class Persona
    {
        public string nombre { get; set; } = "";
        public string apellido { get; set; } = "";
        public string dni { get; set; } = "";
        public string direccion { get; set; } = "";
        public string telefono { get; set; } = "";
        public string email { get; set; } = "";
        public Sexo genero { get; set; } = Sexo.Indefinido;

        public Persona() { }

        public Persona(string nombre, string apellido, string dni, string direccion, string telefono, string email, Sexo genero)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.direccion = direccion;
            this.telefono = telefono;
            this.email = email;
            this.genero = genero;
        }
    }
}
