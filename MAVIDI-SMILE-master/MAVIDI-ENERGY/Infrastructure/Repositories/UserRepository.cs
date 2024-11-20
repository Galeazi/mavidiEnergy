using System.Collections.Generic;
using System.Linq;
using MAVIDI_ENERGY.Domain.Entities;
using MAVIDI_ENERGY.Domain.Interfaces;
using MAVIDI_ENERGY.Infrastructure.Data;

namespace MAVIDI_ENERGY.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppData _context;

        public UserRepository(AppData context)
        {
            _context = context;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}