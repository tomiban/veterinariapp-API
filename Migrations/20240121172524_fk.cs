using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosis_Vacunas_VacunaId",
                table: "Dosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacunas_Mascotas_MascotaId",
                table: "Vacunas");

            migrationBuilder.AlterColumn<int>(
                name: "MascotaId",
                table: "Vacunas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VacunaId",
                table: "Dosis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dosis_Vacunas_VacunaId",
                table: "Dosis",
                column: "VacunaId",
                principalTable: "Vacunas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacunas_Mascotas_MascotaId",
                table: "Vacunas",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dosis_Vacunas_VacunaId",
                table: "Dosis");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacunas_Mascotas_MascotaId",
                table: "Vacunas");

            migrationBuilder.AlterColumn<int>(
                name: "MascotaId",
                table: "Vacunas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VacunaId",
                table: "Dosis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dosis_Vacunas_VacunaId",
                table: "Dosis",
                column: "VacunaId",
                principalTable: "Vacunas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacunas_Mascotas_MascotaId",
                table: "Vacunas",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "Id");
        }
    }
}
