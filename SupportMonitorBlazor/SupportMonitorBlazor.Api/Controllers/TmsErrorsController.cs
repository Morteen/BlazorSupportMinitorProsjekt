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
    public class TmsErrorsController : ControllerBase
    {
        private readonly ITmsErrorsRepository tmsErrorsRepository;
        public TmsErrorsController(ITmsErrorsRepository tmsErrorsRepository)
        {
            this.tmsErrorsRepository = tmsErrorsRepository;

        }



        [HttpGet]
        public async Task<ActionResult> GetAllTmsErrors()
        {
            try
            {
                return Ok(await tmsErrorsRepository.GetTmsErrorsList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTmsErrors(int id)
        {
            try
            {
                return Ok(await tmsErrorsRepository.GetTmsErrors(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }




        }
    }
}
