using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class Cliente : Persona
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool pago { get; set; }
        public string contraseña { get; set; }
        public List<Rutina> Rutinas { get; set; } = new List<Rutina>();
        public int IdEntrenador { get; set; }
        public Cliente(string contraseña, string nombre, string apellido, string dni, string direccion, string telefono, string email, Sexo genero, bool pago, List<Rutina> rutinaxdia) 
            : base(nombre, apellido, dni, direccion, telefono, email, genero)
        {
            this.pago = pago;
            this.Rutinas = rutinaxdia;
            this.contraseña = contraseña;
        }
        public Cliente()
        {

        }
    }
}
