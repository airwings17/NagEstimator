using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEstimationDAL.Tables
{
    public class FeaturedEstimateDto
    {
        public EstimationVersionsHistory estimateVersion { get; set; }
        public List<VersionDetails_Featured> versinDetailsFeatured { get; set; }
        public List<Assumptions> assumptions { get; set; }
        public List<InScope> inScope { get; set; }
        public List<OutScope> outScope { get; set; }
    }
}
