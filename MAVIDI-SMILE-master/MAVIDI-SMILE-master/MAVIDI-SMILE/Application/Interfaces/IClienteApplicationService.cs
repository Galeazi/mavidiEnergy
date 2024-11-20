using System.Collections.Generic;
using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Application.DTOs;

namespace MAVIDI_SMILE.mavidiSmile.Application.Interfaces
{
    public interface IAmigosService
    {
        Amigo? ObterPorId(int id);
        IEnumerable<Amigo> ObterTodos();
        void Adicionar(Amigo amigo);
        void Atualizar(Amigo amigo);
        void Remover(int id);
        IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId);
        Amigo AdicionarAmigo(AmigosDTO amigoDto);
        Amigo AtualizarAmizade(int id, AmigosDTO amigoDto);
    }
}