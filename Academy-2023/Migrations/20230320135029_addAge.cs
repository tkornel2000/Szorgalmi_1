using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academy_2023.Migrations
{
    public partial class addAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Courses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "id");
        }
    }
}
