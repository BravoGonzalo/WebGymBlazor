using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class EnumEjercicio
    {
        public enum DiaDeLaSemana
        {
            Lunes,
            Martes,
            Miercoles,
            Jueves,
            Viernes,
            Sabado,
            Domingo
        }

        public enum NombreEjercicio
        {
            PressBanca,
            Sentadillas,
            PesoMuerto,
            Dominadas,
            RemoConBarra,
            PressMilitar,
            CurlBiceps,
            ExtensionTriceps,
            Abdominales,
            ElevacionesLaterales
        }
    }
}
