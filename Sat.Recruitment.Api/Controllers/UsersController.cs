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
    public class UsersController : ControllerBase
    {
        private IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            var isDuplicated = _usersRepository.UserExists(user.Email);

            if (isDuplicated)
            {
                return StatusCode(409, "The user already exists");
            }
            try
            {
                await _usersRepository.AddUserAsync(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while performing server side tasks.");
            }
            //Created Result 201
            return new ObjectResult(user) { StatusCode = 201 };
        }
    }
}
