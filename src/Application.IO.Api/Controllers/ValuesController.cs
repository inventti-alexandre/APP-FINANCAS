using Application.IO.Core.Domain.Source.Notifications;
using Application.IO.Core.Domain.Source.Notifications.Interfaces;
using Application.IO.Core.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Application.IO.Api.Controllers
{
    public class ValuesController : BaseController
    {
        public ValuesController(IUser user,
            IAppNotificationHandler<DomainNotification> notification) : base(user, notification) { }

        // GET api/values
        [Authorize]
        [HttpGet("values")]
        public ActionResult<IEnumerable<string>> Get(int version)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("values/{id}")]
        public ActionResult<string> Get(int id, int version)
        {
            return id.ToString();
        }

        // POST api/values
        [HttpPost("values")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("values/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("values/{id}")]
        public void Delete(int id)
        {
        }
    }
}
