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
    public class OwnersController : ControllerBase
    {
        private readonly IOwnersRepository _petsRepository;

        public OwnersController(IOwnersRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpGet]
        public IEnumerable<Owner> GetOwners()
        {
            return _petsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var pet = _petsRepository.GetById(id);
            if(pet == null)
            {
                return NotFound(new{message = "Owner no encontrado"});
            }
            return Ok(pet);
        }
    }
}