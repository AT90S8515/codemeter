using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using CodeMeter.HttpService.Models;

namespace CodeMeter.HttpService.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ConfigurationController : ApiController
    {
        public Configuration GetConfiguration()
        {
            using (var c = new DataContext())
            {
                return c.Configurations.Single();
            }
        }

        public void Put(Configuration configuration)
        {
            using (var c = new DataContext())
            {
                c.Entry(configuration).State = EntityState.Modified;
                c.SaveChanges();
            }
        }
    }
}
