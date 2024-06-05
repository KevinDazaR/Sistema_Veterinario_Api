using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Owners;
using FiltroJobs.Models;
using FiltroJobs.DTO;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersCreateController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnersCreateController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

         [HttpPost]
        public IActionResult Create([FromBody]OwnerCreateDTO ownerDTO)
        {
             if (ownerDTO == null)
            {
                return BadRequest();
            }
            _ownersRepository.Add(ownerDTO);

            return CreatedAtAction(nameof(Create), new {ownerDTO}, "Owner creado con exito");
        }
    }
}