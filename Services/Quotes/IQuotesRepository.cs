using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Models;

namespace FiltroJobs.Services.Quotes
{
    public interface IQuotesRepository
    {
         IEnumerable<Quote> GetAll();
         Quote GetById(int id);
         void Add(Quote quote);
         void Update(Quote quote);
         void Delete(int id);
    }
}