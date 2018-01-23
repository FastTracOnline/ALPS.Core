using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ALPS.MVC.ViewModels;
using ALPS.MVC.Helpers;
using System.Net.Http;
using Newtonsoft.Json;
using IdentityModel.Client;
using ALPS.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ALPS.MVC.Controllers
{
    //[Authorize]
    public class SubscribersController : MvcBaseController
    {
        // GET: Subscribers
        public async Task<IActionResult> Index()
        {
            List<Subscriber> model = new List<Subscriber>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"subscribers");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.Subscriber>>();
                    model = Map(content);

                    return View(model);
                }
            }
            catch
            {
                throw;
            }

            return View(model);
        }

        // GET: Subscribers/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Subscriber model = new Subscriber();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"subscribers/{0}",id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Subscriber>();
                    model = Map(content);

                    return View(model);
                }
            }
            catch
            {
                throw;
            }

            return View(model);
        }

        // GET: Subscribers/Create
        public ActionResult Create()
        {
            Subscriber model = new Subscriber();
            return View(model);
        }

        // POST: Subscribers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subscriber subscriber)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Subscriber newRecord = Map(subscriber);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.Subscriber>(@"subscribers",newRecord);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Subscribers/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            Subscriber model = new Subscriber();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"subscribers/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Subscriber>();
                    model = Map(content);

                    return View(model);
                }
            }
            catch
            {
                throw;
            }

            return View(model);
        }

        // POST: Subscribers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Subscriber subscriber)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Subscriber updates = Map(subscriber);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.Subscriber>(string.Format(@"subscribers/{0}", id), updates);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, response.ReasonPhrase);
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Subscribers/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Subscriber model = new Subscriber();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"subscribers/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Subscriber>();
                    model = Map(content);

                    return View(model);
                }
            }
            catch
            {
                throw;
            }

            return View(model);
        }

        // POST: Subscribers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, Subscriber subscriber)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == subscriber.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"subscribers/{0}", subscriber.Id));

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, response.ReasonPhrase);
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Mismatched key, delete aborted");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        internal static Subscriber Map(DTO.Subscriber recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Subscriber()
            {
                Id = recordIn.Id,
                Type = recordIn.Type,
                Name = recordIn.Name,
                PrimaryContact = recordIn.PrimaryContact,
                Balance = recordIn.Balance,
                TenantName = recordIn.TenantName,
                Address = recordIn.Address,
                City = recordIn.City,
                State = recordIn.State,
                Zip = recordIn.Zip,
                Phone = recordIn.Phone,
                Mobile = recordIn.Mobile,
				Fax = recordIn.Fax,
				Email = recordIn.Email,
                Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version
            };

            return recordOut;
        }

        internal static DTO.Subscriber Map(Subscriber recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Subscriber()
            {
                Id = recordIn.Id,
                Type = recordIn.Type,
                Name = recordIn.Name,
                PrimaryContact = recordIn.PrimaryContact,
                Balance = recordIn.Balance,
                TenantName = recordIn.TenantName,
                Address = recordIn.Address,
                City = recordIn.City,
                State = recordIn.State,
                Zip = recordIn.Zip,
				Phone = recordIn.Phone,
				Mobile = recordIn.Mobile,
				Fax = recordIn.Fax,
				Email = recordIn.Email,
                Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version
            };

            return recordOut;
        }

		internal static List<Subscriber> Map(List<DTO.Subscriber> recordList)
		{
			if (recordList == null)
				return null;

			var recordOut = new List<Subscriber>();
			foreach (var item in recordList)
			{
				if (item != null)
					recordOut.Add(Map(item));
			}

			return recordOut;
		}

		internal static List<DTO.Subscriber> Map(List<Subscriber> recordList)
		{
			if (recordList == null)
				return null;

			var recordOut = new List<DTO.Subscriber>();
			foreach (var item in recordList)
			{
				if (item != null)
					recordOut.Add(Map(item));
			}

			return recordOut;
		}
	}
}