using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportMonitorBlazor.Models;

namespace SupportMonitorBlazor.Api.Models
{
    public interface IUsersRepository
    {
        Task<IEnumerable<TmsUser>> GetUserList();
        Task<IEnumerable<TmsUser>> Search(string name);
        Task<TmsUser> GetUser(int userid);
        Task<TmsUser> LoginUser(string username,string password);
        Task<TmsUser> AddUser(TmsUser user);
        Task<TmsUser> UpdateTms(TmsUser user);
        void DeleteUser(int userid);
    }
}
