using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorOfficeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorOfficeEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecializationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecializationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientEntity_AreaEntity_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEntity_AreaEntity_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreaEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DoctorEntity_DoctorOfficeEntity_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "DoctorOfficeEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorEntity_DoctorSpecializationEntity_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "DoctorSpecializationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AreaEntity",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "DoctorOfficeEntity",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "DoctorSpecializationEntity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Терапевт" },
                    { 2, "Психиатр" },
                    { 3, "Стоматолог" },
                    { 4, "Ортопед" },
                    { 5, "Офтальмолог" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntity_AreaId",
                table: "DoctorEntity",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntity_OfficeId",
                table: "DoctorEntity",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntity_SpecializationId",
                table: "DoctorEntity",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEntity_AreaId",
                table: "PatientEntity",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorEntity");

            migrationBuilder.DropTable(
                name: "PatientEntity");

            migrationBuilder.DropTable(
                name: "DoctorOfficeEntity");

            migrationBuilder.DropTable(
                name: "DoctorSpecializationEntity");

            migrationBuilder.DropTable(
                name: "AreaEntity");
        }
    }
}
