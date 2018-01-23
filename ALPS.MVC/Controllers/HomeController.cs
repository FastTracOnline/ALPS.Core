using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ALPS.Common;
using ALPS.MVC.Helpers;
using ALPS.MVC.ViewModels;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ALPS.MVC.Controllers
{
    public class HomeController : Controller
    {
		public async Task<IActionResult> Index()
		{
			ViewData["Message"] = "My Company Information.";
			Dashboard model = new Dashboard();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				//var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
				//userInfoClient.SetBearerToken(tokenResponse.AccessToken);
				//HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

				//var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				//HttpResponseMessage response = await apiClient.GetAsync(@"Dashboard");
				//if (response.IsSuccessStatusCode)
				//{
				//	var content = await response.Content.ReadAsJsonAsync<DTO.Dashboard>();
				//	model = Map(content);
				//	return View(model);
				//}
			}
			catch
			{
				throw;
			}

			return View(model);
		}

		internal static Dashboard Map(DTO.Dashboard recordIn)
		{
			if (recordIn == null)
				return null;

			var recordOut = new Dashboard()
			{
				Agents_Active = recordIn.Agents_Active,
				Lienholders_Active = recordIn.Lienholders_Active,
				Orders_Billable = recordIn.Orders_Billable,
				Orders_New = recordIn.Orders_New,
				Orders_NotPaid = recordIn.Orders_NotPaid,
				Orders_Repossessed = recordIn.Orders_Repossessed,
				Orders_Working = recordIn.Orders_Working
			};

			return recordOut;
		}

		[Authorize]
        public IActionResult Secure()
        {
            ViewData["Message"] = "Secure page.";

            return View();
        }

		public async Task Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        public IActionResult Error()
        {
            return View();
        }

        //public async Task<IActionResult> GetUser()
        //{
        //    var tokenClient = new TokenClient(ALPSConstants.IdSrvToken, "mvc", "secret");
        //    var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

        //    var client = new HttpClient();
        //    client.SetBearerToken(tokenResponse.AccessToken);
        //    ViewBag.Json = null;

        //    var content = await client.GetStringAsync(ALPSConstants.ALPSAPI + @"/identity/getidentity");
            
        //    ViewBag.Json = JArray.Parse(content).ToString();

        //    return View("json");
        //}

        //public async Task<IActionResult> CallApiUsingClientCredentials()
        //{
        //    var tokenClient = new TokenClient(ALPSConstants.IdSrvToken, "mvc", "secret");
        //    var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

        //    var client = new HttpClient();
        //    client.SetBearerToken(tokenResponse.AccessToken);
        //    var content = await client.GetStringAsync(ALPSConstants.ALPSAPI + @"/identity/getclaims");

        //    ViewBag.Json = JArray.Parse(content).ToString();
        //    return View("json");
        //}

        //public async Task<IActionResult> CallApiUsingUserAccessToken()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");

        //    var client = new HttpClient();
        //    client.SetBearerToken(accessToken);
        //    var content = await client.GetStringAsync(ALPSConstants.ALPSAPI + @"/identity/getclaims");

        //    ViewBag.Json = JArray.Parse(content).ToString();
        //    return View("json");
        //}
    }
}
