using System.Collections.Generic;
using System.Linq;
using MAVIDI_SMILE.Infrastructure.Data;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories
{
    public class ProgressoRepository : IProgressoRepository
    {
        private readonly AppData _context;

        public ProgressoRepository(AppData context)
        {
            _context = context;
        }

        // Implementação do método para obter progresso pelo ID
        public Progresso? ObterProgressoPorId(int id)
        {
            return _context.Progresso.FirstOrDefault(p => p.Id == id);
        }

        // Implementação do método para obter todos os progressos de um usuário específico
        public IEnumerable<Progresso> ObterProgressoPorUsuarioId(int usuarioId)
        {
            return _context.Progresso.Where(p => p.UsuarioId == usuarioId).ToList();
        }

        // Implementação do método para adicionar um novo progresso
        public Progresso AdicionarProgresso(Progresso progresso)
        {
            _context.Progresso.Add(progresso);
            _context.SaveChanges();
            return progresso;
        }

        // Implementação do método para atualizar um progresso existente
        public Progresso AtualizarProgresso(int id, Progresso progressoAtualizado)
        {
            var progressoExistente = _context.Progresso.FirstOrDefault(p => p.Id == id);
            if (progressoExistente != null)
            {
                progressoExistente.Atividade = progressoAtualizado.Atividade;
                progressoExistente.Data = progressoAtualizado.Data;

                _context.Progresso.Update(progressoExistente);
                _context.SaveChanges();
            }
            return progressoExistente;
        }

        // Implementação do método para deletar um progresso
        public void DeletarProgresso(int id)
        {
            var progresso = _context.Progresso.FirstOrDefault(p => p.Id == id);
            if (progresso != null)
            {
                _context.Progresso.Remove(progresso);
                _context.SaveChanges();
            }
        }
    }
}
