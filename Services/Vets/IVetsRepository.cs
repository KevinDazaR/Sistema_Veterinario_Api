using System.Collections.Generic;
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
