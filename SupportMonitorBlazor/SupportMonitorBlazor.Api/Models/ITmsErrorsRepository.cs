using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportMonitorBlazor.Models;

namespace SupportMonitorBlazor.Api.Models
{
   public  interface ITmsErrorsRepository
    {
       Task<IEnumerable<TmsErrors>> GetTmsErrorsList();
        Task<IEnumerable<TmsErrors>> GetTmsErrors(int TmsId);
        Task<TmsErrors> AddTmsError(TmsErrors tmsError);
        Task<TmsErrors> UpdateTmsError(TmsErrors tms);
        void DeleteTmsError(int TmsId);
    }
}
