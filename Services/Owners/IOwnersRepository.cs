using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Models;
using FiltroJobs.DTO;

namespace FiltroJobs.Services.Owners
{
    public interface IOwnersRepository
    {
         IEnumerable<Owner> GetAll();
         Owner GetById(int id);
         void Add(OwnerCreateDTO ownerDTO);
         void Update(int id, OwnerCreateDTO ownerDTO);
         void Delete(int id);
    }
}