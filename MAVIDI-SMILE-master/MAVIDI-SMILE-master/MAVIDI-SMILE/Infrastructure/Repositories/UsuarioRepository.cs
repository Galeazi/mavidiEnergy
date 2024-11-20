using System.Collections.Generic;
using System.Linq;
using MAVIDI_SMILE.Infrastructure.Data;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;
using MAVIDI_SMILE.mavidiSmile.Domain.Interfaces;

namespace MAVIDI_SMILE.mavidiSmile.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppData _context;

        public UsuarioRepository(AppData context)
        {
            _context = context;
        }

        // Implementação do método para obter usuário pelo ID
        public Usuario? ObterUsuarioPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        // Implementação do método para obter todos os usuários
        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        // Implementação do método para adicionar um novo usuário
        public Usuario AdicionarUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        // Implementação do método para atualizar um usuário existente
        public Usuario AtualizarUsuario(int id, Usuario usuarioAtualizado)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuarioAtualizado.Nome;
                usuarioExistente.Email = usuarioAtualizado.Email;

                _context.Usuarios.Update(usuarioExistente);
                _context.SaveChanges();
            }
            return usuarioExistente;
        }

        // Implementação do método para deletar um usuário
        public void DeletarUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
    }
}
