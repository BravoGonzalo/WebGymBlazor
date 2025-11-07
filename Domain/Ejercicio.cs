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
    public class Ejercicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public NombreEjercicio nombreEJ { get; set; } 
        public int series { get; set; }
        public int repeticiones { get; set; }

        public int RutinaId { get; set; }
        public Rutina Rutina { get; set; }

        public Ejercicio(NombreEjercicio nombreEJ, int series, int repeticiones)
        {
            this.nombreEJ = nombreEJ;
            this.series = series;
            this.repeticiones = repeticiones;
        }

        public Ejercicio() { }
    }
}
