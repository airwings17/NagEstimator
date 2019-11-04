using QuickEstimationDAL;
using QuickEstimationDAL.Tables;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QuickEstimatorAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EstimationController : ApiController
    {
        //use this api to get all categories
        [System.Web.Mvc.Route("Categories")]
        public List<Catagory> GetCategories()
        {
            EstimationOperations estOperation = new EstimationOperations();
            return estOperation.GetCategories();
        }
        [HttpPost]
        [System.Web.Mvc.Route("SavePhasedEstimates")]
        public bool SavePhasedEstimates(PhasedEstimateDto phasedEstimateDto)
        {
            int estimateVersionID = SavePhasedEstimateVersion(phasedEstimateDto.estimateVersion);

            //Save data after updating the version.
            foreach (VersionDetails_Phased version in phasedEstimateDto.versinDetailsPhased )
            {
                version.VersionID = estimateVersionID;
            }
         
            SavePhasedEstimateVersionDetails(phasedEstimateDto.versinDetailsPhased);

            //Save assumptions 
            foreach (Assumptions assumption in phasedEstimateDto.assumptions)
            {
                assumption.VersionID = estimateVersionID;
            }

            SaveAssumptions(phasedEstimateDto.assumptions);

            //save In-Scope 
            foreach (InScope inScope in phasedEstimateDto.inScope)
            {
                inScope.VersionID = estimateVersionID;
            }
            SaveInScope(phasedEstimateDto.inScope);

            //Save Out-Scope 
            foreach (OutScope outScope in phasedEstimateDto.outScope)
            {
                outScope.VersionID = estimateVersionID;
            }
            SaveOutScope(phasedEstimateDto.outScope);

            return true;

        }


        private int SavePhasedEstimateVersion(EstimationVersionsHistory estimateversion)
        {
            EstimationOperations  qDal = new EstimationOperations();
            return qDal.SaveEstimateVersion(estimateversion);           
        }

        private bool SavePhasedEstimateVersionDetails(List<VersionDetails_Phased> estimateVersionDetail)
        {
            EstimationOperations qDal = new EstimationOperations();
            qDal.SaveEstimateVersionDetails(estimateVersionDetail);
            return true;
        }
        private bool SaveAssumptions(List<Assumptions> assumptions)
        {

            EstimationOperations qDal = new EstimationOperations();
            qDal.SaveAsumptions(assumptions);
            return true;
        }

        private bool SaveInScope(List<InScope> inscopeItems)
        {
            EstimationOperations qDal = new EstimationOperations();
            qDal.SaveInScope(inscopeItems);
            return true;
        }
        private bool SaveOutScope(List<OutScope> outScopeItems)
        {
            EstimationOperations qDal = new EstimationOperations();
            qDal.SaveOutScope(outScopeItems);
            return true;
        }
    }
}
