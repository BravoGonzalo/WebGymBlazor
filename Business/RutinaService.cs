using ProyectoGym.Data;
using ProyectoGym.Domain;

namespace ProyectoGym.Business
{
    public class RutinaService
    {
        private readonly RutinaRepository _repo;

        public RutinaService(RutinaRepository repo)
        {
            _repo = repo;
        }

        public void CrearRutina(Rutina rutina)
        {
            if (rutina == null)
                throw new ArgumentNullException("La rutina no puede ser nula");

            if (string.IsNullOrEmpty(rutina.Nombre))
                throw new Exception("El nombre de la rutina es obligatorio");

            if (rutina.ClienteId <= 0)
                throw new Exception("La rutina debe estar asignada a un cliente.");

            if (rutina.Ejercicios == null)
                rutina.Ejercicios = new List<Ejercicio>();

            _repo.Add(rutina);
        }

        public void ModificarRutina(Rutina rutina)
        {
            var existente = _repo.GetById(rutina.Id);
            if (existente == null)
                throw new Exception("Rutina no existe");

            existente.Nombre = rutina.Nombre;
            existente.Dia = rutina.Dia;

            _repo.Update(existente);
        }

        public void EliminarRutina(int id)
        {
            var rutina = _repo.GetById(id);
            if (rutina == null)
                throw new Exception("Rutina no existe");

            _repo.Delete(rutina);
        }

        public List<Rutina> TraerTodas()
        {
            return _repo.GetAll();
        }

        public Rutina TraerPorId(int id)
        {
            return _repo.GetById(id);
        }
    }
}