using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Data;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;
using FiltroJobs.Services.Vets;

namespace FiltroJobs.Services.Vets
{
    public class VetsRepository : IVetsRepository
    {
        private readonly BaseContext _context;

        public VetsRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Vet> GetAll()
        {
            return _context.Vets.ToList();
        }

        public Vet GetById(int id)
        {
            return _context.Vets.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Vet vet)
        {
            _context.Vets.Add(vet);
            _context.SaveChanges();
        }

        public void Update(Vet vet)
        {
            _context.Vets.Update(vet);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var vet = _context.Vets.Find(id);
            if(vet != null)
            {
                //cambiar el estado a inactivo
                vet.State = "inactive";
                _context.Vets.Update(vet);
                _context.SaveChanges();
            }
        }
    }
}
    