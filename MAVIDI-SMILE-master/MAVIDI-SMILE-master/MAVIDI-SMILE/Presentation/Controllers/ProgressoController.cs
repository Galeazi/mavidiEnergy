using MAVIDI_SMILE.mavidiSmile.Application.Interfaces;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MAVIDI_SMILE.mavidiSmile.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MAVIDI_SMILE.mavidiSmile.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressoController : ControllerBase
    {
        private readonly IProgressoService _progressoService;

        public ProgressoController(IProgressoService progressoService)
        {
            _progressoService = progressoService;
        }

        [HttpGet("{usuarioId}")]
        [SwaggerOperation(Summary = "Lista todos os progressos de um usuário", Description = "Este endpoint retorna todos os registros de progresso para um usuário específico.")]
        [Produces(typeof(IEnumerable<Progresso>))]
        public IActionResult GetProgressoPorUsuario(int usuarioId)
        {
            var progressos = _progressoService.ObterProgressoPorUsuarioId(usuarioId);

            if (progressos != null)
                return Ok(progressos);

            return NotFound("Nenhum progresso encontrado para o usuário especificado.");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registrar progresso", Description = "Este endpoint permite registrar o progresso de um usuário.")]
        [Produces(typeof(Progresso))]
        public IActionResult RegistrarProgresso([FromBody] RegistroProgressoDTO progressoDto)
        {
            try
            {
                var progresso = _progressoService.SalvarProgresso(progressoDto);  // Mudança de RegistrarProgresso para SalvarProgresso

                if (progresso != null)
                    return Ok(progresso);

                return BadRequest("Não foi possível registrar o progresso.");
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
        [SwaggerOperation(Summary = "Atualizar progresso", Description = "Este endpoint permite atualizar um registro de progresso existente.")]
        [Produces(typeof(Progresso))]
        public IActionResult AtualizarProgresso(int id, [FromBody] RegistroProgressoDTO progressoDto)
        {
            try
            {
                var progressoAtualizado = _progressoService.AtualizarProgresso(id, progressoDto);

                if (progressoAtualizado != null)
                    return Ok(progressoAtualizado);

                return BadRequest("Não foi possível atualizar o progresso.");
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
        [SwaggerOperation(Summary = "Deletar progresso", Description = "Este endpoint permite deletar um registro de progresso.")]
        public IActionResult DeletarProgresso(int id)
        {
            _progressoService.DeletarProgresso(id);
            return NoContent();
        }
    }
}
