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


        public Task<TMS_ServicesRepository> AddService(TMS_ServicesRepository service)
        {
            throw new NotImplementedException();
        }

        public void DeleteTmsService(int TmsId)
        {
            throw new NotImplementedException();
        }

        public Task<TMS_ServicesRepository> GetService(int TmsId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TMS_ServicesRepository>> GetServiceList()
        {
            //return await dBContext..ToListAsync(); throw new NotImplementedException();
            throw new NotImplementedException();
        }

        public Task<TMS_ServicesRepository> UpdateTms(TMS_ServicesRepository serevice)
        {
            throw new NotImplementedException();
        }
    }
}
