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
    public class OrdersController : MvcBaseController
    {
        // GET: Orders
        public async Task<IActionResult> Index()
        {
            List<Order> model = new List<Order>();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv,@"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(@"Orders");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<List<DTO.Order>>();
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

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(long id)
        {
            Order model = new Order();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                //var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
                //userInfoClient.SetBearerToken(tokenResponse.AccessToken);
                //HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Orders/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Order>();
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

		// GET: Orders/Create
		public ActionResult Create()
		{
			Order model = new Order()
			{
				Received = DateTime.UtcNow
			};

            return View(model);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order Order)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Order newRecord = Map(Order);

                HttpResponseMessage response = await apiClient.PostAsJsonAsync<DTO.Order>(@"Orders", newRecord);

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

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            Order model = new Order();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Orders/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Order>();
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

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Order Order)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                DTO.Order updates = Map(Order);

                HttpResponseMessage response = await apiClient.PutAsJsonAsync<DTO.Order>(string.Format(@"Orders/{0}", id), updates);

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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            Order model = new Order();

            try
            {
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                HttpResponseMessage response = await apiClient.GetAsync(string.Format(@"Orders/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsJsonAsync<DTO.Order>();
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

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, Order Order)
        {
            try
            {
                // TODO: Add insert logic here
                //var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
                //var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");
                var apiClient = ALPSHttpClient.GetApiClient();
                //apiClient.SetBearerToken(tokenResponse.AccessToken);

                if (id == Order.Id)
                {
                    HttpResponseMessage response = await apiClient.DeleteAsync(string.Format(@"Orders/{0}", Order.Id));

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

		// GET: Orders/GetOrders?type=active
		public async Task<IActionResult> GetOrders(string type)
		{
			List<Order> model = new List<Order>();

			try
			{
				//var tokenClient = new TokenClient(string.Concat(ALPSConstants.IdSrv, @"/connect/token"), "mvc", "secret");
				//var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

				//var userInfoClient = ALPSHttpClient.GetApiClient(ALPSConstants.IdSrv);
				//userInfoClient.SetBearerToken(tokenResponse.AccessToken);
				//HttpResponseMessage response = await userInfoClient.GetAsync(@"/connect/userinfo");

				var apiClient = ALPSHttpClient.GetApiClient();
				//apiClient.SetBearerToken(tokenResponse.AccessToken);

				HttpResponseMessage response = await apiClient.GetAsync(@"Orders");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsJsonAsync<List<DTO.Order>>();
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

		internal static Order Map(DTO.Order recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new Order()
            {
                Id = recordIn.Id,
				OrderNumber = recordIn.OrderNumber,
				ClientRefNo = recordIn.ClientRefNo,
				OrderType = recordIn.OrderType,
				OrderStatus = recordIn.OrderStatus,
				Received = recordIn.Received,
                Repossessed = recordIn.Repossessed,
				VehicleReleased = recordIn.VehicleReleased,
				HasProperty = recordIn.HasProperty,
				PropertyReleased = recordIn.PropertyReleased,
				Billed = recordIn.Billed,
				Paid = recordIn.Paid,
				Closed = recordIn.Closed,
				CloseReason = recordIn.CloseReason,
				DueDate = recordIn.DueDate,
				PastDue = recordIn.PastDue,
				LoanDate = recordIn.LoanDate,
				LastPayment = recordIn.LastPayment,
				Amt_Loan = recordIn.Amt_Loan,
				Amt_Balance = recordIn.Amt_Balance,
				Amt_Payment = recordIn.Amt_Payment,
				Amt_Due = recordIn.Amt_Due,
				Remarks = recordIn.Remarks,
				Property = recordIn.Property,
				PropertyDaysFree = recordIn.PropertyDaysFree,
				PropertyInitialFee = recordIn.PropertyInitialFee,
				PropertyDailyFee = recordIn.PropertyDailyFee,
				VehicleDaysFree = recordIn.VehicleDaysFree,
				VehicleInitialFee = recordIn.VehicleInitialFee,
				VehicleDailyFee = recordIn.VehicleDailyFee,
				Notes = recordIn.Notes,
                Active = recordIn.Active,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				LienholderId = recordIn.LienholderId,
				DebtorId = recordIn.DebtorId,
				VehicleId = recordIn.VehicleId,
				AgentId = recordIn.AgentId,
				BillToId = recordIn.BillToId
			};

            return recordOut;
        }

        internal static DTO.Order Map(Order recordIn)
        {
            if (recordIn == null)
                return null;

            var recordOut = new DTO.Order()
            {
				Id = recordIn.Id,
				OrderNumber = recordIn.OrderNumber,
				ClientRefNo = recordIn.ClientRefNo,
				OrderType = recordIn.OrderType,
				OrderStatus = recordIn.OrderStatus,
				Received = recordIn.Received,
				Repossessed = recordIn.Repossessed,
				VehicleReleased = recordIn.VehicleReleased,
				HasProperty = recordIn.HasProperty,
				PropertyReleased = recordIn.PropertyReleased,
				Billed = recordIn.Billed,
				Paid = recordIn.Paid,
				Closed = recordIn.Closed,
				CloseReason = recordIn.CloseReason,
				DueDate = recordIn.DueDate,
				PastDue = recordIn.PastDue,
				LoanDate = recordIn.LoanDate,
				LastPayment = recordIn.LastPayment,
				Amt_Loan = recordIn.Amt_Loan,
				Amt_Balance = recordIn.Amt_Balance,
				Amt_Payment = recordIn.Amt_Payment,
				Amt_Due = recordIn.Amt_Due,
				Remarks = recordIn.Remarks,
				Property = recordIn.Property,
				PropertyDaysFree = recordIn.PropertyDaysFree,
				PropertyInitialFee = recordIn.PropertyInitialFee,
				PropertyDailyFee = recordIn.PropertyDailyFee,
				VehicleDaysFree = recordIn.VehicleDaysFree,
				VehicleInitialFee = recordIn.VehicleInitialFee,
				VehicleDailyFee = recordIn.VehicleDailyFee,
				Notes = recordIn.Notes,
				Active = recordIn.Active,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				LienholderId = recordIn.LienholderId,
				DebtorId = recordIn.DebtorId,
				VehicleId = recordIn.VehicleId,
				AgentId = recordIn.AgentId,
				BillToId = recordIn.BillToId
			};

            return recordOut;
        }

        internal static List<Order> Map(List<DTO.Order> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<Order>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }

        internal static List<DTO.Order> Map(List<Order> recordList)
        {
            if (recordList == null)
                return null;

            var recordOut = new List<DTO.Order>();
            foreach (var item in recordList)
            {
                if (item != null)
                    recordOut.Add(Map(item));
            }

            return recordOut;
        }
    }
}