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
    public class MakeModelsController : MvcBaseController
    {
        // GET: MakeModels
        public async Task<IActionResult> Index()
        {
            List<MakeModel> model = new List<MakeModel>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"MakeModels");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.MakeModel>>();
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

        // GET: MakeModels/Details/5
        public async Task<IActionResult> Details(long id)
        {
            MakeModel model = new MakeModel();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"MakeModels/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.MakeModel>();
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

        // GET: MakeModels/Create
        public ActionResult Create()
        {
            MakeModel model = new MakeModel();
            return View(model);
        }

        // POST: MakeModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MakeModel MakeModel)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.MakeModel newRecord = Map(MakeModel);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.MakeModel>(@"MakeModels", newRecord);

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

        // GET: MakeModels/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            MakeModel model = new MakeModel();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"MakeModels/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.MakeModel>();
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

        // POST: MakeModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, MakeModel MakeModel)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.MakeModel updates = Map(MakeModel);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.MakeModel>(string.Format(@"MakeModels/{0}", id), updates);

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

        // GET: MakeModels/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            MakeModel model = new MakeModel();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"MakeModels/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.MakeModel>();
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

        // POST: MakeModels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, MakeModel MakeModel)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == MakeModel.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"MakeModels/{0}", MakeModel.Id));

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

		// GET: MakeModels/GetMakeModels?type=active
		public async Task<IActionResult> GetMakeModels(string type)
		{
			List<MakeModel> model = new List<MakeModel>();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				//var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
				//userInfoClient.SetBearerToken(tokenResponse.AccessToken);
				//HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"MakeModels");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.MakeModel>>();
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

		internal static MakeModel Map(DTO.MakeModel recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new MakeModel()
            {
				Id = recordIn.Id,
				Manufacturer = recordIn.Manufacturer,
				Model = recordIn.Model,
				Notes = recordIn.Notes,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version
			};

            return recordOut;
        }

        internal static DTO.MakeModel Map(MakeModel recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.MakeModel()
            {
				Id = recordIn.Id,
				Manufacturer = recordIn.Manufacturer,
				Model = recordIn.Model,
				Notes = recordIn.Notes,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version
			};

            return recordOut;
        }

        internal static List<MakeModel> Map(List<DTO.MakeModel> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<MakeModel>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }

        internal static List<DTO.MakeModel> Map(List<MakeModel> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<DTO.MakeModel>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }
    }
}