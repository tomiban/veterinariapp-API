using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Vacunas;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/mascotas/{mascotaId}/vacunas")]
    public class VacunaController : ControllerBase
    {
        private readonly IVacunaRepository _vacunaRepo;

        public VacunaController(IVacunaRepository vacunaRepository)
        {
            _vacunaRepo = vacunaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int mascotaId)
        {
            try
            {
                var vacunas = await _vacunaRepo.GetAllByMascotaId(mascotaId);
                var vacunasDto = vacunas.Select(v => v.ToVacunaDto());
                return Ok(vacunasDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int mascotaId, [FromRoute] int id)
        {
            try
            {
                var vacuna = await _vacunaRepo.GetVacunaByMascotaId(mascotaId, id);
                if (vacuna == null)
                {
                    return NotFound();
                }
                return Ok(vacuna.ToVacunaDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromRoute] int mascotaId,
            [FromBody] CreateVacunaDto vacunaDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var vacunaModel = vacunaDto.FromDtoToVacuna();
                await _vacunaRepo.CreateVacunaByMascota(mascotaId, vacunaModel);

                return CreatedAtAction(
                    nameof(GetById),
                    new { mascotaId = mascotaId, id = vacunaModel.Id },
                    vacunaModel.ToVacunaDto()
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int mascotaId,
            [FromRoute] int id,
            [FromBody] CreateVacunaDto vacunaDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var vacuna = await _vacunaRepo.UpdateVacunaByMascota(mascotaId, id, vacunaDto);
                if (vacuna == null)
                {
                    return NotFound();
                }
                return Ok(vacuna.ToVacunaDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int mascotaId, [FromRoute] int id)
        {
            try
            {
                var vacuna = await _vacunaRepo.DeleteVacunaByMascotaId(mascotaId, id);
                if (vacuna == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
