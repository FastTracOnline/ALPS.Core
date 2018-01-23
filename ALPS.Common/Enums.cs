using System.ComponentModel.DataAnnotations;

namespace ALPS.Common
{
    public enum AddressType
    {
        Unknown = 0,
        Primary = 1,
        Billing = 2,
        Home = 3,
        Work = 4,
        Contact = 5
    }

    public enum AgentType
    {
        Unknown = 0,
        Individual = 1,
        Company = 2
    }

	public enum CloseReason
	{
		Unknown = 0,
	}

    public enum ExpenseCategory
    {
        Unknown = 0,
        Commissions = 1,
        OutsideServices = 2,
    }

	public enum FeeType
	{
		Unknown = 0,
		FlatFee = 1,
		DailyFee = 2
	}

	public enum Manufacturer
	{
		[Display(Name="Do Not Use")]
		Placeholder = 0,
		[Display(Name = "Toyota")]
		Toyota = 1,
	}

	public enum Model
	{
		[Display(Name = "Do Not Use")]
		Placeholder = 0,
		[Display(Name = "Highlander")]
		Highlander = 1,
		[Display(Name = "Corolla")]
		Corolla = 2,
	}

	public enum OrderType
    {
        Unknown = 0,
		Trace = 1,
		Repossession = 2
    }

    public enum OrderStatus
    {
        Unknown = 0,
        New = 1,
        Working = 2,
        Repossessed = 3,
        Reported = 4,
        Invoiced = 5,
		PaidByDebtor = 6,
		PaidInFull = 7,
        Closed = 8,
        Void = 9,
    }

	public enum RelationshipType
	{
		Unknown = 0,
		Debtor = 1,
		Spouse = 2,
		Child = 3,
		Relative = 4,
		Reference = 5,
		Guarantor = 6,
		Other = 7
	}

    public enum ServiceType
    {
		Unknown = 0,
        Repossession = 1,
        SkipTrace = 2,
    }

    public enum SubscriberType
    {
        Unknown = 0,
        Lienholder = 1,
        Repossessor = 2,
        Transporter = 3,
        Auctioneer = 4
    }

    public enum VehicleType
    {
		Unknown = 0,
		Car = 1,
		Utility = 2,
        Truck = 3,
		Van = 4,
        Semi = 5
    }

	public enum VehicleBodyType
	{
		Unknown = 0,
		Convertible = 1,
		Coupe = 2,
		Crossover = 3,
		Hatchback = 4,
		MiniVan = 5,
		Sedan = 6,
		SUV = 7,
		Truck = 8,
		Wagon = 9
	}

	public enum VendorType
    {
        Unknown = 0,
        Locksmith = 1,
        Transporter = 2,
        Auctioneer = 3,
    }
}
