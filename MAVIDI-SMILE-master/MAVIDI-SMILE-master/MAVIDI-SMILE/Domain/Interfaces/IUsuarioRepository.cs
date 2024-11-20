using System.Collections.Generic;
using MAVIDI_SMILE.mavidiSmile.Domain.Entities;


namespace MAVIDI_SMILE.mavidiSmile.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? ObterUsuarioPorId(int id);
        IEnumerable<Usuario> ObterTodosUsuarios();
        Usuario AdicionarUsuario(Usuario usuario);
        Usuario AtualizarUsuario(int id, Usuario usuario);
        void DeletarUsuario(int id);
    }
}