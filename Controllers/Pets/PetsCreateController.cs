using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Pets;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsCreateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        public PetsCreateController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

         [HttpPost]
        public IActionResult Create([FromBody]Pet pet)
        {
             if (pet == null)
            {
                return BadRequest();
            }
            _petsRepository.Add(pet);

            return CreatedAtAction(nameof(Create), new {id = pet.Id}, "Pet creada con exito");
        }
    }
}