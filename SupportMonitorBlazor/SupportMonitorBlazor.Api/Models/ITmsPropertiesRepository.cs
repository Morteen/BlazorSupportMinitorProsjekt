
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
   public interface ITmsPropertiesRepository
    {
        Task<IEnumerable<TmsProperties>> GetTmsPropertiesList();
        Task<IEnumerable<TmsProperties>> GetTmsProperties(int TmsId);
        Task<TmsProperties> AddTms(TmsProperties tmsProperties);
        Task<TmsProperties> UpdateTms(TmsProperties tmsProperties);
        void DeleteBlazorTms(int TmsId);
    }
}
