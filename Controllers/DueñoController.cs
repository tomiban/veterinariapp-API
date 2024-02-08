using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Dueño;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/mascotas/{mascotaId}/dueño")]
    public class DueñoController : ControllerBase
    {
        private readonly IDueñoRepository _dueñoRepository;

        public DueñoController(IDueñoRepository dueñoRepository)
        {
            _dueñoRepository = dueñoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int mascotaId, [FromRoute] int id)
        {
            try
            {
                var dueño = await _dueñoRepository.GetById(mascotaId, id);

                if (dueño == null)
                {
                    return NotFound();
                }
                return Ok(dueño.ToDueñoDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromRoute] int mascotaId,
            [FromBody] CreateDueñoDto dueñoDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var dueñoModel = dueñoDto.FromDtoToDueño();
                await _dueñoRepository.Create(dueñoModel);
                return CreatedAtAction(
                    nameof(GetById),
                    new { mascotaId = mascotaId, id = dueñoModel.Id },
                    dueñoModel.ToDueñoDto()
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
