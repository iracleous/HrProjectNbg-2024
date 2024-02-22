using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrProjectNbg_2024.Migrations
{
    /// <inheritdoc />
    public partial class D3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeCategory",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeCategory",
                table: "Employees");
        }
    }
}
