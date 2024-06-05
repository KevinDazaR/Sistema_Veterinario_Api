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
    public class VetsController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;

        public VetsController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }

        [HttpGet]
        public IEnumerable<Vet> GetVets()
        {
            return _vetsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var vet = _vetsRepository.GetById(id);
            if(vet == null)
            {
                return NotFound(new{message = "Vet no encontrado"});
            }
            return Ok(vet);
        }
    }
}