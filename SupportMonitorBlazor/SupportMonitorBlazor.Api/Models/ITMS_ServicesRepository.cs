using SupportMonitorBlazor.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
   public interface ITMS_ServicesRepository
    {
        Task<IEnumerable<TMS_Services>> GetServiceList();
        Task<IEnumerable<TMS_Services>> GetServiceListForTms(int TMS_ID);
        Task<TMS_Services> GetService(int Tms_Id,string Name);
        Task<TMS_Services> GetOneService(int Id,int Tms_Id);
        Task<TMS_Services> AddService(TMS_Services service);
        Task<TMS_Services> UpdateTms(TMS_Services serevice);
        Task<TMS_Services> AddOrUpdateTms(TMS_Services serevice);
        void DeleteTmsService(int TmsId);
    }
}
