using ProyectoGym.Domain;
using ProyectoGym.Data;
using Microsoft.EntityFrameworkCore;

namespace ProyectoGym.Data
{
    public class EjercicioRepository
    {
        private readonly AppDbContext _context;

        public EjercicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Ejercicio ejercicio)
        {
            _context.Ejercicios.Add(ejercicio);
            _context.SaveChanges();
        }

        public void Update(Ejercicio ejercicio)
        {
            _context.Ejercicios.Update(ejercicio);
            _context.SaveChanges();
        }

        public void Delete(Ejercicio ejercicio)
        {
            _context.Ejercicios.Remove(ejercicio);
            _context.SaveChanges();
        }

        public Ejercicio? GetById(int id)
        {
            return _context.Ejercicios.FirstOrDefault(e => e.Id == id);
        }

        public List<Ejercicio> GetByRutinaId(int rutinaId)
        {
            return _context.Ejercicios
                           .Where(e => e.RutinaId == rutinaId)
                           .ToList();
        }
    }
}