using Microsoft.EntityFrameworkCore;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Data
{
    public class ClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }
        public Cliente? FindByEmail(string email)
        {
            return _context.Clientes.FirstOrDefault(c => c.email == email);
        }

        // Agregar un cliente
        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        // Modificar un cliente
        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        // Eliminar un cliente
        public void Delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        // Traer un cliente por Id
        public Cliente? GetById(int id)
        {
            return _context.Clientes
                           .Include(c => c.Rutinas)
                               .ThenInclude(r => r.Ejercicios)
                           .Include(c => c.Pagos)
                           .FirstOrDefault(c => c.Id == id);
        }

        public List<Cliente> FindByEntrenadorId(int entrenadorId)
        {
            return _context.Clientes
                           .Include(c => c.Pagos)
                           .Where(c => c.IdEntrenador == entrenadorId)
                           .ToList();
        }
        public Cliente? FindByDni(string dni)
        {
            return _context.Clientes
                           .Include(c => c.Rutinas)
                               .ThenInclude(r => r.Ejercicios)
                           .Include(c => c.Pagos) 
                           .FirstOrDefault(c => c.dni == dni);
        }
    }
}
