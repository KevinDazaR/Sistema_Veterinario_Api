using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Data;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;
using FiltroJobs.Services.Pets;

namespace FiltroJobs.Services.Pets
{
    public class PetsRepository : IPetsRepository
    {
        private readonly BaseContext _context;

        public PetsRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> GetAll()
        {
            return _context.Pets.ToList();
        }

        public Pet GetById(int id)
        {
            return _context.Pets.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Pet pet)
        {
            _context.Pets.Add(pet);
            _context.SaveChanges();
        }

        public void Update(Pet pet)
        {
            _context.Pets.Update(pet);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var pet = _context.Pets.Find(id);
            if(pet != null)
            {
                //cambiar el estado a inactivo
                pet.State = "inactive";
                _context.Pets.Update(pet);
                _context.SaveChanges();
            }
        }
    }
}