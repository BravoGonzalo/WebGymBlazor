using ProyectoGym.Data;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Business
{
    public class ClienteService
    {
        private readonly ClienteRepository _repo;

        public ClienteService(ClienteRepository repo)
        {
            _repo = repo;
        }

        public void CrearCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException("El cliente no puede ser nulo");

            if (string.IsNullOrEmpty(cliente.nombre))
                throw new Exception("El nombre es obligatorio");

            if (cliente.Rutinas == null)
                cliente.Rutinas= new List<Rutina>();

            if (string.IsNullOrWhiteSpace(cliente.contraseña))
                throw new Exception("La contraseña es obligatoria");
            cliente.contraseña = ContraseñaHasher.HashPassword(cliente.contraseña);

            _repo.Add(cliente);
        }

        public void ModificarCliente(Cliente cliente)
        {
            var existente = _repo.GetById(cliente.Id);
            if (existente == null)
                throw new Exception("Cliente no existe");

            existente.nombre = cliente.nombre;
            existente.apellido = cliente.apellido;
            existente.dni = cliente.dni;
            existente.direccion = cliente.direccion;
            existente.telefono = cliente.telefono;
            existente.email = cliente.email;
            existente.genero = cliente.genero;

            _repo.Update(existente);
        }

        public void EliminarCliente(int id)
        {
            var cliente = _repo.GetById(id);
            if (cliente == null)
                throw new Exception("Cliente no existe");

            _repo.Delete(cliente);
        }

        public Cliente? GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;
            return _repo.FindByEmail(email);
        }

        public Cliente GetById(int id)
        {
            return _repo.GetById(id);
        }
        public List<Cliente> GetByEntrenadorId(int entrenadorId)
        {
            return _repo.FindByEntrenadorId(entrenadorId);
        }
        public Cliente? GetByDni(string dni)
        {
            return _repo.FindByDni(dni);
        }
    }
}

