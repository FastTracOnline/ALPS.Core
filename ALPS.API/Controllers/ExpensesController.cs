using ALPS.API.Data;
using ALPS.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ALPS.API.Controllers
{
	[Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : ApiBaseController
    {
        private ALPSContext context;

        public ExpensesController(ALPSContext _context)
        {
            context = _context;
        }

        //[ResourceAuthorize("List", "Expenses")]
        // GET: api/Expenses
        [HttpGet]
        public IActionResult GetExpenses()
        {
			var subscriberId = 1;
			var queryList = context.Expenses
							.Where(c => c.SubscriberId == subscriberId)
							.OrderBy("ExpenseCategory,Description")
							.ToList<Expense>();

			if (queryList != null)
				return Ok(Map(queryList));
			else
				return NoContent();

            //JsonSerializerSettings jsonFormat = new JsonSerializerSettings();
            //jsonFormat.DefaultValueHandling = DefaultValueHandling.Ignore;
            //jsonFormat.NullValueHandling = NullValueHandling.Ignore;
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public ActionResult GetExpense([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Expense = context.Expenses.Find(id);

            if (Expense == null)
            {
                return NotFound();
            }

            return Ok(Map(Expense));
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public ActionResult PutExpense([FromRoute] long id, [FromBody] DTO.Expense recordIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recordIn.Id)
            {
                return BadRequest();
            }

            if (!ExpenseExists(id))
            {
                return NotFound();
            }

            Expense currentRecord = context.Expenses.Find(id);

            if (currentRecord == null)
            {
                return NotFound();
            }

			CopyUpdatedFields(recordIn, ref currentRecord);
            context.Expenses.Update(currentRecord);

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

        // POST: api/Expenses
        [HttpPost]
        public ActionResult PostExpense([FromBody] DTO.Expense Expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriberId = 1;

            Expense.Created = DateTime.UtcNow;
            Expense.SubscriberId = subscriberId;

            context.Expenses.Add(Map(Expense));
            context.SaveChanges();

            return CreatedAtAction("GetExpense", new { id = Expense.Id }, Expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public ActionResult DeleteExpense([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Expense = context.Expenses.Find(id);
            if (Expense == null)
            {
                return NotFound();
            }

            context.Expenses.Remove(Expense);

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(Expense);
        }

        private bool ExpenseExists(long id)
        {
            return (context.Expenses.Find(id) != null);
        }

        internal static DTO.Expense Map(Expense recordIn)
        {
            if (recordIn == null)
                return null;

            DTO.Expense recordOut = new DTO.Expense()
            {
				Id = recordIn.Id,
                ExpenseDate = recordIn.ExpenseDate,
                ExpenseCategory = recordIn.ExpenseCategory,
                Description = recordIn.Description,
                Amount = recordIn.Amount,
                BillClient = recordIn.BillClient,
                DatePaid = recordIn.DatePaid,
                Created = recordIn.Created,
                Updated = recordIn.Updated,
                Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
                Subscriber = SubscribersController.Map(recordIn.Subscriber)
            };

            return recordOut;
        }

        internal static Expense Map(DTO.Expense recordIn)
        {
            if (recordIn == null)
                return null;

            Expense recordOut = new Expense()
            {
				Id = recordIn.Id,
				ExpenseDate = recordIn.ExpenseDate,
				ExpenseCategory = recordIn.ExpenseCategory,
				Description = recordIn.Description,
				Amount = recordIn.Amount,
				BillClient = recordIn.BillClient,
				DatePaid = recordIn.DatePaid,
				Created = recordIn.Created,
				Updated = recordIn.Updated,
				Version = recordIn.Version,
				SubscriberId = recordIn.SubscriberId,
				Subscriber = SubscribersController.Map(recordIn.Subscriber)
			};

            return recordOut;
        }

		internal List<DTO.Expense> Map(List<Expense> listIn)
		{
			if (listIn == null)
				return null;

			List<DTO.Expense> listOut = new List<DTO.Expense>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		internal List<Expense> Map(List<DTO.Expense> listIn)
		{
			if (listIn == null)
				return null;

			List<Expense> listOut = new List<Expense>();
			foreach (var item in listIn)
			{
				listOut.Add(Map(item));
			}

			return listOut;
		}

		public void CopyUpdatedFields(DTO.Expense recordIn, ref Expense currentRecord)
		{
			if (recordIn == null)
				return;

			currentRecord.ExpenseDate = recordIn.ExpenseDate;
			currentRecord.ExpenseCategory = recordIn.ExpenseCategory;
			currentRecord.Description = recordIn.Description;
			currentRecord.Amount = recordIn.Amount;
			currentRecord.BillClient = recordIn.BillClient;
            currentRecord.DatePaid = recordIn.DatePaid;

			currentRecord.Updated = DateTime.UtcNow;
		}
	}
}
