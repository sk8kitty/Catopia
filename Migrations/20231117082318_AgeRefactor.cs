using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catopia.Migrations
{
    public partial class AgeRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdoptionDescription",
                table: "Cats");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Cats",
                newName: "BriefDescription");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "Cats",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Cats");

            migrationBuilder.RenameColumn(
                name: "BriefDescription",
                table: "Cats",
                newName: "Age");

            migrationBuilder.AddColumn<string>(
                name: "AdoptionDescription",
                table: "Cats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
