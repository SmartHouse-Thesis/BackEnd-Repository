using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarrantyReport_Acceptances_AcceptanceId",
                table: "WarrantyReport");

            migrationBuilder.DropIndex(
                name: "IX_WarrantyReport_AcceptanceId",
                table: "WarrantyReport");

            migrationBuilder.DropColumn(
                name: "AcceptanceId",
                table: "WarrantyReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcceptanceId",
                table: "WarrantyReport",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyReport_AcceptanceId",
                table: "WarrantyReport",
                column: "AcceptanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarrantyReport_Acceptances_AcceptanceId",
                table: "WarrantyReport",
                column: "AcceptanceId",
                principalTable: "Acceptances",
                principalColumn: "Id");
        }
    }
}
