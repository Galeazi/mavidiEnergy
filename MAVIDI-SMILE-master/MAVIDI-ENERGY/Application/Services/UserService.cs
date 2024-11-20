using System;
using System.Collections.Generic;
using MAVIDI_ENERGY.Application.DTOs;
using MAVIDI_ENERGY.Application.Interfaces;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Domain.Interfaces;

namespace MAVIDI_ENERGY.Application.Services
{
    public class UserService : IUserApplicationService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User? ObterUsuarioPorId(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<User> ObterTodosUsuarios()
        {
            return _repository.GetAll();
        }

        public void AdicionarUsuario(UserDTO userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = HashPassword(userDto.Password),
                CreatedAt = DateTime.UtcNow
            };
            _repository.Add(user);
        }

        public void AtualizarUsuario(int id, UserDTO userDto)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                user.Name = userDto.Name;
                user.Email = userDto.Email;
                if (!string.IsNullOrEmpty(userDto.Password))
                {
                    user.PasswordHash = HashPassword(userDto.Password);
                }
                user.UpdatedAt = DateTime.UtcNow;
                _repository.Update(user);
            }
        }

        public void RemoverUsuario(int id)
        {
            _repository.Delete(id);
        }

        public User? Authenticate(string email, string password)
        {
            var user = _repository.GetByEmail(email);
            if (user != null && VerifyPassword(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
}
