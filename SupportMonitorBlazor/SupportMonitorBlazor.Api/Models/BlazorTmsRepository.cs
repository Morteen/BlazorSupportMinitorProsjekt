using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class BlazorTmsRepository : IBlazorTmsRepository
    {
        private readonly appDBContext dBContext;
        

        public BlazorTmsRepository(appDBContext dBContext)
        {
            this.dBContext = dBContext;
        }




        public async Task<IEnumerable<BlazorTMS>> GetTmsList()
        {
            return await dBContext.BlazorTMS.ToListAsync();
        }

        public async Task<BlazorTMS> AddTms(BlazorTMS tms)
        {

         var resulte= await dBContext.BlazorTMS.AddAsync(tms);
            await dBContext.SaveChangesAsync();

            return resulte.Entity;
        }

        public async void DeleteBlazorTms(int TmsId)
        {

            var result = await dBContext.BlazorTMS.FirstOrDefaultAsync(t => t.TmsId == TmsId);
            if (result != null)
            {
                dBContext.BlazorTMS.Remove(result);
                await dBContext.SaveChangesAsync();
            }
        }

        public async Task<BlazorTMS> GetTms(int TmsId)
        {
           return await dBContext.BlazorTMS.FirstOrDefaultAsync(t => t.TmsId == TmsId);
          
        }

       

        public async Task<BlazorTMS> UpdateTms(BlazorTMS tms)
        {
            var result = await dBContext.BlazorTMS.FirstOrDefaultAsync(t => t.TmsId ==tms.TmsId);
            if (result != null)
            {
                result.Name = tms.Name;
                result.Country = tms.Country;
                result.TmsCategory = tms.TmsCategory;
                result.CriticalErrors = tms.CriticalErrors;

                await dBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
