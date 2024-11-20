using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Domain.Entities;
using System.Collections.Generic;

namespace MAVIDI_ENERGY.Application.Interfaces
{
    public interface IUserApplicationService
    {
        IEnumerable<User> ObterTodosUsuarios();
        User? ObterUsuarioPorId(int id);
        void AdicionarUsuario(UserDTO userDto);
        void AtualizarUsuario(int id, UserDTO userDto);
        void RemoverUsuario(int id);
        User? Authenticate(string email, string password); // Se for utilizado para autenticação
    }
}