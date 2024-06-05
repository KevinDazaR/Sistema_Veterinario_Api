using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Models;

namespace FiltroJobs.Services.Pets
{
    public interface IPetsRepository
    {
         IEnumerable<Pet> GetAll();
         Pet GetById(int id);
         void Add(Pet pet);
         void Update(Pet pet);
         void Delete(int id);
    }
}