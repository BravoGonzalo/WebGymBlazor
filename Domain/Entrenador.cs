using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class Entrenador : Persona
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string contraseña { get; set; }
        public Entrenador(string contraseña, string nombre, string apellido, string dni, string direccion, string telefono, string email, Sexo genero) 
            : base(nombre, apellido, dni, direccion, telefono, email, genero)
        {
            this.contraseña = contraseña;
        }
        public Entrenador()
        {

        }
    }
}
 