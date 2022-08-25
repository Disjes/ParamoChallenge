using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Utils;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private UsersRepository _usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            var _users = _usersRepository.GetAllUsers();
            var isDuplicated = _users.FirstOrDefault(u => u.Email == user.Email) != null;

            if (isDuplicated)
            {
                Debug.WriteLine("User Created");
                return StatusCode(409, "The user is duplicated");
            }
            
            _usersRepository.AddUser(user);
            //Created Result 201
            return new ObjectResult(user) { StatusCode = 201 };
        }
    }
}
