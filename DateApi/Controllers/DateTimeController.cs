using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DateApi.Controllers
{
    [Route("DateTime")]
    public class DateTimeController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json(DateTime.Now.ToLongDateString() );
        }
    }
}
