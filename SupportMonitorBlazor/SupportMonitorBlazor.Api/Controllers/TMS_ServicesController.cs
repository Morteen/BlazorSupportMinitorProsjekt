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
    public class TMS_ServicesController : ControllerBase
    {
        private readonly ITMS_ServicesRepository tMS_ServicesRepository;
        public TMS_ServicesController(ITMS_ServicesRepository tMS_ServicesRepository)
        {
            this.tMS_ServicesRepository = tMS_ServicesRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllServices()
        {
            try
            {
                return Ok(await tMS_ServicesRepository.GetServiceList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }

        [HttpGet("{TMS_Id}")]
        public async Task<ActionResult> GetAllServicesForTMS(int TMS_Id)
        {
            try
            {
                return Ok(await tMS_ServicesRepository.GetServiceListForTms(TMS_Id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
       /* [HttpGet("{TMS_id}/{Name}")]
        public async Task<ActionResult<TMS_Services>> GetOneTmsService(int TMS_id,string Name)
        {
            try
            {
                var result = await tMS_ServicesRepository.GetService(TMS_id,Name);
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


        }*/
        [HttpGet("{Id}/{TMS_id}")]
        public async Task<ActionResult<TMS_Services>> GetOneTmsService(int Id,int TMS_id)
        {
            try
            {
                
                var result = await tMS_ServicesRepository.GetOneService(Id,TMS_id);
        
              
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                       "Vi kan ikke finne denne windows servicen");
                }
                else
                {
               
                    return result;
                }


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }


        }




        [HttpPost]
        public async Task<ActionResult<TMS_Services>> CreateOrUpdateTMSService(TMS_Services service )
        {
            try
            {
                if (service == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                var createdOrUpdatedTms_service = await tMS_ServicesRepository.AddOrUpdateTms(service);

                //CreatedAtAction tar 3 parameter: navn på metoden som man får ved NameOf + id + det nye objektet
                // return Ok(CreatedAtAction(nameof(createdOrUpdatedTms_service.Name), new { id = createdOrUpdatedTms_service.Id }, createdOrUpdatedTms_service));
                return Ok(service.Id+" Var vellyket"+service.DisplayName);




            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message + " Error retrieving data from the database");
            }

        }





    }
}
