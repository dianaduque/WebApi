using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fintech.Models;
using AutoMapper;
using Fintech.DTOs;
using Fintech.DA;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Fintech.Controllers
{

    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserDA _userDA;

        public UsersController(IMapper mapper, IUserDA userDA)
        {
            _mapper = mapper;
            _userDA = userDA;
        }

        [HttpPost]
        [Route("user/Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            User userVO = await _userDA.Login(user.UserName, user.Password);


            if (userVO != null)
                return Ok(_mapper.Map<UserDTO>(userVO));
            else
                return NoContent();

        }

        
    }
}
