using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Pets;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsUpdateController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;

        public PetsUpdateController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest(new { message = "el Id de la Pet no coincide " });
            }

            try
            {
                _petsRepository.Update(pet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_petsRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Pet no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdatePet), new {id = pet.Id}, "Pet actualizada con exito");
        }

    }
}
