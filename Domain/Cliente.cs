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
        public string contraseña { get; set; }
        public List<Rutina> Rutinas { get; set; } = new List<Rutina>();
        public int IdEntrenador { get; set; }
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        public Cliente(string contraseña, string nombre, string apellido, string dni, string direccion, string telefono, string email, Sexo genero, List<Rutina> rutinaxdia, List<Pago> Pagos) 
            : base(nombre, apellido, dni, direccion, telefono, email, genero)
        {
            this.Rutinas = rutinaxdia;
            this.contraseña = contraseña;
        }
        [NotMapped]
        public bool EstaAlDia
        {
            get
            {
                return Pagos.Any(p => p.FechaDePago > DateTime.Now.AddDays(-30));
            }
        }
        public Cliente()
        {

        }
    }
}
