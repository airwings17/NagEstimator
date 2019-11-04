using EntityFramework.BulkInsert.Extensions;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
namespace QuickEstimationDAL
{
    public class EstimationOperations
    {

        public List<Catagory> GetCategories()
        {
            List<Catagory> objCategories = new List<Catagory>();
            try
            {

                using (Estimator dbContext = new Estimator())
                {
                    objCategories = dbContext.Catogories.ToList();
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join(";", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
            }
            return objCategories;
        }
        public int SaveEstimateVersion(EstimationVersionsHistory estimateversion)
        {
            int versionHistoryID = -1;
            EstimationOperations estOperation = new EstimationOperations();
            using (Estimator dbContext = new Estimator())
            {
                if (estimateversion.Id != 0)
                {
                    var existingversionHistory = dbContext.VersionHistory.Find(estimateversion.Id);
                    DbEntityEntry<EstimationVersionsHistory> ee = dbContext.Entry(existingversionHistory);
                    ee.CurrentValues.SetValues(estimateversion);
                }
                else
                {
                    //dbContext.Projects.AddRange(projects);
                    dbContext.VersionHistory.Add(estimateversion);
                }
                dbContext.SaveChanges();
                versionHistoryID  = estimateversion.Id;
            }

            return versionHistoryID;//estOperation.GetCategories();
        }
        public void  SaveEstimateVersionDetails(List<VersionDetails_Phased> estimateVersionDetail)
        {
            using (Estimator dbContext = new Estimator())
            {
                dbContext.BulkInsert(estimateVersionDetail);
                dbContext.SaveChanges();              
            }          
        }

        public void SaveAsumptions(List<Assumptions> assumptions)
        {
            using (Estimator dbContext = new Estimator())
            {
                dbContext.BulkInsert(assumptions);
                dbContext.SaveChanges();
            }
        }
        public void SaveInScope(List<InScope> inScopeItems)
        {
            using (Estimator dbContext = new Estimator())
            {
                dbContext.BulkInsert(inScopeItems);
                dbContext.SaveChanges();
            }
        }
        public void SaveOutScope(List<OutScope> outScopeItems)
        {
            using (Estimator dbContext = new Estimator())
            {
                dbContext.BulkInsert(outScopeItems);
                dbContext.SaveChanges();
            }
        }       
    }
}
