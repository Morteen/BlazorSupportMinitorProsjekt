using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMonitorBlazor.Api.Models;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemValuesController : ControllerBase
    {
        private readonly ISystemValuesRepository systemValuesRepository;
        public SystemValuesController(ISystemValuesRepository systemValuesRepository)
        {
            this.systemValuesRepository = systemValuesRepository;

        }
        [HttpGet]
        public async Task<ActionResult> GetAllSystemValues()
        {
            try
            {
                return Ok(await systemValuesRepository.GetSystemValuesList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemValues>> GetOneSystemValue(int id)
        {
            try
            {
                var result = await systemValuesRepository .GetSystemValue(id);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                       "Vi kan ikke finne denne kunden");
                }
                else
                {
                    return Ok(result);
                }


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }


        }

    }
}
