using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL
{
    public class VersionDetails_Phased
    {
        public int Id { get; set; }
        public int VersionID { get; set; }
        [ForeignKey("VersionID")]
        public EstimationVersionsHistory EstimationVersionsHistory { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        [Required]
        public Catagory Catagory { get; set; }
        [Required]
        public string Task { get; set; }
        public string SubTask { get; set; }       
        public float? Time { get; set; }
        public int? NoOfItems { get; set; }
        public float? TotalEfforts { get; set; }
        public float? TotalCost { get; set; }
        public string Comments { get; set; }
    }
}
