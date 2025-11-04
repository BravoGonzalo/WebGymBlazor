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

            if (cliente.rutinaxdia == null)
                cliente.rutinaxdia = new List<Rutina>();

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
            existente.pago = cliente.pago;
            existente.rutinaxdia = cliente.rutinaxdia;

            _repo.Update(existente);
        }

        public void EliminarCliente(int id)
        {
            var cliente = _repo.GetById(id);
            if (cliente == null)
                throw new Exception("Cliente no existe");

            _repo.Delete(cliente);
        }

        public List<Cliente> TraerTodos()
        {
            return _repo.GetAll();
        }

        public Cliente TraerPorId(int id)
        {
            return _repo.GetById(id);
        }
    }
}

