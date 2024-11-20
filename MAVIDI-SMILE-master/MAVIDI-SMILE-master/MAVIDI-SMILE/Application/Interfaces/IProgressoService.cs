using System.Collections.Generic;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Interfaces
{
    public interface IProgressoService
    {
        Progresso? ObterProgressoPorId(int id);
        IEnumerable<Progresso> ObterProgressoPorUsuarioId(int usuarioId);
        Progresso SalvarProgresso(RegistroProgressoDTO progressoDto);
        Progresso AtualizarProgresso(int id, RegistroProgressoDTO progressoDto);
        void DeletarProgresso(int id);
    }
}