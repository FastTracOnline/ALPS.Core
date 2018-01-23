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
    public class ServicesController : MvcBaseController
    {
        // GET: Services
        public async Task<IActionResult> Index()
        {
            List<Service> model = new List<Service>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"Services");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.Service>>();
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

        // GET: Services/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Service model = new Service();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Services/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Service>();
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

        // GET: Services/Create
        public ActionResult Create()
        {
            Service model = new Service();
            return View(model);
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service Service)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Service newRecord = Map(Service);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.Service>(@"Services", newRecord);

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

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            Service model = new Service();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Services/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Service>();
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

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Service Service)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Service updates = Map(Service);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.Service>(string.Format(@"Services/{0}", id), updates);

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

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Service model = new Service();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Services/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Service>();
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

        // POST: Services/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, Service Service)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == Service.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"Services/{0}", Service.Id));

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

        internal static Service Map(DTO.Service recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Service()
            {
				Id = recordIn.Id,
				ServiceType = recordIn.ServiceType,
				FeeType = recordIn.FeeType,
				Description = recordIn.Description,
				BasePrice = recordIn.BasePrice,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId
			};

            return recordOut;
        }

        internal static DTO.Service Map(Service recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Service()
            {
				Id = recordIn.Id,
				ServiceType = recordIn.ServiceType,
				FeeType = recordIn.FeeType,
				Description = recordIn.Description,
				BasePrice = recordIn.BasePrice,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId
			};

            return recordOut;
        }

        internal static List<Service> Map(List<DTO.Service> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<Service>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }

		internal static List<DTO.Service> Map(List<Service> recordList)
		{
			if (recordList == null)
                return null;

            var recordOut = new List<DTO.Service>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }
    }
}