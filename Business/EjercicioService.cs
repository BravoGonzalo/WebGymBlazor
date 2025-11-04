using ProyectoGym.Data;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Business
{
    public class EjercicioService
    {
        private readonly EjercicioRepository _repo;

        public EjercicioService(EjercicioRepository repo)
        {
            _repo = repo;
        }

        // Crear ejercicio
        public void CrearEjercicio(Ejercicio ejercicio)
        {
            if (ejercicio == null)
                throw new ArgumentNullException("El ejercicio no puede ser nulo");

            if (ejercicio.series <= 0 || ejercicio.repeticiones <= 0)
                throw new Exception("Series y repeticiones deben ser mayores a 0");

            _repo.Add(ejercicio);
        }

        // Modificar ejercicio
        public void ModificarEjercicio(Ejercicio ejercicio)
        {
            var existente = _repo.GetById(ejercicio.Id);
            if (existente == null)
                throw new Exception("Ejercicio no existe");

            existente.series = ejercicio.series;
            existente.repeticiones = ejercicio.repeticiones;
            existente.nombreEJ = ejercicio.nombreEJ;

            _repo.Update(existente);
        }

        // Eliminar ejercicio
        public void EliminarEjercicio(int id)
        {
            var ejercicio = _repo.GetById(id);
            if (ejercicio == null)
                throw new Exception("Ejercicio no existe");

            _repo.Delete(ejercicio);
        }

        // Traer todos los ejercicios
        public List<Ejercicio> TraerTodos()
        {
            return _repo.GetAll();
        }

        // Traer ejercicio por Id
        public Ejercicio TraerPorId(int id)
        {
            return _repo.GetById(id);
        }
    }
}
