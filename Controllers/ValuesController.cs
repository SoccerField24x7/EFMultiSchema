using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webtest.dbcontext;

namespace webtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            //var optionsBuilder = new DbContextOptionsBuilder<CrmContext>();
            //optionsBuilder.UseSqlServer(Startup.Configuration.GetConnectionString("DbService"));

            using (var context = new CrmContext("1"))
            {
                var records = context.Name.FirstOrDefault();
            }

            using (var context = new CrmContext("2"))
            {
                var records = context.Name.FirstOrDefault();
            }
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
