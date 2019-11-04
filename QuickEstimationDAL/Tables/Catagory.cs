using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL
{
    public class Catagory
    {
        public int Id { get; set; }

        [Required]
        public string TaskCategory { get; set; }        
    }  
   
}
