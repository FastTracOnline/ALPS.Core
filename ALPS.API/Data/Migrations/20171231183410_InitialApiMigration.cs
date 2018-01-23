using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ALPS.API.Data.Migrations
{
    public partial class InitialApiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PrimaryContact = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    TenantName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AgentType = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    InvolRepoPaid = table.Column<decimal>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    TracePaid = table.Column<decimal>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    VolRepoPaid = table.Column<decimal>(nullable: false),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmploymentType = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PrimaryContact = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employers_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lienholders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PrimaryContact = table.Column<string>(nullable: true),
                    PropertyDailyFee = table.Column<decimal>(nullable: false),
                    PropertyDaysFree = table.Column<int>(nullable: false),
                    PropertyInitialFee = table.Column<decimal>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    VehicleDailyFee = table.Column<decimal>(nullable: false),
                    VehicleDaysFree = table.Column<int>(nullable: false),
                    VehicleInitialFee = table.Column<decimal>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lienholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lienholders_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakeModels",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Manufacturer = table.Column<int>(nullable: false),
                    Model = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Tips = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakeModels_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliceDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PrimaryContact = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliceDepartments_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    BasePrice = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FeeType = table.Column<int>(nullable: false),
                    ServiceType = table.Column<int>(nullable: false),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PrimaryContact = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    VendorType = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Cylinders = table.Column<int>(nullable: false),
                    IgnitionCode = table.Column<string>(nullable: true),
                    Insured = table.Column<bool>(nullable: true),
                    MakeModelId = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    TagState = table.Column<string>(nullable: true),
                    TrunkCode = table.Column<string>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    VATCode = table.Column<string>(nullable: true),
                    VIN = table.Column<string>(nullable: true),
                    VehicleBodyType = table.Column<int>(nullable: false),
                    VehicleType = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_MakeModels_MakeModelId",
                        column: x => x.MakeModelId,
                        principalTable: "MakeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    AgentId = table.Column<long>(nullable: true),
                    Amt_Balance = table.Column<decimal>(nullable: true),
                    Amt_Due = table.Column<decimal>(nullable: true),
                    Amt_Loan = table.Column<decimal>(nullable: true),
                    Amt_Payment = table.Column<decimal>(nullable: true),
                    BillToClientId = table.Column<long>(nullable: true),
                    BillToId = table.Column<long>(nullable: true),
                    Billed = table.Column<DateTime>(nullable: true),
                    ClientRefNo = table.Column<string>(maxLength: 20, nullable: true),
                    CloseReason = table.Column<int>(nullable: true),
                    Closed = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    DebtorId = table.Column<long>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    LastPayment = table.Column<DateTime>(nullable: true),
                    LienholderId = table.Column<long>(nullable: false),
                    LoanDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(maxLength: 6, nullable: true),
                    OrderStatus = table.Column<int>(nullable: false),
                    OrderType = table.Column<int>(nullable: false),
                    Paid = table.Column<DateTime>(nullable: true),
                    PastDue = table.Column<DateTime>(nullable: true),
                    Property = table.Column<string>(nullable: true),
                    PropertyDailyFee = table.Column<decimal>(nullable: false),
                    PropertyDaysFree = table.Column<int>(nullable: false),
                    PropertyInitialFee = table.Column<decimal>(nullable: false),
                    PropertyReleased = table.Column<DateTime>(nullable: true),
                    Received = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    Repossessed = table.Column<DateTime>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    VehicleDailyFee = table.Column<decimal>(nullable: false),
                    VehicleDaysFree = table.Column<int>(nullable: false),
                    VehicleId = table.Column<long>(nullable: false),
                    VehicleInitialFee = table.Column<decimal>(nullable: false),
                    VehicleReleased = table.Column<DateTime>(nullable: true),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Lienholders_BillToClientId",
                        column: x => x.BillToClientId,
                        principalTable: "Lienholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Lienholders_LienholderId",
                        column: x => x.LienholderId,
                        principalTable: "Lienholders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmployerId = table.Column<long>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LicenseNumber = table.Column<string>(nullable: true),
                    LicenseState = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    RelationToDebtor = table.Column<int>(nullable: false),
                    SSN = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<long>(nullable: false),
                    SubscriberId1 = table.Column<long>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    BillClient = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ExpenseCategory = table.Column<int>(nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    SubscriberId = table.Column<long>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<long>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_SubscriberId",
                table: "Agents",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_EmployerId",
                table: "Contacts",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrderId",
                table: "Contacts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SubscriberId",
                table: "Contacts",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_SubscriberId",
                table: "Employers",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_OrderId",
                table: "Expenses",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SubscriberId",
                table: "Expenses",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_VendorId",
                table: "Expenses",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lienholders_SubscriberId",
                table: "Lienholders",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeModels_SubscriberId",
                table: "MakeModels",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AgentId",
                table: "Orders",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillToClientId",
                table: "Orders",
                column: "BillToClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DebtorId",
                table: "Orders",
                column: "DebtorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LienholderId",
                table: "Orders",
                column: "LienholderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SubscriberId",
                table: "Orders",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceDepartments_SubscriberId",
                table: "PoliceDepartments",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_SubscriberId",
                table: "Services",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MakeModelId",
                table: "Vehicles",
                column: "MakeModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_SubscriberId",
                table: "Vehicles",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_SubscriberId",
                table: "Vendors",
                column: "SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contacts_DebtorId",
                table: "Orders",
                column: "DebtorId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Subscribers_SubscriberId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Subscribers_SubscriberId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Subscribers_SubscriberId1",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Subscribers_SubscriberId",
                table: "Employers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lienholders_Subscribers_SubscriberId",
                table: "Lienholders");

            migrationBuilder.DropForeignKey(
                name: "FK_MakeModels_Subscribers_SubscriberId",
                table: "MakeModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Subscribers_SubscriberId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Subscribers_SubscriberId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Employers_EmployerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Orders_OrderId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "PoliceDepartments");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Lienholders");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "MakeModels");
        }
    }
}
