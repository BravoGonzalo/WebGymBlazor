using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Data
{
    public class EjercicioRepository
    {
        private readonly AppDbContext _context;

        public EjercicioRepository(AppDbContext context)
        {
            _context = context;
        }


        // Agregar ejercicio
        public void Add(Ejercicio ejercicio)
        {
            _context.Add(ejercicio);
            _context.SaveChanges();
        }

        // Modificar ejercicio
        public void Update(Ejercicio ejercicio)
        {
            _context.Update(ejercicio);
            _context.SaveChanges();
        }

        // Eliminar ejercicio
        public void Delete(Ejercicio ejercicio)
        {
            _context.Remove(ejercicio);
            _context.SaveChanges();
        }

        // Traer ejercicio por Id
        public Ejercicio GetById(int id)
        {
            return _context.Set<Ejercicio>().Find(id);
        }

        // Traer todos los ejercicios
        public List<Ejercicio> GetAll()
        {
            return _context.Set<Ejercicio>().ToList();
        }
    }
}
