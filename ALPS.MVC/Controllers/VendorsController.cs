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
    public class VendorsController : MvcBaseController
    {
        // GET: Vendors
        public async Task<IActionResult> Index()
        {
            List<Vendor> model = new List<Vendor>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"Vendors");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.Vendor>>();
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

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Vendor model = new Vendor();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Vendors/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Vendor>();
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

        // GET: Vendors/Create
        public ActionResult Create()
        {
            Vendor model = new Vendor();
            return View(model);
        }

        // POST: Vendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendor Vendor)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Vendor newRecord = Map(Vendor);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.Vendor>(@"Vendors", newRecord);

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

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            Vendor model = new Vendor();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Vendors/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Vendor>();
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

        // POST: Vendors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Vendor Vendor)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Vendor updates = Map(Vendor);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.Vendor>(string.Format(@"Vendors/{0}", id), updates);

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

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Vendor model = new Vendor();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Vendors/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Vendor>();
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

        // POST: Vendors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, Vendor Vendor)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == Vendor.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"Vendors/{0}", Vendor.Id));

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

		// GET: Vendors/GetVendors?type=active
		public async Task<IActionResult> GetVendors(string type)
		{
			List<Vendor> model = new List<Vendor>();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				//var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
				//userInfoClient.SetBearerToken(tokenResponse.AccessToken);
				//HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"Vendors");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.Vendor>>();
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

		internal static Vendor Map(DTO.Vendor recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Vendor()
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
				VendorType = recordIn.VendorType,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version
			};

            return recordOut;
        }

        internal static DTO.Vendor Map(Vendor recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Vendor()
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
				VendorType = recordIn.VendorType,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version
			};

            return recordOut;
        }

        internal static List<Vendor> Map(List<DTO.Vendor> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<Vendor>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }

        internal static List<DTO.Vendor> Map(List<Vendor> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<DTO.Vendor>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }
    }
}