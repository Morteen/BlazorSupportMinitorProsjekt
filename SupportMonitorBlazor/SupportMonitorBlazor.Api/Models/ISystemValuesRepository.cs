using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
   public interface ISystemValuesRepository
    {
        Task<IEnumerable<SystemValues>> GetSystemValuesList();
        Task<SystemValues> GetSystemValue(int TmsId);
        Task<SystemValues> AddSystemValue(SystemValues systemValues);
        Task<SystemValues> UpdateSystemValue(SystemValues systemValue);
        void DeleteSystemValues(int Id);
    }
}

