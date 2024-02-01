using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dosis;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/vacunas/dosis")]
    public class DosisController : ControllerBase
    {
        private readonly IDosisRepository _dosisRepository;

        public DosisController(IDosisRepository dosisRepository)
        {
            _dosisRepository = dosisRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] int vacunaId)
        {
            try
            {
                var dosis = await _dosisRepository.GetAllDosis(vacunaId);
                var vacunasDto = dosis.Select(d => d.ToDosisDto());
                return Ok(vacunasDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromRoute] int mascotaId,
            [FromRoute] int vacunaId,
            [FromBody] CreateDosisDto dosisDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var dosisModel = dosisDto.FromDtoToDosis();

                var dosis = await _dosisRepository.CreateDosis(mascotaId, vacunaId, dosisModel);

                if (dosis == null)
                {
                    return NotFound();
                }

                return Ok(dosis);

                /*   return CreatedAtAction(
                      nameof(GetById),
                      new { mascotaId = mascotaId, id = dosisModel.Id },
                      dosisModel.TodosisDto()
                  ); */
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
