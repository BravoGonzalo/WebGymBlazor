using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public int series { get; set; }
        public int repeticiones { get; set; }
        public EnumEjercicio.nombreEjercicio nombreEJ { get; set; }

        public Ejercicio(int Id, int series, int repeticiones, EnumEjercicio.nombreEjercicio nombreEJ)
        {
            this.Id = Id;
            this.series = series;
            this.repeticiones = repeticiones;
            this.nombreEJ = nombreEJ;
        }
        public Ejercicio()
        {

        }
    }
}
