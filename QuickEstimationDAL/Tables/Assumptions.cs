using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL
{
    public class Assumptions
    {

        public int Id { get; set; }
        public int VersionID { get; set; }
        [ForeignKey("VersionID")]
        public EstimationVersionsHistory EstimationVersionsHistory { get; set; }
        [Required]
        public string Assumption { get; set; }
       
    }
}
