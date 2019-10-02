using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webtest.dbcontext;

namespace webtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            List<string> firstNames = new List<string>();

            // get the tenant information
            using (var context = new CrmContext("dbo"))
            {
                var tenants = context.Tenant.Where(x => x.IsActive == 1);
                foreach (var tenant in tenants)
                {
                    // now let's get the User's name from different schemas
                    using (var schemaCrmContext = new CrmContext(tenant.SchemaId))
                    {
                        var records = schemaCrmContext.Name.FirstOrDefault();
                        firstNames.Add(records.UserName);
                    }
                }
            }

            return new JsonResult(firstNames);
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
