using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.DTO;
using FiltroJobs.Models;

namespace FiltroJobs.Services.Quotes
{
    public interface IQuotesRepository
    {
         IEnumerable<Quote> GetAll();
         Quote GetById(int id);
         void Add(QuoteCreateDTO quoteDTO);
         void Update(int id, QuoteCreateDTO quoteDTO);
         void Delete(int id);

           //endpoints Medios
        IEnumerable<Quote> ObtenerCitasPorDia( DateTime fecha);
    }
}