using ALPS.API.Data;
using ALPS.API.Entities;
using ALPS.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ALPS.API.Controllers
{
	[Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : ApiBaseController
    {
        private ALPSContext context;

        public OrdersController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "Orders")]
        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrders()
        {
			var subscriberId = 1;
			var queryList = context.Orders
							.Where(c => c.SubscriberId == subscriberId)
							.OrderByDescending(x => x.Received)
							.ToList<Order>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

            //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
            //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
            //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult GetOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Order = context.Orders.Find(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Map(Order));
        }

		// GET: api/Orders/5/Contacts
		[HttpGet]
		[Route("api/Orders/{id}/Contacts")]
		public ActionResult GetContacts([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var contacts = context.Contacts
						.Where(c => c.OrderId == id && c.RelationToDebtor != RelationshipType.Debtor)
						.ToList<Contact>();

			if (contacts == null)
			{
				return NotFound();
			}

			var result = ContactsController.Map(contacts);
			return Ok(result);
		}

		// GET: api/Orders/5/Debtor
		[HttpGet]
		[Route("api/Orders/{id}/Debtor")]
		public ActionResult GetDebtor([FromRoute] long id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var debtor = context.Contacts
						.FirstOrDefault(c => c.OrderId == id && c.RelationToDebtor == RelationshipType.Debtor);

			if (debtor == null)
			{
				return NotFound();
			}

			return Ok(DebtorsController.Map(debtor));
		}

		// PUT: api/Orders/5
		[HttpPut("{id}")]
        public ActionResult PutOrder([FromRoute] long id, [FromBody] DTO.Order recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!OrderExists(id))
            {
                return NotFound();
            }

            Order currentRecord = context.Orders.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
            context.Orders.Update(currentRecord);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult PostOrder([FromBody] DTO.Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriberId = 1;

			Order.OrderStatus = OrderStatus.New;

			Order.Active = true;
            Order.Created = DateTime.UtcNow;
            Order.SubscriberId = subscriberId;

            context.Orders.Add(Map(Order));
            context.SaveChanges();

            return CreatedAtAction("GetOrder", new { id = Order.Id }, Order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Order = context.Orders.Find(id);
            if (Order == null)
            {
                return NotFound();
            }

            context.Orders.Remove(Order);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(Order);
        }

        private bool OrderExists(long id)
        {
            return (context.Orders.Find(id) != null);
        }

        internal static DTO.Order Map(Order recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.Order recordOut = new DTO.Order()
            {
				Id = recordIn.Id,
				OrderNumber = recordIn.OrderNumber,
				ClientRefNo = recordIn.ClientRefNo,
				OrderType = recordIn.OrderType,
				OrderStatus = recordIn.OrderStatus,
				Received = recordIn.Received,
				Repossessed = recordIn.Repossessed,
				VehicleReleased = recordIn.VehicleReleased,
				PropertyReleased = recordIn.PropertyReleased,
				Billed = recordIn.Billed,
				Paid = recordIn.Paid,
				Closed = recordIn.Closed,
				CloseReason = recordIn.CloseReason,

				// Loan Information
				DueDate = recordIn.DueDate,
				PastDue = recordIn.PastDue,
				LoanDate = recordIn.LoanDate,
				LastPayment = recordIn.LastPayment,
				Amt_Loan = recordIn.Amt_Loan,
				Amt_Balance = recordIn.Amt_Balance,
				Amt_Payment = recordIn.Amt_Payment,
				Amt_Due = recordIn.Amt_Due,

				// Repossession Information
				Remarks = recordIn.Remarks,
				Property = recordIn.Property,

				//Billing Information
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
				DebtorId = recordIn.DebtorId,
				Debtor = DebtorsController.Map(recordIn.Debtor),
				VehicleId = recordIn.VehicleId,
				Vehicle = VehiclesController.Map(recordIn.Vehicle),
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

            return recordOut;
        }

        internal static Order Map(DTO.Order recordIn)
        {
            if (recordIn == null)
                return null;

            Order recordOut = new Order()
            {
				Id = recordIn.Id,
				OrderNumber = recordIn.OrderNumber,
				ClientRefNo = recordIn.ClientRefNo,
				OrderType = recordIn.OrderType,
				OrderStatus = recordIn.OrderStatus,
				Received = recordIn.Received,
				Repossessed = recordIn.Repossessed,
				VehicleReleased = recordIn.VehicleReleased,
				PropertyReleased = recordIn.PropertyReleased,
				Billed = recordIn.Billed,
				Paid = recordIn.Paid,
				Closed = recordIn.Closed,
				CloseReason = recordIn.CloseReason,

				// Loan Information
				DueDate = recordIn.DueDate,
				PastDue = recordIn.PastDue,
				LoanDate = recordIn.LoanDate,
				LastPayment = recordIn.LastPayment,
				Amt_Loan = recordIn.Amt_Loan,
				Amt_Balance = recordIn.Amt_Balance,
				Amt_Payment = recordIn.Amt_Payment,
				Amt_Due = recordIn.Amt_Due,

				// Repossession Information
				Remarks = recordIn.Remarks,
				Property = recordIn.Property,

				//Billing Information
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
				DebtorId = recordIn.DebtorId,
				Debtor = DebtorsController.Map(recordIn.Debtor),
				VehicleId = recordIn.VehicleId,
				Vehicle = VehiclesController.Map(recordIn.Vehicle),
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

            return recordOut;
        }

		internal List<DTO.Order> Map(List<Order> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Order> listOut = new List<DTO.Order>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal List<Order> Map(List<DTO.Order> listIn)
		{
			if (listIn == null)
				return null;

			List<Order> listOut = new List<Order>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.Order recordIn, ref Order currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.OrderNumber = recordIn.OrderNumber;
			currentRecord.ClientRefNo = recordIn.ClientRefNo;
			currentRecord.OrderType = recordIn.OrderType;
			currentRecord.OrderStatus = recordIn.OrderStatus;
			currentRecord.Received = recordIn.Received;
			currentRecord.Repossessed = recordIn.Repossessed;
			currentRecord.VehicleReleased = recordIn.VehicleReleased;
			currentRecord.PropertyReleased = recordIn.PropertyReleased;
			currentRecord.Billed = recordIn.Billed;
			currentRecord.Paid = recordIn.Paid;
			currentRecord.Closed = recordIn.Closed;
			currentRecord.CloseReason = recordIn.CloseReason;

			// Loan Information
			currentRecord.DueDate = recordIn.DueDate;
			currentRecord.PastDue = recordIn.PastDue;
			currentRecord.LoanDate = recordIn.LoanDate;
			currentRecord.LastPayment = recordIn.LastPayment;
			currentRecord.Amt_Loan = recordIn.Amt_Loan;
			currentRecord.Amt_Balance = recordIn.Amt_Balance;
			currentRecord.Amt_Payment = recordIn.Amt_Payment;
			currentRecord.Amt_Due = recordIn.Amt_Due;
			
			// Repossession Information
			currentRecord.Remarks = recordIn.Remarks;
			currentRecord.Property = recordIn.Property;
			
			//Billing Information
			currentRecord.PropertyDaysFree = recordIn.PropertyDaysFree;
			currentRecord.PropertyInitialFee = recordIn.PropertyInitialFee;
			currentRecord.PropertyDailyFee = recordIn.PropertyDailyFee;
			currentRecord.VehicleDaysFree = recordIn.VehicleDaysFree;
			currentRecord.VehicleInitialFee = recordIn.VehicleInitialFee;
			currentRecord.VehicleDailyFee = recordIn.VehicleDailyFee;
			
			currentRecord.Notes = recordIn.Notes;
			currentRecord.DebtorId = recordIn.DebtorId;
			currentRecord.VehicleId = recordIn.VehicleId;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
