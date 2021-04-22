using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.DataAccess.Migrations
{
    public partial class Added_Color_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 2309453);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Category");
        }
    }
}
