using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fintech.Models;

namespace Fintech.DA
{
    public class UserDA: IUserDA
    {
        private readonly FintechContext _context;

        public UserDA(FintechContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string userName, string password)
        {
            User userVO = await _context.Users.SingleOrDefaultAsync(m => m.UserName == userName && m.Password == password);
            

            return userVO;
        }
    }
}
