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
    public class PetsController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        public PetsController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpGet]
        public IEnumerable<Pet> GetPets()
        {
            return _petsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var pet = _petsRepository.GetById(id);
            if(pet == null)
            {
                return NotFound(new{message = "Pet no encontrado"});
            }
            return Ok(pet);
        }
    }
}