using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Owners;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersUpdateController : ControllerBase
    {
        private readonly IOwnersRepository _petsRepository;

        public OwnersUpdateController(IOwnersRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, Owner pet)
        {
            if (id != pet.Id)
            {
                return BadRequest(new { message = "el Id de la Owner no coincide " });
            }

            try
            {
                _petsRepository.Update(pet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_petsRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Owner no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateOwner), new {id = pet.Id}, "Owner actualizada con exito");
        }

    }
}
