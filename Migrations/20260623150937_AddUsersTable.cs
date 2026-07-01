using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagementSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salary",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employees",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employees",
                newName: "email");
        }
    }
}
