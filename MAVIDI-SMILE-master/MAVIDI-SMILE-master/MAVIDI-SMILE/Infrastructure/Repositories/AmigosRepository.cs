using System.Collections.Generic;
using System.Linq;
using MAVIDI_SMILE.Domain.Entities;
using MAVIDI_SMILE.Infrastructure.Data;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories
{
    public class AmigosRepository : IAmigosRepository
    {
        private readonly AppData _context;

        public AmigosRepository(AppData context)
        {
            _context = context;
        }

        // Implementação do método para obter uma amizade pelo ID
        public Amigo? ObterAmizadePorId(int id)
        {
            return _context.Amigos.FirstOrDefault(a => a.Id == id);
        }

        // Implementação do método para obter todas as amizades
        public IEnumerable<Amigo> ObterAmizades()
        {
            return _context.Amigos.ToList();
        }

        // Implementação do método para obter todas as amizades de um usuário pelo ID do usuário
        public IEnumerable<Amigo> ObterAmizadesPorUsuarioId(int usuarioId)
        {
            return _context.Amigos.Where(a => a.UsuarioId == usuarioId).ToList();
        }

        // Implementação do método para adicionar uma nova amizade
        public void AdicionarAmigo(Amigo amigo)
        {
            _context.Amigos.Add(amigo);
            _context.SaveChanges();
        }

        // Implementação do método para atualizar uma amizade existente
        public void AtualizarAmizade(int id, Amigo amigoAtualizado)
        {
            var amigoExistente = _context.Amigos.FirstOrDefault(a => a.Id == id);
            if (amigoExistente != null)
            {
                amigoExistente.UsuarioId = amigoAtualizado.UsuarioId;
                amigoExistente.AmigoId = amigoAtualizado.AmigoId;

                _context.Amigos.Update(amigoExistente);
                _context.SaveChanges();
            }
        }

        // Implementação do método para remover uma amizade
        public void RemoverAmigo(int id)
        {
            var amigo = _context.Amigos.FirstOrDefault(a => a.Id == id);
            if (amigo != null)
            {
                _context.Amigos.Remove(amigo);
                _context.SaveChanges();
            }
        }
    }
}
