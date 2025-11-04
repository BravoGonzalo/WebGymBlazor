using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Domain
{
    public class EnumEjercicio
    {
        public nombreEjercicio nombreEJ { get; set; }
        public enum nombreEjercicio
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
