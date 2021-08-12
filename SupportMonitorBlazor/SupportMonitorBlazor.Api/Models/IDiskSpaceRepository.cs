using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public interface IDiskSpaceRepository
    {
        Task<IEnumerable<DiskSpace>> GetDiskSpaceList();
        Task<IEnumerable<DiskSpace>> GetTmsDiskSpace(int TmsId);
        Task<DiskSpace> GetOneTmsDiskSpace(int id);
        Task<DiskSpace> AddTmsDiskSpace(DiskSpace DiskSpace);
        Task<DiskSpace> UpdateTmsDiskSpace(DiskSpace space);
        void DeleteTmsDiskSpace(int TmsId);

    }
}
