using System.Collections.Generic;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Interfaces
{
    public interface IProgressoRepository
    {
        Progresso? ObterProgressoPorId(int id);
        IEnumerable<Progresso> ObterProgressoPorUsuarioId(int usuarioId);
        Progresso AdicionarProgresso(Progresso progresso);
        Progresso AtualizarProgresso(int id, Progresso progresso);
        void DeletarProgresso(int id);
    }
}