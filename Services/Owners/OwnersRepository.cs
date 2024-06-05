using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Data;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;
using FiltroJobs.Services.Owners;

namespace FiltroJobs.Services.Owners
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly BaseContext _context;

        public OwnersRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll()
        {
            return _context.Owners.ToList();
        }

        public Owner GetById(int id)
        {
            return _context.Owners.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Owner pet)
        {
            _context.Owners.Add(pet);
            _context.SaveChanges();
        }

        public void Update(Owner pet)
        {
            _context.Owners.Update(pet);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var pet = _context.Owners.Find(id);
            if(pet != null)
            {
                //cambiar el estado a inactivo
                pet.State = "inactive";
                _context.Owners.Update(pet);
                _context.SaveChanges();
            }
        }
    }
}
    