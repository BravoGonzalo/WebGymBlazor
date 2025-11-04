using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class Entrenador : Persona
    {
        public int Id { get; set; }
        public Entrenador(int Id, string nombre, string apellido, string dni, string direccion, string telefono, string email, Sexo genero) 
            : base(nombre, apellido, dni, direccion, telefono, email, genero)
        {
            this.Id = Id;
        }
        public Entrenador()
        {

        }
    }
}
