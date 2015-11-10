using IdentityModel;
using IdentityModel.Client;
using IdentityModel.Extensions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShowingSecureDateTime.Controllers
{
    public class AccountController : Controller
    {
        

        // GET: Account
        public ActionResult SignIn()
        {
            var url = Constants.AuthorizeEndpoint +
                "?client_id=_test"+
                "&scope=openid email"+
                "&response_type=code"+
                "&response_mode=form_post"+
                "&redirect_uri=https://localhost:44300/Account/SignInToken";

            return Redirect(url);
           
        }

        [HttpPost]
        public ActionResult SignInAuthCode()
        {
            

            return RedirectToAction("SignInCallBack", new { id = 1 });
        }

        [HttpPost]
        public async Task<ActionResult> SignInToken()
        {
            var client = new TokenClient(Constants.TokenEndpoint,
                "_test",
                "8XBxsZWA4z8YicTXZ0meRE/Pm03tXLDXLUw6ofyvjg8=");

            var code = Request.Form["code"];
            //var tempState = await GetTem

            var response = await client.RequestAuthorizationCodeAsync(code, "https://localhost:44300/Account/SignInToken");


            return RedirectToAction("SignInToken", new { token = response });
        }

        public  ActionResult SignInToken(TokenResponse token)
        {
            return View(token);
        }

        public ActionResult SignInCallBack(int id)
        {
            //return Redirect("/");
            return View();
        }
    }
}