using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceptances_Constracts_ContractId",
                table: "Acceptances");

            migrationBuilder.DropForeignKey(
                name: "FK_Constracts_Customers_CustomerId",
                table: "Constracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Constracts_Revenues_RevenueId",
                table: "Constracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Constracts_Staff_StaffId",
                table: "Constracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Constracts_Tellers_TellerId",
                table: "Constracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Constracts_ContractId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Constracts_ContractId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Constracts",
                table: "Constracts");

            migrationBuilder.RenameTable(
                name: "Constracts",
                newName: "Contracts");

            migrationBuilder.RenameIndex(
                name: "IX_Constracts_TellerId",
                table: "Contracts",
                newName: "IX_Contracts_TellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Constracts_StaffId",
                table: "Contracts",
                newName: "IX_Contracts_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Constracts_RevenueId",
                table: "Contracts",
                newName: "IX_Contracts_RevenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Constracts_CustomerId",
                table: "Contracts",
                newName: "IX_Contracts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "DeletedBy", "IsDelete", "ModificationBy", "ModificationDate", "RoleName" },
                values: new object[,]
                {
                    { new Guid("16ea920a-8627-437c-8350-19efd59a8482"), null, null, null, null, null, null, "Owner" },
                    { new Guid("23f8ef1a-7f69-4d8b-bd0f-ee5b2ee067a5"), null, null, null, null, null, null, "Teller" },
                    { new Guid("c319d383-06d7-4720-9b75-694c0e5c0dca"), null, null, null, null, null, null, "Staff" },
                    { new Guid("cb0e966a-118a-49fd-8a6c-1f2f4bf74956"), null, null, null, null, null, null, "Customer" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Acceptances_Contracts_ContractId",
                table: "Acceptances",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Customers_CustomerId",
                table: "Contracts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Revenues_RevenueId",
                table: "Contracts",
                column: "RevenueId",
                principalTable: "Revenues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Staff_StaffId",
                table: "Contracts",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Tellers_TellerId",
                table: "Contracts",
                column: "TellerId",
                principalTable: "Tellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Contracts_ContractId",
                table: "Packages",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Contracts_ContractId",
                table: "Payment",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceptances_Contracts_ContractId",
                table: "Acceptances");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Customers_CustomerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Revenues_RevenueId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Staff_StaffId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Tellers_TellerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Contracts_ContractId",
                table: "Packages");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Contracts_ContractId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contracts",
                table: "Contracts");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("16ea920a-8627-437c-8350-19efd59a8482"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("23f8ef1a-7f69-4d8b-bd0f-ee5b2ee067a5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c319d383-06d7-4720-9b75-694c0e5c0dca"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("cb0e966a-118a-49fd-8a6c-1f2f4bf74956"));

            migrationBuilder.RenameTable(
                name: "Contracts",
                newName: "Constracts");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_TellerId",
                table: "Constracts",
                newName: "IX_Constracts_TellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_StaffId",
                table: "Constracts",
                newName: "IX_Constracts_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_RevenueId",
                table: "Constracts",
                newName: "IX_Constracts_RevenueId");

            migrationBuilder.RenameIndex(
                name: "IX_Contracts_CustomerId",
                table: "Constracts",
                newName: "IX_Constracts_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Constracts",
                table: "Constracts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceptances_Constracts_ContractId",
                table: "Acceptances",
                column: "ContractId",
                principalTable: "Constracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Constracts_Customers_CustomerId",
                table: "Constracts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Constracts_Revenues_RevenueId",
                table: "Constracts",
                column: "RevenueId",
                principalTable: "Revenues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Constracts_Staff_StaffId",
                table: "Constracts",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Constracts_Tellers_TellerId",
                table: "Constracts",
                column: "TellerId",
                principalTable: "Tellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Constracts_ContractId",
                table: "Packages",
                column: "ContractId",
                principalTable: "Constracts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Constracts_ContractId",
                table: "Payment",
                column: "ContractId",
                principalTable: "Constracts",
                principalColumn: "Id");
        }
    }
}
