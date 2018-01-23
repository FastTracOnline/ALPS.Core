using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALPS.API.Entities;

namespace ALPS.API.Configuration
{
	public class OrderConfiguration : EntityTypeConfiguration<Order>
	{
		public OrderConfiguration()
		{
            //// Order has 1 Repossessor, Repossessor has many Order records
            //HasRequired(s => s.Repossessor)
            //   .WithMany(p => p.Orders);

            //// Order has 1 Lienholder, Lienholder has many Order records
            //HasRequired(s => s.Lienholder)
            //   .WithMany(p => p.Orders);

            //HasOptional(s => s.Location)
            //   .WithMany(p => p.Orders);

            //Map(m =>
            //{
            //	m.Properties(p => new
            //	{
            //		p.Id,
            //		p.OrderNumber,
            //		p.ClientRefNo,
            //		p.OrderType,
            //		p.OrderStatus,
            //		p.Received,
            //		p.VIN,
            //		p.Year,
            //		p.BodyStyle,
            //		p.Color,
            //		p.Tag,
            //		p.TagState,
            //		p.IgnitionCode,
            //		p.TrunkCode,
            //		p.VATCode,
            //		p.Insured,
            //		p.DueDate,
            //		p.LoanDate,
            //		p.LastPayment,
            //		p.Amt_Balance,
            //		p.Amt_Loan,
            //		p.Amt_Payment,
            //		p.Amt_Total,
            //		p.Notes,
            //		p.Active,
            //		p.Created,
            //		p.Updated,
            //		p.Relatives,
            //		p.Guarantors,
            //		p.Other,
            //		p.Remarks,
            //		p.Collateral
            //	});
            //	m.ToTable("Orders");
            //});
        }
    }
}
