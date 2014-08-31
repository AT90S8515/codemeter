using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (var c = new DataContext())
            {
                return c.Projects.ToArray();
            }
        } 

        public Project Get(int id)
        {
            using (var c = new DataContext())
            {
                return c.Projects.Single(x => x.ID == id);
            }
        }

        public HttpResponseMessage Post(HttpRequestMessage request, Project project)
        {
            using (var c = new DataContext())
            {
                project.Guid = Guid.NewGuid();
                c.Projects.Add(project);
                c.SaveChanges();
            }
            var response = request.CreateResponse(HttpStatusCode.Created, project.ID);
            return response;
        }

        public void Put(Project project)
        {
            using (var c = new DataContext())
            {
                c.Entry(project).State = EntityState.Modified;
                c.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var c = new DataContext())
            {
                c.Entry(new Project() { ID = id }).State = EntityState.Deleted;
                c.SaveChanges();
            }
        }
    }
}
