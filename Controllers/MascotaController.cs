using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Mascotas;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/mascotas")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaRepository _mascotaRepo;

        public MascotaController(IMascotaRepository mascotaRepository)
        {
            _mascotaRepo = mascotaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var mascotas = await _mascotaRepo.GetAll();
                var mascotasDto = mascotas.Select(m => m.ToMascotaDto());
                return Ok(mascotasDto);
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
                var mascota = await _mascotaRepo.GetById(id);
                if (mascota == null)
                {
                    return NotFound();
                }
                return Ok(mascota.ToMascotaDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMascotaDto mascotaDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var mascotaModel = mascotaDto.FromDtoToMascota();
                await _mascotaRepo.Create(mascotaModel);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = mascotaModel.Id },
                    mascotaModel.ToMascotaDto()
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
            [FromBody] CreateMascotaDto mascotaDto
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var mascota = await _mascotaRepo.Update(id, mascotaDto);
                if (mascota == null)
                {
                    return NotFound();
                }
                return Ok(mascota.ToMascotaDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var mascota = await _mascotaRepo.Delete(id);
                if (mascota == null)
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
