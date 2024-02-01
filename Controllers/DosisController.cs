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
    [Route("api/mascotas/{mascotaId}/vacunas/{vacunaId}/dosis")]
    public class DosisController : ControllerBase
    {
        private readonly IDosisRepository _dosisRepository;

        public DosisController(IDosisRepository dosisRepository)
        {
            _dosisRepository = dosisRepository;
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

                await _dosisRepository.CreateDosis(mascotaId, vacunaId, dosisModel);

                return Ok(dosisModel.ToDosisDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
