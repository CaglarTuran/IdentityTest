﻿using IdentityTest.Models;

namespace IdentityTest.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void  CreateUser(User user)
        {

        }
    }
}
