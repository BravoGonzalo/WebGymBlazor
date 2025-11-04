using ProyectoGym.Data;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Business
{
    public class EntrenadorService
    {
        private readonly EntrenadorRepository _repo;

        public EntrenadorService(EntrenadorRepository repo)
        {
            _repo = repo;
        }

        public void CrearEntrenador(Entrenador entrenador)
        {
            if (entrenador == null)
                throw new ArgumentNullException(nameof(entrenador));

            if (string.IsNullOrWhiteSpace(entrenador.nombre))
                throw new Exception("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(entrenador.email))
                throw new Exception("El email es obligatorio");

            if (string.IsNullOrWhiteSpace(entrenador.dni))
                throw new Exception("El DNI es obligatorio");

            _repo.Add(entrenador);
        }

        public void ModificarEntrenador(Entrenador entrenador)
        {
            var existente = _repo.GetById(entrenador.Id);
            if (existente == null)
                throw new Exception("Entrenador no existe");

            existente.nombre = entrenador.nombre;
            existente.apellido = entrenador.apellido;
            existente.dni = entrenador.dni;
            existente.direccion = entrenador.direccion;
            existente.telefono = entrenador.telefono;
            existente.email = entrenador.email;
            existente.genero = entrenador.genero;

            _repo.Update(existente);
        }

        public void EliminarEntrenador(int id)
        {
            var entrenador = _repo.GetById(id);
            if (entrenador == null)
                throw new Exception("Entrenador no existe");

            _repo.Delete(entrenador);
        }

        public List<Entrenador> TraerTodos()
        {
            return _repo.GetAll();
        }

        public Entrenador TraerPorId(int id)
        {
            return _repo.GetById(id);
        }

        public Entrenador? GetByEmailAndDni(string email, string dni)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(dni))
                return null;
            return _repo.FindByEmailAndDni(email, dni);
        }
    }
}

