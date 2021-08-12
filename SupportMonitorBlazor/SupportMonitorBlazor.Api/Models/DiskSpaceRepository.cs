﻿using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class DiskSpaceRepository : IDiskSpaceRepository
    {

        private readonly appDBContext dBContext;


        public DiskSpaceRepository(appDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<IEnumerable<DiskSpace>> GetDiskSpaceList()
        {
            return await dBContext.DiskSpace.ToListAsync();
        }

        public async Task<DiskSpace> GetOneTmsDiskSpace(int Id)
        {
            return await dBContext.DiskSpace.FirstOrDefaultAsync(s => s.Id == Id);
        }



        public async Task<IEnumerable<DiskSpace>> GetTmsDiskSpace(int TmsId)
        {
            return await dBContext.DiskSpace.Where(s => s.TmsId == TmsId).ToListAsync();
        }


        public async Task<DiskSpace> AddTmsDiskSpace(DiskSpace diskSpace)
        {
            var result = await dBContext.DiskSpace.AddAsync(diskSpace);
            await dBContext.SaveChangesAsync();
            return result.Entity;
        }



        public void DeleteTmsDiskSpace(int TmsId)
        {
            throw new NotImplementedException();
        }

       
       

        public async Task<DiskSpace> UpdateTmsDiskSpace(DiskSpace space)
        {

          

            var result = await dBContext.DiskSpace.FirstOrDefaultAsync(d => d.Id == space.Id);
            if (result != null)
            {
                result.Name = space.Name;
                result.TmsId = space.TmsId;
                result.Type = space.Type;
                result.Actualsize = space.Actualsize;
                result.FreespacePercentMinimum = space.FreespacePercentMinimum;
                result.FrespaceMinimumBytes = space.FrespaceMinimumBytes;
                result.MaxSize = space.MaxSize;

                await dBContext.SaveChangesAsync();
                return result;
            }
          
            return null;
        }
    }
}
