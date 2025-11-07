using Microsoft.EntityFrameworkCore;
using ProyectoGym.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGym.Data
{
    public class EntrenadorRepository
    {
        private readonly AppDbContext _context;

        public EntrenadorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Entrenador? FindByEmail(string email)
        {
            return _context.Entrenadores.FirstOrDefault(e => e.email == email);
        }

        // Agregar entrenador
        public void Add(Entrenador entrenador)
        {
            _context.Entrenadores.Add(entrenador);
            _context.SaveChanges();
        }

        // Modificar entrenador
        public void Update(Entrenador entrenador)
        {
            _context.Entrenadores.Update(entrenador);
            _context.SaveChanges();
        }

        // Eliminar entrenador
        public void Delete(Entrenador entrenador)
        {
            _context.Entrenadores.Remove(entrenador);
            _context.SaveChanges();
        }

        // Traer entrenador por Id
        public Entrenador GetById(int id)
        {
            return _context.Entrenadores.FirstOrDefault(e => e.Id == id);
        }

        // Traer todos los entrenadores
        public List<Entrenador> GetAll()
        {
            return _context.Entrenadores.ToList();
        }
        public Entrenador? FindByDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                return null;

            return _context.Entrenadores.FirstOrDefault(e => e.dni == dni);
        }
    }
}
