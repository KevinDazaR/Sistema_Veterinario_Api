using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltroJobs.Services.Vets;
using FiltroJobs.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroJobs.Controllers.Vets
{
    [ApiController]
    [Route("api/[controller]")]
    public class VetsDeleteController : ControllerBase
    {
         private readonly IVetsRepository _vetsRepository;

        public VetsDeleteController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteVet(int id)
        {
            var vet = _vetsRepository.GetById(id);

            if (vet == null)
            {
                return NotFound(new { message = "Vet no encontrada" });
            }
             try
            {
                _vetsRepository.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la Vet ingresado con ID: " + vet.Id);
            }

            return Ok(new { message = $"Vet con el ID : {id} marcado como inactivo" });
        }
    }
}