using ProyectoGym.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoGym.Data
{
    public class PagoRepository
    {
        private readonly AppDbContext _context;

        public PagoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Pago pago)
        {
            _context.Pagos.Add(pago);
            _context.SaveChanges();
        }

        public void Delete(Pago pago)
        {
            _context.Pagos.Remove(pago);
            _context.SaveChanges();
        }

        public List<Pago> GetByClienteId(int clienteId)
        {
            return _context.Pagos
                           .Where(p => p.ClienteId == clienteId)
                           .OrderByDescending(p => p.FechaDePago)
                           .ToList();
        }
        public Pago? GetById(int id)
        {
            return _context.Pagos.FirstOrDefault(p => p.Id == id);
        }
    }
}