using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CodeMeter.HttpService.Models;

namespace CodeMeter.HttpService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TasksController : ApiController
    {
        public Project Get(int projectId)
        {
            return new Project
            {
                ID = 1,
                Name = "XXX",
                Tasks = new List<Task>()
                {
                    new Task() {ID = 1, Name = "SDSD", Description = "dfshfljhs dfhaslj fkdhfa hl   "}
                }
            };
        }

        public Task Get(int projectId, int taskId)
        {
            return new Task() {ID = 1, Name = "SDSD", Description = "dfshfljhs dfhaslj fkdhfa hl   "};
        }

        public HttpResponseMessage Post(HttpRequestMessage request, int projectId,Task task)
        {
            var r = request.CreateResponse(HttpStatusCode.Created, task.ID);
            return r;
        }

        public void Put(int projectId, Task task)
        {
            
        }

        public void Delete(int projectId, int taskId)
        {
            
        }

        [HttpGet]
        public Task LastRun(int taskId)
        {
            return new Task() { ID = 1, Name = "SDSD", Description = "dfshfljhs dfhaslj fkdhfa hl   " };
        }

        public void StartTask(int taskId)
        {
            
        }

        public void EndTask(int taskId)
        {
            
        }
    }
}
