using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Api.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class TmsPropertiesRepository : ITmsPropertiesRepository
    {
        private readonly appDBContext dBContext;


        public TmsPropertiesRepository(appDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

     


        public Task<TmsProperties> UpdateTms(TmsProperties tmsProperties)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<SupportMonitorBlazor.Models.TmsProperties>> ITmsPropertiesRepository.GetTmsPropertiesList()
        {
            return await dBContext.TmsProperties.ToListAsync();
        }

        async Task<IEnumerable<SupportMonitorBlazor.Models.TmsProperties>> ITmsPropertiesRepository.GetTmsProperties(int TmsId)
        {
            return await dBContext.TmsProperties.Where(p=>p.TmsId==TmsId).ToListAsync();
           
        }

        public async Task<SupportMonitorBlazor.Models.TmsProperties> AddTms(SupportMonitorBlazor.Models.TmsProperties tmsProperties)
        {
            throw new NotImplementedException();
        }

        public Task<SupportMonitorBlazor.Models.TmsProperties> UpdateTms(SupportMonitorBlazor.Models.TmsProperties tmsProperties)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlazorTms(int TmsId)
        {
            throw new NotImplementedException();
        }
    }
}
