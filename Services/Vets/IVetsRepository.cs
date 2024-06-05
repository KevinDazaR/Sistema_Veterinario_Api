using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Models;

namespace FiltroJobs.Services.Vets
{
    public interface IVetsRepository
    {
         IEnumerable<Vet> GetAll();
         Vet GetById(int id);
         void Add(Vet vet);
         void Update(Vet vet);
         void Delete(int id);
    }
}