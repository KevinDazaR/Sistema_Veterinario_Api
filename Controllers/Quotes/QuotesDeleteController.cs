using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Quotes;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesDeleteController : ControllerBase
    {
         private readonly IQuotesRepository _quotesRepository;

        public QuotesDeleteController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            var quote = _quotesRepository.GetById(id);

            if (quote == null)
            {
                return NotFound(new { message = "Quote no encontrada" });
            }
             try
            {
                _quotesRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Quote ingresado con ID: " + quote.Id);
            }

            return Ok(new { message = $"Quote con el ID : {id} marcado como inactivo" });
        }
    }
}