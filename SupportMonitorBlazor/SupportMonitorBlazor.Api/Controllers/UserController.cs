using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMonitorBlazor.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        public UserController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;

        }
        [HttpGet]
        public async Task<ActionResult> GetAllusers()
        {
            try
            {
                return Ok(await usersRepository.GetUserList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
        [HttpGet("LoginUser")]
        public async Task<ActionResult> LoginUser(string userName,string password)
        {
            try
            {
                return Ok(await usersRepository.LoginUser(userName,password));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
    }
}
