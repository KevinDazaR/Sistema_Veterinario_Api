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
    public class OwnersDeleteController : ControllerBase
    {
         private readonly IOwnersRepository _petsRepository;

        public OwnersDeleteController(IOwnersRepository petsRepository)
        {
            _petsRepository = petsRepository;
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(int id)
        {
            var pet = _petsRepository.GetById(id);

            if (pet == null)
            {
                return NotFound(new { message = "Owner no encontrada" });
            }
             try
            {
                _petsRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Owner ingresado con ID: " + pet.Id);
            }

            return Ok(new { message = $"Owner con el ID : {id} marcado como inactivo" });
        }
    }
}