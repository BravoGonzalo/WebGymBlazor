using ProyectoGym.Data;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Business
{
    public class RutinaService
    {
        private readonly RutinaRepository _repo;

        public RutinaService(RutinaRepository repo)
        {
            _repo = repo;
        }

        // Crear rutina
        public void CrearRutina(Rutina rutina)
        {
            if (rutina == null)
                throw new ArgumentNullException("La rutina no puede ser nula");

            if (string.IsNullOrEmpty(rutina.nombre))
                throw new Exception("El nombre de la rutina es obligatorio");

            if (rutina.ejercicios == null)
                rutina.ejercicios = new List<Ejercicio>();

            _repo.Add(rutina);
        }

        // Modificar rutina
        public void ModificarRutina(Rutina rutina)
        {
            var existente = _repo.GetById(rutina.Id);
            if (existente == null)
                throw new Exception("Rutina no existe");

            existente.nombre = rutina.nombre;
            existente.ejercicios = rutina.ejercicios;

            _repo.Update(existente);
        }

        // Eliminar rutina
        public void EliminarRutina(int id)
        {
            var rutina = _repo.GetById(id);
            if (rutina == null)
                throw new Exception("Rutina no existe");

            _repo.Delete(rutina);
        }

        // Traer todas las rutinas
        public List<Rutina> TraerTodas()
        {
            return _repo.GetAll();
        }

        // Traer rutina por Id
        public Rutina TraerPorId(int id)
        {
            return _repo.GetById(id);
        }
    }
}
