﻿using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class UserRepository: IUserRepository
    {
        MarketPlaceContext _context;
        public UserRepository(MarketPlaceContext context) {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        public User GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Iduser == id);
        }
    }
}