using SupportMonitorBlazor.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    interface ITMS_ServicesRepository
    {
        Task<IEnumerable<TMS_ServicesRepository>> GetServiceList();
        Task<TMS_ServicesRepository> GetService(int TmsId);
        Task<TMS_ServicesRepository> AddService(TMS_ServicesRepository service);
        Task<TMS_ServicesRepository> UpdateTms(TMS_ServicesRepository serevice);
        void DeleteTmsService(int TmsId);
    }
}
