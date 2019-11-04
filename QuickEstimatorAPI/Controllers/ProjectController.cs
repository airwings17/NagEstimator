using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using QuickEstimationDAL;
namespace QuickEstimatorAPI
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProjectController : ApiController
    {
        //use this api to get all projects
        // GET api/project
        public List<Project> Get()
        {
            ProjectOperations projectOperation = new ProjectOperations();
            return projectOperation.GetProject(-1);
        }
      
        // GET api/project/5
        public Project Get(int id)
        {
            ProjectOperations projectOperation = new ProjectOperations();
            return projectOperation.GetProject(id).FirstOrDefault();           
        }        
        

        public string Post(IEnumerable<Project> projects)
        {
            ProjectOperations projectOperation = new ProjectOperations();
            projectOperation.InsertProjects(projects);

            return projects != null ? "0" : projects.Count().ToString();
        }

        ////[HttpPost]
        //[ActionName("addProject")]
        //// POST api/project
        //public string addProject([FromBody] List<string> projects)
        //{
        //    int count = -1;
        //    try
        //    {
        //        count = projects.Count;
        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //    return "Count:" + count;
        //    // ProjectOperations projectOperation = new ProjectOperations();
        //    //projectOperation.InSertProjects(null);
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
