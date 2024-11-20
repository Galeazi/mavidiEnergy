using MAVIDI_SMILE.Domain.Entities;
using System.Collections.Generic;

namespace MAVIDI_SMILE.mavidiSmile.Domain.Interfaces
{
    public interface IAmigosRepository
    {
        Amigo? ObterAmizadePorId(int id);
        IEnumerable<Amigo> ObterAmizades();
        void AdicionarAmigo(Amigo amigo);
        void AtualizarAmizade(int id, Amigo amigo);
        void RemoverAmigo(int id);
        IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId);
    }
}