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
    [Route("api/dueños")]
    public class DueñosController : ControllerBase
    {
        private readonly IDueñoRepository _dueñoRepository;

        public DueñosController(IDueñoRepository dueñoRepository)
        {
            _dueñoRepository = dueñoRepository;
        }

        // GET api/dueños?busqueda=ana  -> filtra por nombre o teléfono
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? busqueda)
        {
            try
            {
                var dueños = await _dueñoRepository.GetAll(busqueda);
                return Ok(dueños.Select(d => d.ToDueñoDto()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var dueño = await _dueñoRepository.GetById(id);

                if (dueño == null)
                {
                    return NotFound();
                }
                return Ok(dueño.ToDueñoDetalleDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDueñoDto dueñoDto)
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
                    new { id = dueñoModel.Id },
                    dueñoModel.ToDueñoDto()
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] CreateDueñoDto dueñoDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var dueño = await _dueñoRepository.Update(id, dueñoDto);
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

        // Las mascotas del dueño no se borran: quedan sin dueño asignado.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var dueño = await _dueñoRepository.Delete(id);
                if (dueño == null)
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
