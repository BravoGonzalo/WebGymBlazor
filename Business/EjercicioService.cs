using ProyectoGym.Data;
using ProyectoGym.Domain;

namespace ProyectoGym.Business
{
    public class EjercicioService
    {
        private readonly EjercicioRepository _repo;

        public EjercicioService(EjercicioRepository repo)
        {
            _repo = repo;
        }

        public void CrearEjercicio(Ejercicio ejercicio)
        {
            if (ejercicio == null)
                throw new ArgumentNullException("El ejercicio no puede ser nulo.");
            if (ejercicio.RutinaId <= 0)
                throw new Exception("El ejercicio debe estar asignado a una rutina.");
            if (ejercicio.series <= 0 || ejercicio.repeticiones <= 0)
                throw new Exception("Las series y repeticiones deben ser mayores a cero.");

            _repo.Add(ejercicio);
        }

        public void ModificarEjercicio(Ejercicio ejercicio)
        {
            var existente = _repo.GetById(ejercicio.Id);
            if (existente == null)
                throw new Exception("Ejercicio no encontrado.");

            existente.nombreEJ = ejercicio.nombreEJ;
            existente.series = ejercicio.series;
            existente.repeticiones = ejercicio.repeticiones;

            _repo.Update(existente);
        }

        public void EliminarEjercicio(int id)
        {
            var ejercicio = _repo.GetById(id);
            if (ejercicio == null)
                throw new Exception("Ejercicio no encontrado.");

            _repo.Delete(ejercicio);
        }

        public Ejercicio? TraerPorId(int id)
        {
            return _repo.GetById(id);
        }
    }
}
