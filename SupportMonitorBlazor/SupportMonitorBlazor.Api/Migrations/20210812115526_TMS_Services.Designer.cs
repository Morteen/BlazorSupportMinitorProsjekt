﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupportMonitorBlazor.Api.Models;

namespace SupportMonitorBlazor.Api.Migrations
{
    [DbContext(typeof(appDBContext))]
    [Migration("20210812115526_TMS_Services")]
    partial class TMS_Services
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SupportMonitorBlazor.Models.BlazorTMS", b =>
                {
                    b.Property<int>("TmsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CriticalErrors")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TmsCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TmsId");

                    b.ToTable("BlazorTMS");

                    b.HasData(
                        new
                        {
                            TmsId = 1,
                            Country = "Norge",
                            CriticalErrors = 1,
                            Name = "Elkjøp",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 2,
                            Country = "Sverige",
                            CriticalErrors = 0,
                            Name = "Foria",
                            TmsCategory = "Tdxlog"
                        },
                        new
                        {
                            TmsId = 3,
                            Country = "Sverige",
                            CriticalErrors = 0,
                            Name = "LBC Logistik",
                            TmsCategory = "Tdxlog"
                        },
                        new
                        {
                            TmsId = 4,
                            Country = "Finland",
                            CriticalErrors = 0,
                            Name = "Gigantti OY",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 5,
                            Country = "Felles nordisk",
                            CriticalErrors = 0,
                            Name = "DSV",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 6,
                            Country = "Norsk",
                            CriticalErrors = 0,
                            Name = "Gausdal Skurlag",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 7,
                            Country = "Norsk",
                            CriticalErrors = 0,
                            Name = "Brødrene Dahl",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 8,
                            Country = "Norsk",
                            CriticalErrors = 0,
                            Name = "Alvdal Skurlag",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 9,
                            Country = "Norsk",
                            CriticalErrors = 1,
                            Name = "Østfold Olje Ragnar Larsen & Sønner",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 10,
                            Country = "Norsk",
                            CriticalErrors = 0,
                            Name = "Toll",
                            TmsCategory = "TransFleet"
                        },
                        new
                        {
                            TmsId = 11,
                            Country = "Sverige",
                            CriticalErrors = 0,
                            Name = "Wiklunds",
                            TmsCategory = "Tdxlog"
                        },
                        new
                        {
                            TmsId = 12,
                            Country = "Sverige",
                            CriticalErrors = 0,
                            Name = "LBC Logistik",
                            TmsCategory = "Tdxlog"
                        },
                        new
                        {
                            TmsId = 13,
                            Country = "Sverige",
                            CriticalErrors = 0,
                            Name = "LBC Tingsryd",
                            TmsCategory = "Tdxlog"
                        },
                        new
                        {
                            TmsId = 14,
                            Country = "Sverige",
                            CriticalErrors = 1,
                            Name = "Örnfrakt",
                            TmsCategory = "Tdxlog"
                        },
                        new
                        {
                            TmsId = 15,
                            Country = "Sverige",
                            CriticalErrors = 0,
                            Name = "Fraktkedjan Anläggning AB",
                            TmsCategory = "Tdxlog"
                        });
                });

            modelBuilder.Entity("SupportMonitorBlazor.Models.DiskSpace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Actualsize")
                        .HasColumnType("int");

                    b.Property<int>("FreespacePercentMinimum")
                        .HasColumnType("int");

                    b.Property<int>("FrespaceMinimumBytes")
                        .HasColumnType("int");

                    b.Property<int>("MaxSize")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TmsId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiskSpace");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Actualsize = 9999,
                            FreespacePercentMinimum = 5,
                            FrespaceMinimumBytes = 5000,
                            MaxSize = 10000,
                            Name = "E",
                            TmsId = 2,
                            Type = "Local Disk"
                        });
                });

            modelBuilder.Entity("SupportMonitorBlazor.Models.SystemValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SystemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemValues");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            SystemName = "PROGRAM_RUNNING",
                            SystemValue = "CRASH"
                        },
                        new
                        {
                            Id = 1,
                            SystemName = "NETWORK",
                            SystemValue = "OK"
                        },
                        new
                        {
                            Id = 2,
                            SystemName = "MOBILE",
                            SystemValue = "OK"
                        });
                });

            modelBuilder.Entity("SupportMonitorBlazor.Models.TmsErrors", b =>
                {
                    b.Property<int>("TmsErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ErrorDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequiredAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemFunction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TMSid")
                        .HasColumnType("int");

                    b.HasKey("TmsErrorId");

                    b.ToTable("TmsErrors");

                    b.HasData(
                        new
                        {
                            TmsErrorId = 2,
                            ErrorDetail = "TdxExt feil detektert  2021-06-22 07:05",
                            ErrorInformation = "Fatal Program feil",
                            RequiredAction = "Hent ut detalj logger fra Ext-en og send til utvikler",
                            SystemFunction = "ImportEksport datafeil",
                            TMSid = 2
                        },
                        new
                        {
                            TmsErrorId = 1,
                            ErrorDetail = "TdxExt har stoppet 2021-06-22 07:05",
                            ErrorInformation = "ImportEksport har stoppet",
                            RequiredAction = "Logg inn på Wicklunds server og restart TdxLogContoller tjenestene",
                            SystemFunction = "ImportEksport",
                            TMSid = 11
                        });
                });

            modelBuilder.Entity("SupportMonitorBlazor.Models.TmsProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TmsId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TmsProperties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "TransFleet WebApi",
                            TmsId = 6,
                            Value = "http://tms.gaus.no:31003/docs/"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
