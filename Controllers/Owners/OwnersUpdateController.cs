using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Owners;
using FiltroJobs.DTO;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersUpdateController : ControllerBase
    {
        private readonly IOwnersRepository _ownersRepository;

        public OwnersUpdateController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, OwnerCreateDTO ownerDTO)
        {
            // if (id != pet.Id)
            // {
            //     return BadRequest(new { message = "el Id de la Owner no coincide " });
            // }

            try
            {
                _ownersRepository.Update(id,ownerDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_ownersRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Owner no encontrado" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateOwner), new {ownerDTO}, "Owner actualizada con exito");
        }

    }
}
