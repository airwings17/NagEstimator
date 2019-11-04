using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
namespace QuickEstimationDAL
{
    public class ProjectOperations
    {
        //[HttpPost]
        public void InsertProjects(IEnumerable<Project> projects)
        {
            try
            {
                using (Estimator dbContext = new Estimator())
                {
                    foreach (Project proj in projects)
                    {
                        if (proj.Id != 0)
                        {
                            var existingProject = dbContext.Projects.Find(proj.Id);
                           
                            DbEntityEntry<Project> ee = dbContext.Entry(existingProject);
                            ee.CurrentValues.SetValues(proj);
                        }
                        else
                        {
                            //dbContext.Projects.AddRange(projects);
                            dbContext.Projects.Add(proj);
                        }
                        dbContext.SaveChanges();
                    }
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

        }

        public List<Project> GetProject(int id)
        {
            List<Project> objProj = new List<Project>();
            try
            {

                using (Estimator dbContext = new Estimator())
                {
                    if (id > 0)
                    {
                        Project proj = dbContext.Projects.Find(id);
                        dbContext.SaveChanges();
                        objProj.Add(proj);
                    }
                    else
                    {
                        dbContext.SaveChanges();
                        objProj.AddRange(dbContext.Projects.ToList());
                       
                    }                   
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
            return objProj;
        }


    }
}
