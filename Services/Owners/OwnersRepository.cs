using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Data;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;
using FiltroJobs.Services.Owners;
using FiltroJobs.DTO;

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
            return _context.Owners.Include(p => p.Pets).ToList();
        }

        public Owner GetById(int id)
        {
            return _context.Owners.Include(p => p.Pets).FirstOrDefault(p => p.Id == id);
        }

        public void Add(OwnerCreateDTO createDTO)
        {
            var owner = new Owner
            {
                Names = createDTO.Names,
                LastNames = createDTO.LastNames,
                Phone = createDTO.Phone,
                Address =createDTO.Address,
                Email=createDTO.Email,
                State=createDTO.State
            };
            
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        public void Update(int id, OwnerCreateDTO owner)
        {
            var existentOwner = _context.Owners.Find(id);

            if (existentOwner != null)
            {
                existentOwner.Names = owner.Names;
                existentOwner.LastNames = owner.LastNames;
                existentOwner.Phone = owner.Phone;
                existentOwner.Address =owner.Address;
                existentOwner.Email=owner.Email;
                

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var owner = _context.Owners.Find(id);
            if(owner != null)
            {
                //cambiar el estado a inactivo
                owner.State = "inactive";
                _context.Owners.Update(owner);
                _context.SaveChanges();
            }
        }
    }
}
    