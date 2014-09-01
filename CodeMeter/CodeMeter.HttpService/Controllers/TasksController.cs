using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CodeMeter.HttpService.Models;
using System.Data.Entity;
using System.Linq;

namespace CodeMeter.HttpService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TasksController : ApiController
    {
        public Project Get(int projectId)
        {
            using (var c = new DataContext())
            {
                var project = c.Projects.Include(x => x.Tasks).Include(x => x.Tasks.Select(t => t.Logs)).Single(x => x.ID == projectId);
                foreach (var task in project.Tasks)
                {
                    task.Project = null;
                    task.SetStartAndEnd();
                    task.Logs = null;
                }
                return project;
            }
        }

        public Task Get(int projectId, int taskId)
        {
            using (var c = new DataContext())
            {
                return c.Tasks.Single(x => x.ID == taskId);
            }
        }

        public HttpResponseMessage Post(HttpRequestMessage request, int projectId,Task task)
        {
            using (var c = new DataContext())
            {
                c.Tasks.Add(task);
                c.SaveChanges();
            }
            var r = request.CreateResponse(HttpStatusCode.Created, task.ID);
            return r;
        }

        public void Put(int projectId, int taskId, Task task)
        {
            using (var c = new DataContext())
            {
                c.Entry(task).State = EntityState.Modified;
                c.SaveChanges();
            }
        }

        public void Delete(int projectId, int taskId)
        {
            using (var c = new DataContext())
            {
                c.Entry(new Task{ID = taskId}).State = EntityState.Deleted;
                c.SaveChanges();
            }
        }

        [System.Web.Http.HttpGet]
        public Task LastRun(int taskId)
        {
            using (var c = new DataContext())
            {
                var task = c.Tasks.Include(x => x.Logs).Single(x => x.ID == taskId);
                task.SetStartAndEnd();
                task.Logs = null;
                return task;
            }
        }

        [System.Web.Http.HttpPut]
        public HttpResponseMessage StartTask(HttpRequestMessage request, int taskId)
        {
            using (var c = new DataContext())
            {
                if (c.Tasks.Any(x => x.IsRunning))
                {
                    return request.CreateResponse(HttpStatusCode.MethodNotAllowed, "Some task already is running");
                }
                var task = c.Tasks.Single(x => x.ID == taskId);
                task.Logs.Add(new TaskLog()
                {
                    Start = DateTime.Now
                });
                task.IsRunning = true;
                c.SaveChanges();
                return request.CreateResponse(HttpStatusCode.OK, taskId);
            }
        }

        [System.Web.Http.HttpPut]
        public Task EndTask(HttpRequestMessage request, int taskId)
        {
            using (var c = new DataContext())
            {
                var task = c.Tasks.Include(x => x.Logs).Single(x => x.ID == taskId);
                if (!task.IsRunning) return task;
                task.IsRunning = false;
                var logs = task.Logs.ToArray();
                var last = logs.Last();
                last.End = DateTime.Now;
                task.SetStartAndEnd();
                c.SaveChanges();
                task.Logs = null;
                return task;
            }
        }
    }
}
