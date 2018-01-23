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
    public class LienholdersController : MvcBaseController
    {
        // GET: Lienholders
        public async Task<IActionResult> Index()
        {
            List<Lienholder> model = new List<Lienholder>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"Lienholders");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.Lienholder>>();
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

		[Route("/Lienholders/Search")]
		public async Task<IActionResult> Search(string type=null)
		{
			List<Lienholder> model = new List<Lienholder>();

			if (type == null)
				ViewBag.searchtype = "lienholder";
			else
				ViewBag.searchtype = "billto";

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"Lienholders");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.Lienholder>>();
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

		// GET: Lienholders/Details/5
		public async Task<IActionResult> Details(long id)
        {
            Lienholder model = new Lienholder();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Lienholders/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Lienholder>();
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

        // GET: Lienholders/Create
        public ActionResult Create()
        {
            Lienholder model = new Lienholder();
            return View(model);
        }

        // POST: Lienholders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lienholder Lienholder)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Lienholder newRecord = Map(Lienholder);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.Lienholder>(@"Lienholders", newRecord);

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

        // GET: Lienholders/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            Lienholder model = new Lienholder();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Lienholders/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Lienholder>();
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

        // POST: Lienholders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Lienholder Lienholder)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Lienholder updates = Map(Lienholder);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.Lienholder>(string.Format(@"Lienholders/{0}", id), updates);

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

        // GET: Lienholders/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Lienholder model = new Lienholder();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Lienholders/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Lienholder>();
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

        // POST: Lienholders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, Lienholder Lienholder)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == Lienholder.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"Lienholders/{0}", Lienholder.Id));

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

		// GET: Lienholders/GetLienholders?type=active
		public async Task<IActionResult> GetLienholders(string type)
		{
			List<Lienholder> model = new List<Lienholder>();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				//var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
				//userInfoClient.SetBearerToken(tokenResponse.AccessToken);
				//HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"Lienholders");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.Lienholder>>();
					model = Map(content.Where(p => p.Active == true).ToList());

					return View("Index", model);
				}
			}
			catch
			{
				throw;
			}

			return View(model);
		}

		internal static Lienholder Map(DTO.Lienholder recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Lienholder()
			{ 
				Id = recordIn.Id,
				Name = recordIn.Name,
				PrimaryContact = recordIn.PrimaryContact,
				Address = recordIn.Address,
				City = recordIn.City,
				State = recordIn.State,
				Zip = recordIn.Zip,
				Phone = recordIn.Phone,
				Mobile = recordIn.Mobile,
				Fax = recordIn.Fax,
				Email = recordIn.Email,
				Notes = recordIn.Notes,
				PropertyDaysFree = recordIn.PropertyDaysFree,
				PropertyInitialFee = recordIn.PropertyInitialFee,
				PropertyDailyFee = recordIn.PropertyDailyFee,
				VehicleDaysFree = recordIn.VehicleDaysFree,
				VehicleInitialFee = recordIn.VehicleInitialFee,
				VehicleDailyFee = recordIn.VehicleDailyFee,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version
			};

            return recordOut;
        }

        internal static DTO.Lienholder Map(Lienholder recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Lienholder()
            {
				Id = recordIn.Id,
				Name = recordIn.Name,
				PrimaryContact = recordIn.PrimaryContact,
				Address = recordIn.Address,
				City = recordIn.City,
				State = recordIn.State,
				Zip = recordIn.Zip,
				Phone = recordIn.Phone,
				Mobile = recordIn.Mobile,
				Fax = recordIn.Fax,
				Email = recordIn.Email,
				Notes = recordIn.Notes,
				PropertyDaysFree = recordIn.PropertyDaysFree,
				PropertyInitialFee = recordIn.PropertyInitialFee,
				PropertyDailyFee = recordIn.PropertyDailyFee,
				VehicleDaysFree = recordIn.VehicleDaysFree,
				VehicleInitialFee = recordIn.VehicleInitialFee,
				VehicleDailyFee = recordIn.VehicleDailyFee,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version
			};

            return recordOut;
        }

        internal static List<Lienholder> Map(List<DTO.Lienholder> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<Lienholder>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }

        internal static List<DTO.Lienholder> Map(List<Lienholder> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<DTO.Lienholder>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }
    }
}