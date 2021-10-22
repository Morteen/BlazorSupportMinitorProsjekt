using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class UsersRepository : IUsersRepository
    {

         private readonly appDBContext dBContext;


         public UsersRepository(appDBContext dBContext)
         {
             this.dBContext = dBContext;
         }



          public async Task<IEnumerable<TmsUser>> GetUserList()
          {
            return await dBContext.TmsUsers.ToListAsync();
        }

        public Task<TmsUser> AddUser(TmsUser user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userid)
        {
            throw new NotImplementedException();
        }

        public async Task<TmsUser> GetUser(int userid)
        {
            return await dBContext.TmsUsers.FirstOrDefaultAsync(u => u.Id == userid);
        }

     

        public Task<IEnumerable<TmsUser>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task<TmsUser> UpdateTms(TmsUser user)
        {
            throw new NotImplementedException();
        }

        public async Task<TmsUser> LoginUser(string username,string password)
        {
            return await dBContext.TmsUsers.FirstOrDefaultAsync(u => u.Username == username && u.Password==password);
        }
    }
}
