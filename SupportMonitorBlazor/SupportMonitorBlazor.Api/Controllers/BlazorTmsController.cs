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
    public class BlazorTmsController : ControllerBase
    {
        private readonly IBlazorTmsRepository blazorTmsRepository;
        public BlazorTmsController(IBlazorTmsRepository blazorTmsRepository)
        {
            this.blazorTmsRepository = blazorTmsRepository;

        }

        [HttpGet]
        public async Task<ActionResult> GetAllBlazorTms()
        {
            try
            {
                return Ok(await blazorTmsRepository.GetTmsList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BlazorTMS>> GetOneBlazorTms(int id)
        {
            try
            {
                var result = await blazorTmsRepository.GetTms(id);
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


        [HttpPost]
        public async Task<ActionResult<BlazorTMS>> CreateBlazorTMS(BlazorTMS tms)
        {
            try
            {
                if (tms == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var createdTms = await blazorTmsRepository.AddTms(tms);

                //CreatedAtAction tar 3 parameter: navn på metoden som man får ved NameOf + id + det nye objektet
                return Ok(CreatedAtAction(nameof(GetOneBlazorTms), new { id = createdTms.TmsId }, createdTms));

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message + " Error retrieving data from the database");
            }

        }




        [HttpPut("{id:int}")]
        public async Task<ActionResult<BlazorTMS>> UpdateEmployee(int id, BlazorTMS tms)
        {
            try
            {
                if (id != tms.TmsId)
                {
                    return BadRequest("Employee id mismatch");
                }

                var BlazorTmsToUpdate = await blazorTmsRepository.GetTms(id);
                if (BlazorTmsToUpdate == null)
                {
                    return NotFound($"Kunde with ID ={id} not faund in the database");
                }
                return await blazorTmsRepository.UpdateTms(tms);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message + "Error Updating data from in the database");
            }

        }

    }
}
