using Microsoft.EntityFrameworkCore;
using SupportMonitorBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportMonitorBlazor.Api.Models
{
    public class appDBContext:DbContext
    {
        public appDBContext(DbContextOptions<appDBContext>options):base(options)
        {
                
        }
        public DbSet<BlazorTMS> BlazorTMS { get; set; }
        public DbSet<TmsErrors> TmsErrors { get; set; }
        public DbSet<SystemValues> SystemValues { get; set; }
        public DbSet<DiskSpace> DiskSpace { get; set; }
        public DbSet<TmsProperties> TmsProperties { get; set; }
        public DbSet<TMS_Services> TMS_Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Lager føste data til DB
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS {
                TmsId = 1,
                Name = "Elkjøp",
                Country = "Norge",
                TmsCategory = "TransFleet",
                CriticalErrors = 1
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 2,
                Name = "Foria",
                Country = "Sverige",
                TmsCategory = "Tdxlog",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 3,
                Name = "LBC Logistik",
                Country = "Sverige",
                TmsCategory = "Tdxlog",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 4,
                Name = "Gigantti OY",
                Country = "Finland",
                TmsCategory = "TransFleet",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 5,
                Name = "DSV",
                Country = "Felles nordisk",
                TmsCategory = "TransFleet",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 6,
                Name = "Gausdal Skurlag",
                Country = "Norsk",
                TmsCategory = "TransFleet",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 7,
                Name = "Brødrene Dahl",
                Country = "Norsk",
                TmsCategory = "TransFleet",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 8,
                Name = "Alvdal Skurlag",
                Country = "Norsk",
                TmsCategory = "TransFleet",
                CriticalErrors = 0
            });
           ;
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 9,
                Name = "Østfold Olje Ragnar Larsen & Sønner",
                Country = "Norsk",
                TmsCategory = "TransFleet",
                CriticalErrors = 1
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 10,
                Name = "Toll",
                Country = "Norsk",
                TmsCategory = "TransFleet",
                CriticalErrors = 0
            });
            modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 11,
                Name = "Wiklunds",
                Country = "Sverige",
                TmsCategory = "Tdxlog",
                CriticalErrors = 0
            }); modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 12,
                Name = "LBC Logistik",
                Country = "Sverige",
                TmsCategory = "Tdxlog",
                CriticalErrors = 0
            }); modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 13,
                Name = "LBC Tingsryd",
                Country = "Sverige",
                TmsCategory = "Tdxlog",

                CriticalErrors = 0
            }); modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 14,
                Name = "Örnfrakt",
                Country = "Sverige",
                TmsCategory = "Tdxlog",
                CriticalErrors = 1
            }) ; modelBuilder.Entity<BlazorTMS>().HasData(new BlazorTMS
            {
                TmsId = 15,
                Name = "Fraktkedjan Anläggning AB",
                Country = "Sverige",
                TmsCategory = "Tdxlog",
                CriticalErrors = 0
            });
            ; modelBuilder.Entity<TmsErrors>().HasData(new TmsErrors
            {
                TmsErrorId=2,
                  TMSid =2,
        ErrorInformation= "Fatal Program feil" ,       
         SystemFunction = "ImportEksport datafeil",
         ErrorDetail = "TdxExt feil detektert  2021-06-22 07:05",
        RequiredAction = "Hent ut detalj logger fra Ext-en og send til utvikler"

    });
            modelBuilder.Entity<TmsErrors>().HasData(new TmsErrors
            {
                TmsErrorId=1,
                TMSid = 11,
                ErrorInformation = "ImportEksport har stoppet",
                SystemFunction = "ImportEksport",
                ErrorDetail = "TdxExt har stoppet 2021-06-22 07:05",
                RequiredAction = "Logg inn på Wicklunds server og restart TdxLogContoller tjenestene"

            });

            modelBuilder.Entity<SystemValues>().HasData(new SystemValues
            {
                Id=3,
                 SystemName = "PROGRAM_RUNNING",
                 SystemValue = "CRASH"

            });
            modelBuilder.Entity<SystemValues>().HasData(new SystemValues
            {
                Id=1,
                SystemName = "NETWORK",
                SystemValue = "OK"

            });
            modelBuilder.Entity<SystemValues>().HasData(new SystemValues
            {
                Id=2,
                SystemName = "MOBILE",
                SystemValue = "OK"

            });

            //Diskspace

            modelBuilder.Entity<DiskSpace>().HasData(new DiskSpace
            {
                Id = 1,
             
        
       TmsId =2,
        Name ="E",
        Type ="Local Disk",
       FreespacePercentMinimum =5,
       FrespaceMinimumBytes =5000,
         Actualsize =9999,
        MaxSize=10000
        

        });
            modelBuilder.Entity<TmsProperties>().HasData(new TmsProperties
            {
                Id = 1,


                TmsId = 6,
                Name = "TransFleet WebApi",
                Value= "http://tms.gaus.no:31003/docs/"



            });
            /* modelBuilder.Entity<DiskSpace>().HasData(new DiskSpace
             {
                 Id = 1,


                 TmsId = 3,
                 Name = "C",
                 Type = "Local Disk",
                 FreespacePercentMinimum = 20,
                 FrespaceMinimumBytes = 8000,
                 Actualsize = 600,
                 MaxSize = 10000


             });*/
             modelBuilder.Entity<TMS_Services>().HasData(new TMS_Services
             {
                Id = 1,
                Name="Test",
                DisplayName="Teast",
             //RunningSince= "2021 - 06 - 18 07:54:26.2000000"


                


            });



        }
    }
}
