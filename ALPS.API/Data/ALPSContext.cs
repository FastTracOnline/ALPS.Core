using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using ALPS.API.Entities;

namespace ALPS.API.Data

{
	public class ALPSContext : DbContext
	{
        public ALPSContext()
        { }

		// ToDo: Move Initializer to Global.asax; don't want dependence on SampleData
		public ALPSContext(DbContextOptions<ALPSContext> options) : base(options)
		{ }

		public DbSet<Agent> Agents { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Employer> Employers { get; set; }
		public DbSet<Expense> Expenses { get; set; }
		public DbSet<Lienholder> Lienholders { get; set; }
		public DbSet<MakeModel> MakeModels { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<PoliceDepartment> PoliceDepartments { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Subscriber> Subscribers { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Vendor> Vendors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//         // Use singular table names
			//         modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Agent>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Contact>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Employer>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Expense>().Property(p => p.Version).IsConcurrencyToken();
            modelBuilder.Entity<Lienholder>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<MakeModel>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Order>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<PoliceDepartment>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Service>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Subscriber>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Vehicle>().Property(p => p.Version).IsConcurrencyToken();
			modelBuilder.Entity<Vendor>().Property(p => p.Version).IsConcurrencyToken();

			// Simple One-to-Many Relationships (Subscriber as parent)
			modelBuilder.Entity<Subscriber>()
                .HasMany(c => c.Agents)
                .WithOne(d => d.Subscriber)
                .HasForeignKey(c => c.SubscriberId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Contacts)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Employers)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Expenses)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Lienholders)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.MakeModels)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Orders)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.PoliceDepartments)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Services)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Vehicles)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Subscriber>()
				.HasMany(c => c.Vendors)
				.WithOne(d => d.Subscriber)
				.HasForeignKey(c => c.SubscriberId)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			// Simple One-to-Many Relationships (Lienholder as parent)
			modelBuilder.Entity<Lienholder>()
				.HasMany(c => c.Orders)
				.WithOne(d => d.Lienholder)
				.HasForeignKey(c => c.LienholderId)
				.IsRequired();

			// Simple One-to-Many Relationships (Order as parent)
			modelBuilder.Entity<Order>()
				.HasMany(c => c.Contacts)
				.WithOne(d => d.Order)
				.HasForeignKey(c => c.OrderId)
				.IsRequired();

			modelBuilder.Entity<Order>()
				.HasOne(c => c.Vehicle)
				.WithMany(d => d.Orders)
				.HasForeignKey(c => c.VehicleId)
				.IsRequired();

			modelBuilder.Entity<Order>()
				.HasOne(c => c.AssignedTo)
				.WithMany(d => d.Orders)
				.HasForeignKey(c => c.AgentId)
				.IsRequired(false);

			// Simple One-to-Many Relationships (Contact as parent)
			modelBuilder.Entity<Contact>()
				.HasOne(c => c.Employer)
				.WithMany(d => d.Contacts)
				.HasForeignKey(c => c.EmployerId)
				.IsRequired(false);

			// Simple One-to-Many Relationships (MakeModel as parent)
			modelBuilder.Entity<MakeModel>()
				.HasMany(c => c.Vehicles)
				.WithOne(d => d.MakeModel)
				.HasForeignKey(c => c.MakeModelId)
				.IsRequired();

			base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;");
        //    }
        //}
    }
}