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
    public class TmsPropertiesController : ControllerBase
    {
        private readonly ITmsPropertiesRepository tmsPropertiesRepository;
        public TmsPropertiesController(ITmsPropertiesRepository tmsPropertiesRepository)
        {
            this.tmsPropertiesRepository = tmsPropertiesRepository;


        }
        [HttpGet]
        public async Task<ActionResult> GetAllTmsProperties()
        {
            try
            {
                return Ok(await tmsPropertiesRepository.GetTmsPropertiesList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Noe er galt her !!");
            }


        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTmsProperties(int id)
        {
            try
            {

                return Ok(await tmsPropertiesRepository.GetTmsProperties(id));


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }


        }
    }
    }
