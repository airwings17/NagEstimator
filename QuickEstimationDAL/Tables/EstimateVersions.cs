using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL
{
    public class EstimationVersionsHistory
    {

        public int Id { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }       
        public Project Project { get; set; }
        public string EstimationType { get; set; }
        [Required]
        public string VersionSummary { get; set; }

        public float? Estimates { get; set; }
        public float? Cost { get; set; }
        public float? CustomerSharedEstimates { get; set; }
        public float? CustomerSharedCost { get; set; }
        public DateTime? EstimationDate { get; set; }
        public float? PMEfforts { get; set; }
        public bool IsApproved { get; set; }
        public string EstimatedBy { get; set; }
        public string ReviewedBy { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
