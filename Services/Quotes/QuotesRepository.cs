using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Data;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;
using FiltroJobs.Services.Quotes;

namespace FiltroJobs.Services.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly BaseContext _context;

        public QuotesRepository(BaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes.ToList();
        }

        public Quote GetById(int id)
        {
            return _context.Quotes.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public void Update(Quote quote)
        {
            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var quote = _context.Quotes.Find(id);
            if(quote != null)
            {
                //cambiar el estado a inactivo
                quote.State = "inactive";
                _context.Quotes.Update(quote);
                _context.SaveChanges();
            }
        }
    }
}
    