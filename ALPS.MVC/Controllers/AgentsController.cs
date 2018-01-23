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
    public class AgentsController : MvcBaseController
    {
        // GET: Agents
        public async Task<IActionResult> Index()
        {
            List<Agent> model = new List<Agent>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"Agents");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.Agent>>();
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

		[Route("/Agents/Search")]
		public async Task<IActionResult> Search()
		{
			List<Agent> model = new List<Agent>();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"Agents");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.Agent>>();
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

		// GET: Agents/Details/5
		public async Task<IActionResult> Details(long id)
        {
            Agent model = new Agent();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Agents/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Agent>();
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

        // GET: Agents/Create
        public ActionResult Create()
        {
            Agent model = new Agent();
            return View(model);
        }

        // POST: Agents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agent Agent)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Agent newRecord = Map(Agent);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.Agent>(@"Agents", newRecord);

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

        // GET: Agents/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            Agent model = new Agent();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Agents/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Agent>();
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

        // POST: Agents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Agent Agent)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Agent updates = Map(Agent);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.Agent>(string.Format(@"Agents/{0}", id), updates);

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

        // GET: Agents/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Agent model = new Agent();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Agents/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Agent>();
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

        // POST: Agents/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, Agent Agent)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == Agent.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"Agents/{0}", Agent.Id));

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

		// GET: Agents/GetAgents?type=active
		public async Task<IActionResult> GetAgents(string type)
		{
			List<Agent> model = new List<Agent>();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				//var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
				//userInfoClient.SetBearerToken(tokenResponse.AccessToken);
				//HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"Agents");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.Agent>>();
					model = Map(content.Where(p=>p.Active == true).ToList());

					return View("Index", model);
				}
			}
			catch
			{
				throw;
			}

			return View(model);
		}

		internal static Agent Map(DTO.Agent recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Agent()
            {
                Id = recordIn.Id,
                AgentType = recordIn.AgentType,
                FirstName = recordIn.FirstName,
                LastName = recordIn.LastName,
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

        internal static DTO.Agent Map(Agent recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Agent()
            {
                Id = recordIn.Id,
                AgentType = recordIn.AgentType,
                FirstName = recordIn.FirstName,
                LastName = recordIn.LastName,
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

        internal static List<Agent> Map(List<DTO.Agent> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<Agent>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }

        internal static List<DTO.Agent> Map(List<Agent> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<DTO.Agent>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }
    }
}