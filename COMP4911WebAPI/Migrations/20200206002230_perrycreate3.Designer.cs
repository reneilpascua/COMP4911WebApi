﻿// <auto-generated />
using System;
using COMP4911WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace COMP4911WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200206002230_perrycreate3")]
    partial class perrycreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("COMP4911WebAPI.Models.Credential", b =>
                {
                    b.Property<string>("CredentialId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmployeeId");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<string>("Password");

                    b.Property<byte[]>("Salt");

                    b.Property<string>("Token");

                    b.HasKey("CredentialId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Credentials");

                    b.HasData(
                        new
                        {
                            CredentialId = "A100001",
                            EmployeeId = 1,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 725, DateTimeKind.Local).AddTicks(9489),
                            Password = "j1teXn1I792Zlo0QZnZQUuPXxt2/0Mt4FhFduZKtjVU=",
                            Salt = new byte[] { 122, 68, 16, 182, 198, 43, 140, 145, 48, 136, 158, 74, 190, 233, 44, 169 }
                        },
                        new
                        {
                            CredentialId = "A100002",
                            EmployeeId = 2,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 726, DateTimeKind.Local).AddTicks(907),
                            Password = "lAi+kt2cusVjFP6K5FDqlzB/BQVi3d5h9HwYDmIwEoI=",
                            Salt = new byte[] { 46, 62, 119, 171, 218, 246, 189, 82, 46, 97, 32, 235, 86, 181, 65, 108 }
                        });
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeFirstName");

                    b.Property<string>("EmployeeLastName");

                    b.Property<bool>("IsActivated");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsHumanResources");

                    b.Property<bool>("IsProjectManager");

                    b.Property<int>("JobTitleId");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<int?>("SupervisorId");

                    b.Property<int?>("TimesheetApproverId");

                    b.HasKey("EmployeeId");

                    b.HasIndex("JobTitleId");

                    b.HasIndex("SupervisorId");

                    b.HasIndex("TimesheetApproverId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            EmployeeFirstName = "AdminFirstName",
                            EmployeeLastName = "AdminLastName",
                            IsActivated = true,
                            IsAdmin = true,
                            IsHumanResources = true,
                            IsProjectManager = true,
                            JobTitleId = 1,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 723, DateTimeKind.Local).AddTicks(1244)
                        },
                        new
                        {
                            EmployeeId = 2,
                            EmployeeFirstName = "Perry",
                            EmployeeLastName = "Li",
                            IsActivated = true,
                            IsAdmin = false,
                            IsHumanResources = false,
                            IsProjectManager = true,
                            JobTitleId = 2,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 724, DateTimeKind.Local).AddTicks(6647),
                            SupervisorId = 1,
                            TimesheetApproverId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            EmployeeFirstName = "Bruce",
                            EmployeeLastName = "Link",
                            IsActivated = true,
                            IsAdmin = false,
                            IsHumanResources = false,
                            IsProjectManager = true,
                            JobTitleId = 3,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 724, DateTimeKind.Local).AddTicks(7550),
                            SupervisorId = 1,
                            TimesheetApproverId = 2
                        });
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.EmployeeProjectAssignment", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("ProjectId");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<bool>("isProjectManager");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjectAssignments");

                    b.HasData(
                        new
                        {
                            EmployeeId = 3,
                            ProjectId = 1,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 727, DateTimeKind.Local).AddTicks(292),
                            isProjectManager = true
                        });
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.EmployeeWorkPackageAssignment", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int?>("WorkPackageId");

                    b.Property<int>("ProjectId");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.HasKey("EmployeeId", "WorkPackageId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WorkPackageId", "ProjectId");

                    b.ToTable("EmployeeWorkPackageAssignments");
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.JobTitle", b =>
                {
                    b.Property<int>("JobTitleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobTitleName");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.HasKey("JobTitleId");

                    b.ToTable("JobTitles");

                    b.HasData(
                        new
                        {
                            JobTitleId = 1,
                            JobTitleName = "Software Developer",
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 725, DateTimeKind.Local).AddTicks(2803)
                        },
                        new
                        {
                            JobTitleId = 2,
                            JobTitleName = "Q/A Analyst",
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 725, DateTimeKind.Local).AddTicks(4126)
                        },
                        new
                        {
                            JobTitleId = 3,
                            JobTitleName = "Business Analyst",
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 725, DateTimeKind.Local).AddTicks(4934)
                        });
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<string>("ProjectDescription");

                    b.Property<int>("ProjectManagerId");

                    b.Property<string>("ProjectName");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            LastUpdatedBy = "perry",
                            LastUpdatedTime = new DateTime(2020, 2, 5, 16, 22, 29, 726, DateTimeKind.Local).AddTicks(4151),
                            ProjectDescription = "NewProjectDescription1",
                            ProjectManagerId = 3,
                            ProjectName = "NewProject1"
                        });
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.Timesheet", b =>
                {
                    b.Property<int>("TimesheetId");

                    b.Property<int>("VersionNumber");

                    b.Property<int>("EmployeeId");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<string>("Signature");

                    b.Property<DateTime>("WeekEndingIn");

                    b.Property<int>("WeekNumber");

                    b.HasKey("TimesheetId", "VersionNumber");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Timesheets");
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.TimesheetRow", b =>
                {
                    b.Property<int>("TimesheetRowId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Friday");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<int>("Monday");

                    b.Property<string>("Notes");

                    b.Property<int>("Saturday");

                    b.Property<int>("Sunday");

                    b.Property<int>("Thursday");

                    b.Property<int>("TimesheetId");

                    b.Property<int>("TimesheetVersionNumber");

                    b.Property<int>("Tuesday");

                    b.Property<int>("Wednesday");

                    b.Property<int>("WorkPackageId");

                    b.HasKey("TimesheetRowId");

                    b.HasIndex("TimesheetId", "TimesheetVersionNumber");

                    b.HasIndex("TimesheetId", "WorkPackageId");

                    b.ToTable("TimesheetRows");
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.WorkPackage", b =>
                {
                    b.Property<int>("WorkPackageId");

                    b.Property<int>("ProjectId");

                    b.Property<string>("Activities");

                    b.Property<string>("Contractor");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Inputs");

                    b.Property<string>("LastUpdatedBy");

                    b.Property<DateTime>("LastUpdatedTime");

                    b.Property<string>("Outputs");

                    b.Property<int?>("ParentWorkPackageId");

                    b.Property<string>("Purpose");

                    b.Property<int>("ResponsibleEngineerId");

                    b.Property<DateTime>("StartDate");

                    b.Property<double?>("WorkPackageCost");

                    b.Property<string>("WorkPackageDescription");

                    b.Property<string>("WorkPackageName");

                    b.HasKey("WorkPackageId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ParentWorkPackageId", "ProjectId");

                    b.ToTable("WorkPackages");
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.Credential", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.Employee", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.JobTitle", "JobTitle")
                        .WithMany()
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("COMP4911WebAPI.Models.Employee", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");

                    b.HasOne("COMP4911WebAPI.Models.Employee", "TimesheetApprover")
                        .WithMany()
                        .HasForeignKey("TimesheetApproverId");
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.EmployeeProjectAssignment", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.Employee", "Employee")
                        .WithMany("EmployeeProjectAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("COMP4911WebAPI.Models.Project", "Project")
                        .WithMany("EmployeeProjectAssignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.EmployeeWorkPackageAssignment", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.Employee", "Employee")
                        .WithMany("EmployeeWorkPackageAssignments")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("COMP4911WebAPI.Models.Project")
                        .WithMany("EmployeeWorkPackageAssignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("COMP4911WebAPI.Models.WorkPackage", "WorkPackage")
                        .WithMany("EmployeeWorkPackageAssignments")
                        .HasForeignKey("WorkPackageId", "ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.Timesheet", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.Employee", "Employee")
                        .WithMany("Timesheets")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.TimesheetRow", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.Timesheet", "Timesheet")
                        .WithMany("TimesheetRows")
                        .HasForeignKey("TimesheetId", "TimesheetVersionNumber")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("COMP4911WebAPI.Models.WorkPackage", "WorkPackage")
                        .WithMany("TimesheetRows")
                        .HasForeignKey("TimesheetId", "WorkPackageId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("COMP4911WebAPI.Models.WorkPackage", b =>
                {
                    b.HasOne("COMP4911WebAPI.Models.Project", "Project")
                        .WithMany("WorkPackages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("COMP4911WebAPI.Models.WorkPackage", "ParentWorkPackage")
                        .WithMany("ChildrenWorkPackages")
                        .HasForeignKey("ParentWorkPackageId", "ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
