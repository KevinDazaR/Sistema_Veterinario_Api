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
    public class PetsDeleteController : ControllerBase
    {
         private readonly IPetsRepository _petsRepository;

        public PetsDeleteController(IPetsRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            var pet = _petsRepository.GetById(id);

            if (pet == null)
            {
                return NotFound(new { message = "Pet no encontrada" });
            }
             try
            {
                _petsRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Pet ingresado con ID: " + pet.Id);
            }

            return Ok(new { message = $"Pet con el ID : {id} marcado como inactivo" });
        }
    }
}