using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "PatientEntity",
                newName: "Patronymic");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "PatientEntity",
                newName: "FamilyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Patronymic",
                table: "PatientEntity",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FamilyName",
                table: "PatientEntity",
                newName: "LastName");
        }
    }
}
