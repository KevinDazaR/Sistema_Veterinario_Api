using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Quotes;
using FiltroJobs.DTO;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesCreateController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;

        public QuotesCreateController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

         [HttpPost]
        public IActionResult Create([FromBody]QuoteCreateDTO quoteDTO)
        {
             if (quoteDTO == null)
            {
                return BadRequest();
            }
            _quotesRepository.Add(quoteDTO);

             return Ok("Cita creada exitosamente" ); 

            // return CreatedAtAction(nameof(Create), new {quoteDTO}, "Quote creada con exito");
        }
    }
}