using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public interface IBlazorTmsRepository
    {
        Task<IEnumerable<BlazorTMS>> GetTmsList();
        Task<IEnumerable<BlazorTMS>> Search(string name);
        Task<BlazorTMS> GetTms(int TmsId);
        Task<BlazorTMS> AddTms(BlazorTMS tms);
        Task<BlazorTMS> UpdateTms(BlazorTMS tms);
        void DeleteBlazorTms(int TmsId);
    }
}
