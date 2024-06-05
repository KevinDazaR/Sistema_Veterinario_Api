using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Vets;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VetsCreateController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;

        public VetsCreateController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }

         [HttpPost]
        public IActionResult Create([FromBody]Vet vet)
        {
             if (vet == null)
            {
                return BadRequest();
            }
            _vetsRepository.Add(vet);

            return CreatedAtAction(nameof(Create), new {id = vet.Id}, "Vet creada con exito");
        }
    }
}