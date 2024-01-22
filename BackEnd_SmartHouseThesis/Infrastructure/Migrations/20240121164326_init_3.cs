using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceptances_Constracts_ConstractId",
                table: "Acceptances");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Accounts_AccountId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "WarrantyReport");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_AccountId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Acceptances_ConstractId",
                table: "Acceptances");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "WarrantyTime",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "EndWarranty",
                table: "Acceptances");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Device",
                newName: "DeviceType");

            migrationBuilder.RenameColumn(
                name: "ConstractId",
                table: "Acceptances",
                newName: "ContractId");

            migrationBuilder.AddColumn<Guid>(
                name: "ManufacturerId",
                table: "Tellers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Promotion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Promotion",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManufacturerId",
                table: "Packages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PolicyId",
                table: "Packages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManufacturerId",
                table: "Device",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Device",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConstructStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConstructEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Policy_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_Id",
                        column: x => x.Id,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tellers_ManufacturerId",
                table: "Tellers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_ManufacturerId",
                table: "Device",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_OrderId",
                table: "Device",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Acceptances_ContractId",
                table: "Acceptances",
                column: "ContractId",
                unique: true,
                filter: "[ContractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_PackageId",
                table: "Manufacturer",
                column: "PackageId",
                unique: true,
                filter: "[PackageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentId",
                table: "Order",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StaffId",
                table: "Order",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_DeviceId",
                table: "OrderDetail",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_OwnerId",
                table: "Policy",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PackageId",
                table: "Policy",
                column: "PackageId",
                unique: true,
                filter: "[PackageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceptances_Constracts_ContractId",
                table: "Acceptances",
                column: "ContractId",
                principalTable: "Constracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_Order_OrderId",
                table: "Device",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tellers_Manufacturer_ManufacturerId",
                table: "Tellers",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceptances_Constracts_ContractId",
                table: "Acceptances");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Manufacturer_ManufacturerId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Device_Order_OrderId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_Tellers_Manufacturer_ManufacturerId",
                table: "Tellers");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Tellers_ManufacturerId",
                table: "Tellers");

            migrationBuilder.DropIndex(
                name: "IX_Device_ManufacturerId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_OrderId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Acceptances_ContractId",
                table: "Acceptances");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Tellers");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Device");

            migrationBuilder.RenameColumn(
                name: "DeviceType",
                table: "Device",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "ContractId",
                table: "Acceptances",
                newName: "ConstractId");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountId",
                table: "Surveys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Device",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarrantyTime",
                table: "Device",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndWarranty",
                table: "Acceptances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WarrantyReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    ModificationBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantyReport_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarrantyReport_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AccountId",
                table: "Surveys",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Acceptances_ConstractId",
                table: "Acceptances",
                column: "ConstractId",
                unique: true,
                filter: "[ConstractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyReport_DeviceId",
                table: "WarrantyReport",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyReport_StaffId",
                table: "WarrantyReport",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceptances_Constracts_ConstractId",
                table: "Acceptances",
                column: "ConstractId",
                principalTable: "Constracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Accounts_AccountId",
                table: "Surveys",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
