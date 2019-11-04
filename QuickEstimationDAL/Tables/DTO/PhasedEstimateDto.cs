using System.Collections.Generic;

namespace QuickEstimationDAL.Tables
{
    public class PhasedEstimateDto
    {
        public EstimationVersionsHistory estimateVersion { get; set; }
        public List<VersionDetails_Phased> versinDetailsPhased { get; set; }
        public List<Assumptions> assumptions { get; set; }
        public List<InScope> inScope { get; set; }
        public List<OutScope> outScope { get; set; }
    }
}

