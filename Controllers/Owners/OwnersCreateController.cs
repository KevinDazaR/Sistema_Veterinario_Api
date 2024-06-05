using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Owners;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersCreateController : ControllerBase
    {
        private readonly IOwnersRepository _petsRepository;

        public OwnersCreateController(IOwnersRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

         [HttpPost]
        public IActionResult Create([FromBody]Owner pet)
        {
             if (pet == null)
            {
                return BadRequest();
            }
            _petsRepository.Add(pet);

            return CreatedAtAction(nameof(Create), new {id = pet.Id}, "Owner creada con exito");
        }
    }
}