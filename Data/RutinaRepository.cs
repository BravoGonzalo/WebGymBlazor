using Microsoft.EntityFrameworkCore;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Data
{
    public class RutinaRepository
    {
        private readonly AppDbContext _context;

        public RutinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Rutina rutina)
        {
            _context.Rutinas.Add(rutina);
            _context.SaveChanges();
        }

        public void Update(Rutina rutina)
        {
            _context.Rutinas.Update(rutina);
            _context.SaveChanges();
        }

        public void Delete(Rutina rutina)
        {
            _context.Rutinas.Remove(rutina);
            _context.SaveChanges();
        }

        public Rutina GetById(int id)
        {
            return _context.Rutinas
                .Include(r => r.ejercicios)
                .FirstOrDefault(r => r.Id == id);
        }

        public List<Rutina> GetAll()
        {
            return _context.Rutinas
                .Include(r => r.ejercicios)
                .ToList();
        }
    }
}
