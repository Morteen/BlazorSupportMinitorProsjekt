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
    public class DiskSpaceController: ControllerBase
    {

        private readonly IDiskSpaceRepository diskSpaceRepository;
        public DiskSpaceController(IDiskSpaceRepository diskSpaceRepository)
        {
            this.diskSpaceRepository = diskSpaceRepository;

        }



        [HttpGet]
        public async Task<ActionResult> GetAllDsikSpaceInDB()
        {
            try
            {
                return Ok(await diskSpaceRepository.GetDiskSpaceList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTmsDiskSpaces(int id)//GetTMSDiskspace
        {
            try
            {
                return Ok(await diskSpaceRepository.GetTmsDiskSpace(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error retrieving data from the database");
            }




        }



        [HttpPost]
        public async Task<ActionResult<DiskSpace>> CreateDisksapce(DiskSpace space)
        {
            try
            {
                if (space == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,"Object er null");
                }
              
                var createdDiskSpace = await diskSpaceRepository.AddTmsDiskSpace(space);

                //CreatedAtAction tar 3 parameter: navn på metoden som man får ved NameOf + id + det nye objektet
                return CreatedAtAction(nameof(createdDiskSpace), new { id = createdDiskSpace.Id }, createdDiskSpace);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message + "Error retrieving data from the database");
            }

        }





        [HttpPut]
        public async Task<ActionResult<DiskSpace>> UpdateDiskspace(DiskSpace ds)
       {
          try
           {
                 /*if (id != ds.Id)
                  {
                      return BadRequest("DiskSpaceId  mismatch");
                  }*/
            

                var DiskSpaceToUpdate = await diskSpaceRepository.GetOneTmsDiskSpace(ds.Id);
                if (DiskSpaceToUpdate==null) {
                    return StatusCode(StatusCodes.Status304NotModified, "DiskSpaceToUpdate er null i DiskSpaceController");
                }
            

                if (DiskSpaceToUpdate == null)
               {
                    return NotFound($"Diskspace with ID ={ds.Id} not found in the database");
                   
                }
               return await diskSpaceRepository.UpdateTmsDiskSpace(ds);
           }
           catch (Exception e)
           {
               return StatusCode(StatusCodes.Status500InternalServerError, e.Message + "Error Updating data from in the database");
           }

    }











}
}
