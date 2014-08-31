using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CodeMeter.HttpService.Models;

namespace CodeMeter.HttpService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProjectsController : ApiController
    {
        public IList<Project> Get()
        {
            return new List<Project>()
            {
                new Project(){ID = 1, Guid = Guid.NewGuid(), Name = "Demo", Description = "Bla bla bla"},
                new Project(){ID = 2, Guid = Guid.NewGuid(), Name = "Test"},
                new Project(){ID = 3, Guid = Guid.NewGuid(), Name = "Nineks"},
                new Project(){ID = 4, Guid = Guid.NewGuid(), Name = "Agava"},
            };
        } 

        public Project Get(int id)
        {
            return new Project() {ID = id, Guid = Guid.NewGuid(), Name = "Demo"};
        }

        public HttpResponseMessage Post(HttpRequestMessage request, Project project)
        {
            var response = request.CreateResponse(HttpStatusCode.Created, project.ID);
            return response;
        }

        public void Put(Project project)
        {
            
        }

        public void Delete(int id)
        {
            
        }
    }
}
