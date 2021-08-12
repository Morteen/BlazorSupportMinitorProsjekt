using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class TmsErrorsRepository : ITmsErrorsRepository
    {
        private readonly appDBContext dBContext;


        public TmsErrorsRepository(appDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<IEnumerable<TmsErrors>> GetTmsErrorsList()
        {
            return await dBContext.TmsErrors.ToListAsync();
        }
        public async Task<IEnumerable<TmsErrors>> GetTmsErrors(int TmsId)
        {
            return await dBContext.TmsErrors.Where(e=>e.TMSid==TmsId).ToListAsync();
        }

        public Task<TmsErrors> AddTmsError(TmsErrors tmsError)
        {
            throw new NotImplementedException();
        }

        public void DeleteTmsError(int TmsId)
        {
            throw new NotImplementedException();
        }

       

       

        public Task<TmsErrors> UpdateTmsError(TmsErrors tms)
        {
            throw new NotImplementedException();
        }
    }
}
