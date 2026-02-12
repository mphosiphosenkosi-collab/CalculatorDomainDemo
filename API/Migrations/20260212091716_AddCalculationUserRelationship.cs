using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculationUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Calculation",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Calculation",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Calculation",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Calculation_UserId",
                table: "Calculation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculation_AspNetUsers_UserId",
                table: "Calculation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculation_AspNetUsers_UserId",
                table: "Calculation");

            migrationBuilder.DropIndex(
                name: "IX_Calculation_UserId",
                table: "Calculation");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Calculation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Calculation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Calculation");
        }
    }
}
