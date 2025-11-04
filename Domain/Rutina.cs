using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class Rutina
    {
        public int Id { get; set; }
        public String nombre { get; set; }
        public List<Ejercicio> ejercicios { get; set; }
        public Rutina(int Id, String nombre, List<Ejercicio> ejercicios)
        {
            this.Id = Id;
            this.nombre = nombre;
            this.ejercicios = ejercicios;
        }
        public Rutina()
        {

        }
    }
}
