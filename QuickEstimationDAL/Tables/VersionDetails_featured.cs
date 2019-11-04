using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL
{
    public class VersionDetails_Featured
    {

        public int Id { get; set; }
        public int VersionID { get; set; }
        [ForeignKey("VersionID")]
        public EstimationVersionsHistory EstimationVersionsHistory { get; set; }
        [Required]
        public string Task { get; set; }
        public string SubTask { get; set; }
        public float? Time_Requirement { get; set; }
        public float? Time_Design { get; set; }
        public float? Time_UX { get; set; }
        public float? Time_Development { get; set; }
        public float? Time_Testing { get; set; }
        public float? Time_Deployment { get; set; }
        public float? TotalEfforts { get; set; }
        public float? TotalCost { get; set; }
        public string Comments { get; set; }
    }
}
