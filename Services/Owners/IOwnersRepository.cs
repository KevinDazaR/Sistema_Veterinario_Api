using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Models;

namespace FiltroJobs.Services.Owners
{
    public interface IOwnersRepository
    {
         IEnumerable<Owner> GetAll();
         Owner GetById(int id);
         void Add(Owner pet);
         void Update(Owner pet);
         void Delete(int id);
    }
}