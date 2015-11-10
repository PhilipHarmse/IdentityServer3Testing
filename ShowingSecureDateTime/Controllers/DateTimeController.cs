using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowingSecureDateTime.Models;
using System.Net.Http;

namespace ShowingSecureDateTime.Controllers
{
    //api adddress http://localhost:59797/

    public class DateTimeController : Controller
    {
        // GET: DateTime
        public ActionResult DisplayDateTimeWithUser()
        {
            var client = new HttpClient();

            var getDate = client.GetStringAsync("http://localhost:59797/DateTime/").Result;


            MyDateWithUserInfo dateAndUserInfo = new MyDateWithUserInfo
            {
                ProtectedDate = getDate
            };

            return View(dateAndUserInfo);
        }
    }
}