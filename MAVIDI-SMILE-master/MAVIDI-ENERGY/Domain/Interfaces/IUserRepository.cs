using MAVIDI_ENERGY.Domain.Entities;
using System.Collections.Generic;

namespace MAVIDI_ENERGY.Domain.Interfaces
{
    public interface IUserRepository
    {
        User? GetById(int id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        User? GetByEmail(string email);
    }
}