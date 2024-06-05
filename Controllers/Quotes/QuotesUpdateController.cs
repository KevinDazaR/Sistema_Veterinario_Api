using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Quotes;
using FiltroJobs.Models;
using FiltroJobs.DTO;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesUpdateController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;

        public QuotesUpdateController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuote(int id, QuoteCreateDTO quoteDTO)
        {
            // if (id != quote.Id)
            // {
            //     return BadRequest(new { message = "el Id de la Quote no coincide " });
            // }

            try
            {
                _quotesRepository.Update(id, quoteDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_quotesRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Quote no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateQuote), new {quoteDTO}, "Quote actualizada con exito");
        }

    }
}
