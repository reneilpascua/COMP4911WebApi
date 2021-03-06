﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMP4911WebAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobTitleName = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "LabourGrades",
                columns: table => new
                {
                    LabourGradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabourGradeCode = table.Column<string>(nullable: true),
                    HourlyWage = table.Column<double>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabourGrades", x => x.LabourGradeId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectReport",
                columns: table => new
                {
                    ProjectReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    ProjectCode = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReport", x => x.ProjectReportId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectCode = table.Column<int>(nullable: false),
                    ProjectName = table.Column<string>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: false),
                    Budget = table.Column<double>(nullable: false),
                    ProjectManagerId = table.Column<int>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "WorkPackageReportSnapshot",
                columns: table => new
                {
                    WorkPackageReportSnapshotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkPackageId = table.Column<int>(nullable: false),
                    ProjectReportId = table.Column<int>(nullable: false),
                    WorkPackageCode = table.Column<string>(nullable: true),
                    WorkPackageTitle = table.Column<string>(nullable: true),
                    WorkPackageResponsibleEngineerBudget = table.Column<double>(nullable: false),
                    WorkPackageActualSpends = table.Column<double>(nullable: false),
                    WorkPackageResponsibleEngineerEstimateAtCompletion = table.Column<double>(nullable: false),
                    WorkPackageProjectManagerEstimateAtCompletion = table.Column<double>(nullable: false),
                    IsHighWorkPackage = table.Column<bool>(nullable: false),
                    WorkPackageReportSnapshotDate = table.Column<DateTime>(nullable: false),
                    WpReVariance = table.Column<double>(nullable: false),
                    WpPmVariance = table.Column<double>(nullable: false),
                    WpReCompletion = table.Column<double>(nullable: false),
                    WpPmCompletion = table.Column<double>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    EngineerInitials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackageReportSnapshot", x => x.WorkPackageReportSnapshotId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobTitleId = table.Column<int>(nullable: false),
                    LabourGradeId = table.Column<int>(nullable: false),
                    EmployeeCode = table.Column<int>(nullable: false),
                    EmployeeFirstName = table.Column<string>(nullable: false),
                    EmployeeLastName = table.Column<string>(nullable: false),
                    IsActivated = table.Column<bool>(nullable: false),
                    TimesheetApproverId = table.Column<int>(nullable: true),
                    SupervisorId = table.Column<int>(nullable: true),
                    IsProjectManager = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsHumanResources = table.Column<bool>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false),
                    LabourGradeId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_LabourGrades_LabourGradeId",
                        column: x => x.LabourGradeId,
                        principalTable: "LabourGrades",
                        principalColumn: "LabourGradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_LabourGrades_LabourGradeId1",
                        column: x => x.LabourGradeId1,
                        principalTable: "LabourGrades",
                        principalColumn: "LabourGradeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_TimesheetApproverId",
                        column: x => x.TimesheetApproverId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPackages",
                columns: table => new
                {
                    WorkPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    ResponsibleEngineerId = table.Column<int>(nullable: false),
                    WorkPackageCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Contractor = table.Column<string>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    IsClosed = table.Column<bool>(nullable: false),
                    ParentWorkPackageId = table.Column<int>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackages", x => x.WorkPackageId);
                    table.ForeignKey(
                        name: "FK_WorkPackages_WorkPackages_ParentWorkPackageId",
                        column: x => x.ParentWorkPackageId,
                        principalTable: "WorkPackages",
                        principalColumn: "WorkPackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPackages_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    CredentialId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.CredentialId);
                    table.ForeignKey(
                        name: "FK_Credentials_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjectAssignments",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    IsProjectManager = table.Column<bool>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjectAssignments", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProjectAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjectAssignments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timesheets",
                columns: table => new
                {
                    TimesheetId = table.Column<int>(nullable: false),
                    VersionNumber = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    WeekNumber = table.Column<int>(nullable: false),
                    WeekEndingIn = table.Column<DateTime>(nullable: false),
                    FlexTime = table.Column<double>(nullable: false),
                    OverTime = table.Column<double>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheets", x => new { x.TimesheetId, x.VersionNumber });
                    table.ForeignKey(
                        name: "FK_Timesheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkPackageAssignments",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    WorkPackageId = table.Column<int>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkPackageAssignments", x => new { x.EmployeeId, x.WorkPackageId });
                    table.ForeignKey(
                        name: "FK_EmployeeWorkPackageAssignments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkPackageAssignments_WorkPackages_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "WorkPackages",
                        principalColumn: "WorkPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPackageLabourGradeAssignment",
                columns: table => new
                {
                    WorkPackageId = table.Column<int>(nullable: false),
                    LabourGradeId = table.Column<int>(nullable: false),
                    pmEAC = table.Column<double>(nullable: true),
                    reBudget = table.Column<double>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackageLabourGradeAssignment", x => new { x.WorkPackageId, x.LabourGradeId });
                    table.ForeignKey(
                        name: "FK_WorkPackageLabourGradeAssignment_LabourGrades_LabourGradeId",
                        column: x => x.LabourGradeId,
                        principalTable: "LabourGrades",
                        principalColumn: "LabourGradeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkPackageLabourGradeAssignment_WorkPackages_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "WorkPackages",
                        principalColumn: "WorkPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPackageReports",
                columns: table => new
                {
                    WorkPackageReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkPackageId = table.Column<int>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    WorkAccomplished = table.Column<string>(nullable: true),
                    WorkPlanned = table.Column<string>(nullable: true),
                    ProblemsThisPeriod = table.Column<string>(nullable: true),
                    ProblemsAnticipated = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackageReports", x => x.WorkPackageReportId);
                    table.ForeignKey(
                        name: "FK_WorkPackageReports_WorkPackages_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "WorkPackages",
                        principalColumn: "WorkPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimesheetRows",
                columns: table => new
                {
                    TimesheetRowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimesheetId = table.Column<int>(nullable: false),
                    TimesheetVersionNumber = table.Column<int>(nullable: false),
                    WorkPackageId = table.Column<int>(nullable: false),
                    Monday = table.Column<double>(nullable: false),
                    Tuesday = table.Column<double>(nullable: false),
                    Wednesday = table.Column<double>(nullable: false),
                    Thursday = table.Column<double>(nullable: false),
                    Friday = table.Column<double>(nullable: false),
                    Saturday = table.Column<double>(nullable: false),
                    Sunday = table.Column<double>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetRows", x => x.TimesheetRowId);
                    table.ForeignKey(
                        name: "FK_TimesheetRows_WorkPackages_WorkPackageId",
                        column: x => x.WorkPackageId,
                        principalTable: "WorkPackages",
                        principalColumn: "WorkPackageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimesheetRows_Timesheets_TimesheetId_TimesheetVersionNumber",
                        columns: x => new { x.TimesheetId, x.TimesheetVersionNumber },
                        principalTable: "Timesheets",
                        principalColumns: new[] { "TimesheetId", "VersionNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkPackageReportDetails",
                columns: table => new
                {
                    WorkPackageReportDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WorkPackageReportId = table.Column<int>(nullable: false),
                    LabourGradeId = table.Column<int>(nullable: false),
                    LabourGradeName = table.Column<string>(nullable: true),
                    ResponsibleEngineerBudgetInDays = table.Column<double>(nullable: false),
                    TotalDays = table.Column<double>(nullable: false),
                    ReEstimateAtCompletion = table.Column<double>(nullable: false),
                    ReEstimateToCompletion = table.Column<double>(nullable: false),
                    VariancePercent = table.Column<double>(nullable: false),
                    CompletionPercent = table.Column<double>(nullable: false),
                    LastUpdatedBy = table.Column<string>(nullable: true),
                    LastUpdatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPackageReportDetails", x => x.WorkPackageReportDetailsId);
                    table.ForeignKey(
                        name: "FK_WorkPackageReportDetails_WorkPackageReports_WorkPackageReportId",
                        column: x => x.WorkPackageReportId,
                        principalTable: "WorkPackageReports",
                        principalColumn: "WorkPackageReportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "JobTitleName", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 1, "Software Developer", "perry", new DateTime(2020, 4, 2, 22, 55, 43, 694, DateTimeKind.Local).AddTicks(3935) },
                    { 2, "Q/A Analyst", "perry", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(2002) },
                    { 3, "Business Analyst", "perry", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(2918) }
                });

            migrationBuilder.InsertData(
                table: "LabourGrades",
                columns: new[] { "LabourGradeId", "HourlyWage", "LabourGradeCode", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 1, 22.0, "P1", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(8149) },
                    { 2, 23.0, "P2", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(9113) },
                    { 3, 10.0, "P3", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(9127) },
                    { 4, 8.0, "P4", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(9131) },
                    { 5, 25.0, "SS", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(9133) },
                    { 6, 35.0, "DD", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 696, DateTimeKind.Local).AddTicks(9136) }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Budget", "EndDate", "IsClosed", "LastUpdatedBy", "LastUpdatedTime", "ProjectCode", "ProjectDescription", "ProjectManagerId", "ProjectName", "StartDate" },
                values: new object[,]
                {
                    { 1, 1337.0, new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(1567), false, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(6161), 111, "NewProjectDescription1", 2, "NewProject1", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(1562) },
                    { 2, 1337.0, new DateTime(2020, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(538), 222, "ProjectDescription3", 2, "ProjectName2", new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1337.0, new DateTime(2020, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(578), 333, "ProjectDescription3", 3, "ProjectName3", new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1337.0, new DateTime(2100, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(591), 123, "Sick Description", 1, "Sick", new DateTime(1900, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1337.0, new DateTime(2100, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(603), 555, "Vacation Description", 1, "Vacation", new DateTime(1900, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeFirstName", "EmployeeLastName", "IsActivated", "IsAdmin", "IsHumanResources", "IsProjectManager", "JobTitleId", "LabourGradeId", "LabourGradeId1", "LastUpdatedBy", "LastUpdatedTime", "SupervisorId", "TimesheetApproverId" },
                values: new object[] { 1, 888, "AdminFirstName", "AdminLastName", true, true, true, true, 1, 1, null, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 697, DateTimeKind.Local).AddTicks(6697), null, null });

            migrationBuilder.InsertData(
                table: "WorkPackages",
                columns: new[] { "WorkPackageId", "Contractor", "Description", "IsClosed", "IssueDate", "LastUpdatedBy", "LastUpdatedTime", "Name", "ParentWorkPackageId", "ProjectId", "ResponsibleEngineerId", "WorkPackageCode" },
                values: new object[,]
                {
                    { 1, null, "WpDescription1Root", false, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(6385), "WpName1Root", null, 1, 2, "A" },
                    { 3, null, "WpDescription2Root", false, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7325), "WpName2Root", null, 2, 3, "B" },
                    { 7, null, "WpDescription3Root", false, new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7360), "WpName3Root", null, 3, 4, "C" },
                    { 9, null, "SickDescription", false, new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7376), "Sick", null, 4, 1, "Sick" },
                    { 10, null, "VacationPackage", false, new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7383), "Vacation", null, 5, 1, "Vacation" }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "CredentialId", "EmployeeId", "LastUpdatedBy", "LastUpdatedTime", "Password", "Salt", "Token" },
                values: new object[] { "A100001", 1, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(711), "clxAHJuzuwNYvKi37h3iC7Vf6Rd1y8WK/ya+UknJYWU=", new byte[] { 32, 126, 115, 157, 245, 171, 224, 103, 253, 251, 46, 39, 81, 149, 52, 36 }, null });

            migrationBuilder.InsertData(
                table: "EmployeeWorkPackageAssignments",
                columns: new[] { "EmployeeId", "WorkPackageId", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[] { 1, 1, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(2002) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeFirstName", "EmployeeLastName", "IsActivated", "IsAdmin", "IsHumanResources", "IsProjectManager", "JobTitleId", "LabourGradeId", "LabourGradeId1", "LastUpdatedBy", "LastUpdatedTime", "SupervisorId", "TimesheetApproverId" },
                values: new object[] { 2, 778, "Perry", "Li", true, false, false, true, 2, 2, null, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 697, DateTimeKind.Local).AddTicks(7242), 1, 1 });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "TimesheetId", "VersionNumber", "Comment", "EmployeeId", "FlexTime", "LastUpdatedBy", "LastUpdatedTime", "OverTime", "Status", "WeekEndingIn", "WeekNumber" },
                values: new object[,]
                {
                    { 7, 1, "seeded comment", 1, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7573), 1.0, 2, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 1, "seeded comment", 1, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7580), 1.0, 3, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 8, 2, "seeded comment", 1, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7601), 1.0, 2, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.InsertData(
                table: "WorkPackageLabourGradeAssignment",
                columns: new[] { "WorkPackageId", "LabourGradeId", "LastUpdatedBy", "LastUpdatedTime", "pmEAC", "reBudget" },
                values: new object[] { 1, 1, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(9963), 10.0, 8.0 });

            migrationBuilder.InsertData(
                table: "WorkPackages",
                columns: new[] { "WorkPackageId", "Contractor", "Description", "IsClosed", "IssueDate", "LastUpdatedBy", "LastUpdatedTime", "Name", "ParentWorkPackageId", "ProjectId", "ResponsibleEngineerId", "WorkPackageCode" },
                values: new object[,]
                {
                    { 2, null, "WpDescription1Child1", false, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7305), "WpName1Child1", 1, 1, 2, "AB" },
                    { 4, null, "WpDescription2Child1", false, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7334), "WpName2Child1", 3, 2, 5, "BA" },
                    { 6, null, "WpDescription2Child2", false, new DateTime(2020, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7351), "WpName2Child2", 3, 2, 5, "BB" },
                    { 8, null, "Hi Ren", false, new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7368), "RenWorkPackage", 7, 3, 1, "CA" }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "CredentialId", "EmployeeId", "LastUpdatedBy", "LastUpdatedTime", "Password", "Salt", "Token" },
                values: new object[] { "A100002", 2, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(1192), "9Xx6MEBJbq35STNLFfhj6qurFGDsnKa5JhWP5u9TXu0=", new byte[] { 175, 19, 33, 140, 108, 231, 124, 94, 169, 45, 155, 167, 185, 205, 149, 132 }, null });

            migrationBuilder.InsertData(
                table: "EmployeeProjectAssignments",
                columns: new[] { "EmployeeId", "ProjectId", "IsProjectManager", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[] { 2, 1, true, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(5282) });

            migrationBuilder.InsertData(
                table: "EmployeeWorkPackageAssignments",
                columns: new[] { "EmployeeId", "WorkPackageId", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 1, 8, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(3418) },
                    { 2, 8, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(4322) },
                    { 1, 2, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(4665) },
                    { 2, 2, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(5602) },
                    { 2, 1, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(679) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeFirstName", "EmployeeLastName", "IsActivated", "IsAdmin", "IsHumanResources", "IsProjectManager", "JobTitleId", "LabourGradeId", "LabourGradeId1", "LastUpdatedBy", "LastUpdatedTime", "SupervisorId", "TimesheetApproverId" },
                values: new object[] { 3, 111, "Bruce", "Link", true, false, false, true, 3, 3, null, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 697, DateTimeKind.Local).AddTicks(7255), 1, 2 });

            migrationBuilder.InsertData(
                table: "TimesheetRows",
                columns: new[] { "TimesheetRowId", "Friday", "LastUpdatedBy", "LastUpdatedTime", "Monday", "Notes", "Saturday", "Sunday", "Thursday", "TimesheetId", "TimesheetVersionNumber", "Tuesday", "Wednesday", "WorkPackageId" },
                values: new object[,]
                {
                    { 7, 1.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5510), 5.0, "forRen", 3.0, 3.0, 8.0, 7, 1, 7.0, 8.0, 1 },
                    { 8, 3.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5513), 6.0, "forRen", 3.0, 3.0, 2.0, 7, 1, 7.0, 5.0, 2 },
                    { 6, 3.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5507), 3.0, "forRen", 3.0, 3.0, 8.0, 7, 1, 3.0, 8.0, 8 }
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "TimesheetId", "VersionNumber", "Comment", "EmployeeId", "FlexTime", "LastUpdatedBy", "LastUpdatedTime", "OverTime", "Status", "WeekEndingIn", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1, "seeded comment", 2, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(5335), 1.0, 2, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 4, 1, "seeded comment", 2, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7550), 1.0, 1, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 }
                });

            migrationBuilder.InsertData(
                table: "WorkPackageLabourGradeAssignment",
                columns: new[] { "WorkPackageId", "LabourGradeId", "LastUpdatedBy", "LastUpdatedTime", "pmEAC", "reBudget" },
                values: new object[,]
                {
                    { 2, 1, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(959), 30.0, 80.0 },
                    { 2, 2, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(973), 55.5, 66.599999999999994 }
                });

            migrationBuilder.InsertData(
                table: "WorkPackageReports",
                columns: new[] { "WorkPackageReportId", "Comment", "EndDate", "LastUpdatedBy", "LastUpdatedTime", "ProblemsAnticipated", "ProblemsThisPeriod", "ReportDate", "StartDate", "WorkAccomplished", "WorkPackageId", "WorkPlanned" },
                values: new object[] { 1, "seeded comment", new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 705, DateTimeKind.Local).AddTicks(1753), "seeded anticipated", "seeded problems", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "seeded stuff", 2, "seeded planned" });

            migrationBuilder.InsertData(
                table: "WorkPackages",
                columns: new[] { "WorkPackageId", "Contractor", "Description", "IsClosed", "IssueDate", "LastUpdatedBy", "LastUpdatedTime", "Name", "ParentWorkPackageId", "ProjectId", "ResponsibleEngineerId", "WorkPackageCode" },
                values: new object[] { 5, null, "WpDescription2ChildChild1", false, new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(7342), "WpName2ChildChild1", 4, 2, 2, "BAA" });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "CredentialId", "EmployeeId", "LastUpdatedBy", "LastUpdatedTime", "Password", "Salt", "Token" },
                values: new object[] { "A100003", 3, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(1205), "2iUM2vznQ8nQqExaRDxZ0DO+xSpIJQryqGYJbO6SycM=", new byte[] { 9, 188, 200, 228, 138, 147, 62, 170, 155, 199, 60, 186, 229, 104, 239, 222 }, null });

            migrationBuilder.InsertData(
                table: "EmployeeProjectAssignments",
                columns: new[] { "EmployeeId", "ProjectId", "IsProjectManager", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 3, 1, false, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(6646) },
                    { 3, 2, true, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(7466) },
                    { 3, 3, false, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(9955) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeWorkPackageAssignments",
                columns: new[] { "EmployeeId", "WorkPackageId", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 2, 5, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(9895) },
                    { 3, 7, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(1648) },
                    { 3, 3, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(6476) },
                    { 3, 8, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(5264) },
                    { 3, 1, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(2827) },
                    { 3, 2, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(3737) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeFirstName", "EmployeeLastName", "IsActivated", "IsAdmin", "IsHumanResources", "IsProjectManager", "JobTitleId", "LabourGradeId", "LabourGradeId1", "LastUpdatedBy", "LastUpdatedTime", "SupervisorId", "TimesheetApproverId" },
                values: new object[,]
                {
                    { 5, 222, "Employee5FirstName", "Employee5LastName", true, false, false, true, 3, 3, null, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 697, DateTimeKind.Local).AddTicks(7262), 3, 3 },
                    { 4, 123, "Employee4FirstName", "Employee4LastName", true, false, false, false, 2, 2, null, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 697, DateTimeKind.Local).AddTicks(7259), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TimesheetRows",
                columns: new[] { "TimesheetRowId", "Friday", "LastUpdatedBy", "LastUpdatedTime", "Monday", "Notes", "Saturday", "Sunday", "Thursday", "TimesheetId", "TimesheetVersionNumber", "Tuesday", "Wednesday", "WorkPackageId" },
                values: new object[,]
                {
                    { 1, 7.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(4455), 3.0, "dota is best", 8.0, 9.0, 6.0, 1, 1, 4.0, 5.0, 2 },
                    { 2, 3.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5477), 3.0, "PIG GOD!!!", 3.0, 3.0, 3.0, 1, 1, 3.0, 3.0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "TimesheetId", "VersionNumber", "Comment", "EmployeeId", "FlexTime", "LastUpdatedBy", "LastUpdatedTime", "OverTime", "Status", "WeekEndingIn", "WeekNumber" },
                values: new object[,]
                {
                    { 2, 1, "seeded comment", 3, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7504), 1.0, 2, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2, 2, "seeded comment", 3, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7534), 1.0, 2, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 3, 1, "seeded comment", 3, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7542), 1.0, 2, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 6, 1, "seeded comment", 3, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7566), 1.0, 2, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 }
                });

            migrationBuilder.InsertData(
                table: "WorkPackageReportDetails",
                columns: new[] { "WorkPackageReportDetailsId", "CompletionPercent", "LabourGradeId", "LabourGradeName", "LastUpdatedBy", "LastUpdatedTime", "ReEstimateAtCompletion", "ReEstimateToCompletion", "ResponsibleEngineerBudgetInDays", "TotalDays", "VariancePercent", "WorkPackageReportId" },
                values: new object[,]
                {
                    { 1, 90.0, 3, "labourgrade3name", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 705, DateTimeKind.Local).AddTicks(8781), 8.0, 21.5, 20.5, 50.0, 30.0, 1 },
                    { 2, 50.0, 4, "labourgrade4name", "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 705, DateTimeKind.Local).AddTicks(9307), 42.0, 42.0, 19.0, 19.5, 50.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkPackageReports",
                columns: new[] { "WorkPackageReportId", "Comment", "EndDate", "LastUpdatedBy", "LastUpdatedTime", "ProblemsAnticipated", "ProblemsThisPeriod", "ReportDate", "StartDate", "WorkAccomplished", "WorkPackageId", "WorkPlanned" },
                values: new object[] { 2, "seeded comment 2", new DateTime(2020, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 705, DateTimeKind.Local).AddTicks(2298), "seeded anticipated 2", "seeded problems2", new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "seeded workaccomplished 2", 5, "seeded workplanned2" });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "CredentialId", "EmployeeId", "LastUpdatedBy", "LastUpdatedTime", "Password", "Salt", "Token" },
                values: new object[,]
                {
                    { "Nezuko", 4, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(1208), "qJWCxfNXeeWJfRDXvUZbYQ78rLB/bvxqEOFfmktYLhA=", new byte[] { 33, 49, 13, 92, 18, 65, 124, 171, 165, 172, 222, 201, 216, 245, 227, 207 }, null },
                    { "Nier", 5, "seeded", new DateTime(2020, 4, 2, 22, 55, 43, 698, DateTimeKind.Local).AddTicks(1211), "GEEhnKgM9Qa8EutlElgi07jPPM+BPAHHn1sgzl1eV/M=", new byte[] { 185, 57, 184, 194, 29, 232, 77, 94, 205, 66, 221, 176, 119, 173, 156, 132 }, null }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjectAssignments",
                columns: new[] { "EmployeeId", "ProjectId", "IsProjectManager", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 4, 3, false, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 700, DateTimeKind.Local).AddTicks(764) },
                    { 5, 2, false, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(8292) },
                    { 5, 3, true, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 699, DateTimeKind.Local).AddTicks(9121) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeWorkPackageAssignments",
                columns: new[] { "EmployeeId", "WorkPackageId", "LastUpdatedBy", "LastUpdatedTime" },
                values: new object[,]
                {
                    { 4, 3, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(7302) },
                    { 4, 7, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(2516) },
                    { 5, 4, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(8191) },
                    { 5, 5, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 701, DateTimeKind.Local).AddTicks(9059) },
                    { 5, 6, "perry", new DateTime(2020, 4, 2, 22, 55, 43, 702, DateTimeKind.Local).AddTicks(801) }
                });

            migrationBuilder.InsertData(
                table: "TimesheetRows",
                columns: new[] { "TimesheetRowId", "Friday", "LastUpdatedBy", "LastUpdatedTime", "Monday", "Notes", "Saturday", "Sunday", "Thursday", "TimesheetId", "TimesheetVersionNumber", "Tuesday", "Wednesday", "WorkPackageId" },
                values: new object[,]
                {
                    { 3, 3.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5497), 3.0, "NEZUKO", 3.0, 3.0, 3.0, 2, 1, 3.0, 3.0, 5 },
                    { 4, 3.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5501), 3.0, "clannad", 3.0, 3.0, 3.0, 2, 2, 3.0, 3.0, 3 },
                    { 5, 3.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 704, DateTimeKind.Local).AddTicks(5504), 3.0, "emp3note", 3.0, 3.0, 8.0, 3, 1, 3.0, 8.0, 7 }
                });

            migrationBuilder.InsertData(
                table: "Timesheets",
                columns: new[] { "TimesheetId", "VersionNumber", "Comment", "EmployeeId", "FlexTime", "LastUpdatedBy", "LastUpdatedTime", "OverTime", "Status", "WeekEndingIn", "WeekNumber" },
                values: new object[] { 5, 1, "seeded comment", 5, 2.0, "Seeded", new DateTime(2020, 4, 2, 22, 55, 43, 703, DateTimeKind.Local).AddTicks(7558), 1.0, 2, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_EmployeeId",
                table: "Credentials",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjectAssignments_ProjectId",
                table: "EmployeeProjectAssignments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LabourGradeId",
                table: "Employees",
                column: "LabourGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LabourGradeId1",
                table: "Employees",
                column: "LabourGradeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorId",
                table: "Employees",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TimesheetApproverId",
                table: "Employees",
                column: "TimesheetApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkPackageAssignments_WorkPackageId",
                table: "EmployeeWorkPackageAssignments",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetRows_WorkPackageId",
                table: "TimesheetRows",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetRows_TimesheetId_TimesheetVersionNumber",
                table: "TimesheetRows",
                columns: new[] { "TimesheetId", "TimesheetVersionNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Timesheets_EmployeeId",
                table: "Timesheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackageLabourGradeAssignment_LabourGradeId",
                table: "WorkPackageLabourGradeAssignment",
                column: "LabourGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackageReportDetails_WorkPackageReportId",
                table: "WorkPackageReportDetails",
                column: "WorkPackageReportId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackageReports_WorkPackageId",
                table: "WorkPackageReports",
                column: "WorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackages_ParentWorkPackageId",
                table: "WorkPackages",
                column: "ParentWorkPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPackages_ProjectId",
                table: "WorkPackages",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "EmployeeProjectAssignments");

            migrationBuilder.DropTable(
                name: "EmployeeWorkPackageAssignments");

            migrationBuilder.DropTable(
                name: "ProjectReport");

            migrationBuilder.DropTable(
                name: "TimesheetRows");

            migrationBuilder.DropTable(
                name: "WorkPackageLabourGradeAssignment");

            migrationBuilder.DropTable(
                name: "WorkPackageReportDetails");

            migrationBuilder.DropTable(
                name: "WorkPackageReportSnapshot");

            migrationBuilder.DropTable(
                name: "Timesheets");

            migrationBuilder.DropTable(
                name: "WorkPackageReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "WorkPackages");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "LabourGrades");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
