using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class SystemValuesRepository : ISystemValuesRepository
    {

        private readonly appDBContext dBContext;


        public SystemValuesRepository(appDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Task<SystemValues> AddSystemValue(SystemValues systemValues)
        {
            throw new NotImplementedException();
        }

        public void DeleteSystemValues(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<SystemValues> GetSystemValue(int TmsId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SystemValues>> GetSystemValuesList()
        {
            return await dBContext.SystemValues.ToListAsync();
        }

        public Task<SystemValues> UpdateSystemValue(SystemValues systemValue)
        {
            throw new NotImplementedException();
        }
    }
}
