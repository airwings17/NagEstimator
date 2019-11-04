using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }
        public string projectUrlName { get; set; }
        public string Manager { get; set; }
        public float? CostPerhr { get; set; }
        public string Team { get; set; }
        public string EmailLink { get; set; }
        public string SketchLink { get; set; }
        public string JiraLink { get; set; }
        public bool? TechnicalApproachNeeded { get; set; }
        public bool? EnvtSetupAndRampupNeeded { get; set; }
        public bool? BrowserTestingNeeded { get; set; }
        public bool? DeviceTestingNeeded { get; set; }
        public bool? PerformanceTestingNeeded { get; set; }
        public bool? AutomationTestingNeeded { get; set; }
        public bool? RegressionTestingNeeded { get; set; }
        public bool? ReleaseDocumentNeeded { get; set; }
        public bool? UATSupportNeeded { get; set; }
        public bool? WarrantySupportNeeded { get; set; }
        public bool? AdminGuideNeeded { get; set; }
        public bool? UserGuideNeeded { get; set; }
        public float? PMEffortsinPercentage { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
      

    }
}
