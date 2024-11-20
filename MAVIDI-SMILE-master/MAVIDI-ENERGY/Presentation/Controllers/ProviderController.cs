using MAVIDI_ENERGY.Application.Interfaces;
using MAVIDI_ENERGY.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using MAVIDI_ENERGY.Interfaces;

namespace MAVIDI_ENERGY.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ISolarProviderService _solarProviderService;

        public ProviderController(ISolarProviderService solarProviderService)
        {
            _solarProviderService = solarProviderService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar fornecedores", Description = "Este endpoint retorna todos os fornecedores de energia solar disponíveis.")]
        [Produces(typeof(IEnumerable<SolarProviderDTO>))]
        public IActionResult GetAllProviders()
        {
            var providers = _solarProviderService.ObterTodosFornecedores();

            if (providers != null && providers.Any())
                return Ok(providers);

            return NotFound("Nenhum fornecedor encontrado.");
        }

        [HttpGet("{location}")]
        [SwaggerOperation(Summary = "Buscar fornecedores por localização", Description = "Este endpoint retorna os fornecedores de energia solar com base na localização.")]
        [Produces(typeof(IEnumerable<SolarProviderDTO>))]
        public IActionResult GetProvidersByLocation(string location)
        {
            var providers = _solarProviderService.ObterFornecedoresPorLocalizacao(location);

            if (providers != null && providers.Any())
                return Ok(providers);

            return NotFound($"Nenhum fornecedor encontrado para a localização: {location}");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adicionar fornecedor", Description = "Este endpoint permite adicionar um novo fornecedor de energia solar.")]
        [Produces(typeof(SolarProviderDTO))]
        public IActionResult AddProvider([FromBody] SolarProviderDTO providerDto)
        {
            try
            {
                var provider = _solarProviderService.AdicionarFornecedor(providerDto);

                if (provider != null)
                    return Ok(provider);

                return BadRequest("Não foi possível adicionar o fornecedor.");
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
        [SwaggerOperation(Summary = "Atualizar fornecedor", Description = "Este endpoint permite atualizar informações de um fornecedor existente.")]
        [Produces(typeof(SolarProviderDTO))]
        public IActionResult UpdateProvider(int id, [FromBody] SolarProviderDTO providerDto)
        {
            try
            {
                var updatedProvider = _solarProviderService.AtualizarFornecedor(id, providerDto);

                if (updatedProvider != null)
                    return Ok(updatedProvider);

                return BadRequest("Não foi possível atualizar o fornecedor.");
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
        [SwaggerOperation(Summary = "Remover fornecedor", Description = "Este endpoint permite remover um fornecedor de energia solar.")]
        public IActionResult DeleteProvider(int id)
        {
            try
            {
                _solarProviderService.RemoverFornecedor(id);
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
