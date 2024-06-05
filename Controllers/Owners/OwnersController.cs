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
        private readonly IOwnersRepository _ownersRepository;

        public OwnersController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

        [HttpGet]
        public IEnumerable<Owner> GetOwners()
        {
            return _ownersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var pet = _ownersRepository.GetById(id);
            if(pet == null)
            {
                return NotFound(new{message = "Owner no encontrado"});
            }
            return Ok(pet);
        }
    }
}