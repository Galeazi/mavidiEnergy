using System.Net;
using MAVIDI_ENERGY.Application.Interfaces;
using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MAVIDI_ENERGY.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyController : ControllerBase
    {
        private readonly IEnergyUsageService _energyUsageService;

        public EnergyController(IEnergyUsageService energyUsageService)
        {
            _energyUsageService = energyUsageService;
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Listar consumo de energia", Description = "Este endpoint retorna todos os registros de consumo de energia para um usuário específico.")]
        [Produces(typeof(IEnumerable<EnergyUsage>))]
        public IActionResult GetEnergyUsageByUser(int userId)
        {
            var energyUsages = _energyUsageService.ObterRegistrosPorUsuarioId(userId);

            if (energyUsages != null && energyUsages.Any())
                return Ok(energyUsages);

            return NotFound("Nenhum registro de consumo encontrado para o usuário especificado.");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registrar consumo de energia", Description = "Este endpoint permite registrar o consumo de energia de um usuário.")]
        [Produces(typeof(EnergyUsage))]
        public IActionResult RegisterEnergyUsage([FromBody] EnergyUsageDTO energyUsageDto)
        {
            try
            {
                var energyUsage = _energyUsageService.SalvarRegistro(energyUsageDto);

                if (energyUsage != null)
                    return Ok(energyUsage);

                return BadRequest("Não foi possível registrar o consumo de energia.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar consumo de energia", Description = "Este endpoint permite atualizar um registro de consumo de energia existente.")]
        [Produces(typeof(EnergyUsage))]
        public IActionResult UpdateEnergyUsage(int id, [FromBody] EnergyUsageDTO energyUsageDto)
        {
            try
            {
                var updatedEnergyUsage = _energyUsageService.AtualizarRegistro(id, energyUsageDto);

                if (updatedEnergyUsage != null)
                    return Ok(updatedEnergyUsage);

                return BadRequest("Não foi possível atualizar o registro de consumo de energia.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest
                });
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletar consumo de energia", Description = "Este endpoint permite deletar um registro de consumo de energia.")]
        public IActionResult DeleteEnergyUsage(int id)
        {
            try
            {
                _energyUsageService.DeletarRegistro(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    Status = HttpStatusCode.BadRequest
                });
            }
        }
    }
}
