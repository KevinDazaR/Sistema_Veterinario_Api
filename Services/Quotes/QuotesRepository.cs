using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiltroJobs.Data;
using FiltroJobs.Models;
using FiltroJobs.DTO;
using Microsoft.EntityFrameworkCore;
using FiltroJobs.Services.Quotes;
using FiltroJobs.Services.Emails;

namespace FiltroJobs.Services.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly BaseContext _context;
        private readonly IEmailService _emailService;

        public QuotesRepository (BaseContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
      
        }
        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes.Include(p => p.Pets).Include(v => v.Vets).ToList();
        }

        public Quote GetById(int id)
        {
            return _context.Quotes.Include(x => x.Pets).Include(x => x.Vets).FirstOrDefault(x => x.Id == id);
        }

        public void Add(QuoteCreateDTO quoteDTO)
        {
            var quote = new Quote
            {
                Date = quoteDTO.Date,
                PetId = quoteDTO.PetId,
                VetId = quoteDTO.VetId,
                Description = quoteDTO.Description,
                State = quoteDTO.State
            };

            _context.Quotes.Add(quote);
            _context.SaveChanges();

            var pet = _context.Pets.Include(p => p.Owners).FirstOrDefault(p => p.Id == quoteDTO.PetId);
            var vet = _context.Vets.Find(quoteDTO.VetId);

            if (pet != null && vet != null && pet.Owners != null)
            {
                var subject = "Veterinaria Kevin Daza";
                var mensajePaciente = $"Hola, Sr@ {pet.Owners.Names},\n Recuerda que tienes una nueva cita programada para el {quoteDTO.Date}.";
            
                _emailService.SendEmail(pet.Owners.Email, subject, mensajePaciente);
            }
        }
    

        public void Update(int id, QuoteCreateDTO quoteDTO)
        {
              var existentQuote = _context.Quotes.Find(id);
            if (existentQuote != null)
            {
                existentQuote.Date = quoteDTO.Date;
                existentQuote.PetId = quoteDTO.PetId;
                existentQuote.VetId = quoteDTO.VetId;
                existentQuote.Description =quoteDTO.Description;
                existentQuote.Description =quoteDTO.State;
               

                _context.SaveChanges();
            }
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

          //adicional
        public IEnumerable<Quote> ObtenerCitasPorDia(DateTime fecha)
        {
            return _context.Quotes.Where(q =>  q.Date == fecha.Date)
                                 .Include(p => p.Pets)
                                 .ToList();
        }
    }
}
    