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
    public class VetsUpdateController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;

        public VetsUpdateController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVet(int id, Vet vet)
        {
            if (id != vet.Id)
            {
                return BadRequest(new { message = "el Id de la Vet no coincide " });
            }

            try
            {
                _vetsRepository.Update(vet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_vetsRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Vet no encontrada" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(UpdateVet), new {id = vet.Id}, "Vet actualizada con exito");
        }

    }
}
