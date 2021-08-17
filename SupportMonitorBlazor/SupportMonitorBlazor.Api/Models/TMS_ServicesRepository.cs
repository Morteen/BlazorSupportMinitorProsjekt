using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SupportMonitorBlazor.Api.Models
{
    public class TMS_ServicesRepository : ITMS_ServicesRepository
    {
        private readonly appDBContext dBContext;
        public TMS_ServicesRepository(appDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IEnumerable<TMS_Services>> GetServiceList()
        {
         
            return await dBContext.TMS_Services.ToListAsync();
        }
        public async Task<TMS_Services> GetService(int TMS_Id,string Name)
        {
            return await dBContext.TMS_Services.FirstOrDefaultAsync(s => s.TMS_Id == TMS_Id && s.Name==Name);
        }



        public async Task<IEnumerable<TMS_Services>> GetServiceListForTms(int TMS_ID)
        {
            return await dBContext.TMS_Services.Where(t=>t.TMS_Id==TMS_ID).ToListAsync();
        }




        public Task<TMS_Services> AddService(TMS_Services service)
        {
            throw new NotImplementedException();
        }

        public void DeleteTmsService(int TmsId)
        {
            throw new NotImplementedException();
        }

      


        public Task<TMS_Services> UpdateTms(TMS_Services serevice)
        {
            throw new NotImplementedException();
        }

       
        public  async Task<TMS_Services> AddOrUpdateTms(TMS_Services service)
        {
            var result = await dBContext.TMS_Services.FirstOrDefaultAsync(f=>f.TMS_Id==service.TMS_Id && f.Name==service.Name);
          
            if (result!= null)
            {
                //result.Name = service.Name;
                result.DisplayName = service.DisplayName;
                result.Status = service.Status;
                result.RunningSince = DateTime.Now;



                await dBContext.SaveChangesAsync();
                return result;
            }
            else
            {

                var resulte = await dBContext.TMS_Services.AddAsync(service);
                await dBContext.SaveChangesAsync();
                return resulte.Entity;
            }
           //return null;



        }
    }
}
