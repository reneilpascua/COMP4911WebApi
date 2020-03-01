﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COMP4911WebAPI.Models
{
    public class WorkPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //unnecessary
        public int WorkPackageId { get; set; }  //internal id

        [Required]
        public int ProjectId { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int ResponsibleEngineerId { get; set; }  // not a relation

        [Required]
        public string WorkPackageCode { get; set; } //this is the frontend id 

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public double? ProposedHours { get; set; }

        public double? BudgetHours { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime IssueDate { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        [ForeignKey("ParentWorkPackage")]
        public int? ParentWorkPackageId { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        public WorkPackage ParentWorkPackage { get; set; }
        public IList<WorkPackage> ChildrenWorkPackages { get; set; }
        public Project Project { get; set; }
        public IList<TimesheetRow> TimesheetRows { get; set; }
        public IList<EmployeeWorkPackageAssignment> EmployeeWorkPackageAssignments { get; set; }

        public WorkPackage()
        {

        }

        //For seeding
        public WorkPackage(int wpId, int projId, int responsibleEngineerId, string code, string name, string description, 
            DateTime issueDate, bool isClosed, double? proposedHours, double? budgetHours, int? parentWorkPackageId)
        {
            this.WorkPackageId = wpId;
            this.ProjectId = projId;
            this.ResponsibleEngineerId = responsibleEngineerId;
            this.WorkPackageCode = code;
            this.Name = name;
            this.Description = description;
            this.IssueDate = issueDate;
            this.IsClosed = isClosed;
            this.ProposedHours = proposedHours;
            this.BudgetHours = budgetHours;
            this.ParentWorkPackageId = parentWorkPackageId;

            this.LastUpdatedTime = DateTime.Now;
            this.LastUpdatedBy = "Seeded";
        }
    }
}
