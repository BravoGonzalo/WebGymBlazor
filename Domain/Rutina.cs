using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoGym.Domain.EnumEjercicio;

namespace ProyectoGym.Domain
{
    public class Rutina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; } 

        public DiaDeLaSemana Dia { get; set; }

        public List<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();

        public int ClienteId { get; set; } 
        public Cliente Cliente { get; set; }

        public Rutina(string nombre, DiaDeLaSemana dia, int clienteId)
        {
            Nombre = nombre;
            Dia = dia;
            ClienteId = clienteId;
        }

        public Rutina() { }
    }
}
