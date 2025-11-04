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
        public Cliente GetById(int id)
        {
            return _context.Clientes
                .Include(c => c.rutinaxdia) // Incluimos las rutinas
                .FirstOrDefault(c => c.Id == id);
        }

        // Traer todos los clientes
        public List<Cliente> GetAll()
        {
            return _context.Clientes
                .Include(c => c.rutinaxdia) // Incluimos las rutinas
                .ToList();
        }
    }
}
