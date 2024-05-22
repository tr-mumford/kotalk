using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository : IUserService
    {
        private readonly kotalkDbContext _context;

        public UserRepository(kotalkDbContext context)
        {
            _context = context;
        }

        public User RegisterUser(string username)
        {
            var user = new User { Username = username };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User FindUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
