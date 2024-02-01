using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class addatributesdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDosis",
                table: "Dosis");

            migrationBuilder.AddColumn<int>(
                name: "CantidadDosis",
                table: "Vacunas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSiguienteAplicacion",
                table: "Dosis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantidadDosis",
                table: "Vacunas");

            migrationBuilder.DropColumn(
                name: "FechaSiguienteAplicacion",
                table: "Dosis");

            migrationBuilder.AddColumn<int>(
                name: "NumeroDosis",
                table: "Dosis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
