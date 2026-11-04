using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DueñoConVariasMascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Primero se crea la FK nueva en Mascotas, después se copian los vínculos que
            // existían en Dueño.MascotaId y recién entonces se borra la columna vieja.
            migrationBuilder.AddColumn<int>(
                name: "DueñoId",
                table: "Mascotas",
                type: "integer",
                nullable: true);

            migrationBuilder.Sql(
                @"UPDATE ""Mascotas"" AS m
                  SET ""DueñoId"" = d.""Id""
                  FROM ""Dueño"" AS d
                  WHERE d.""MascotaId"" = m.""Id"";");

            migrationBuilder.DropForeignKey(
                name: "FK_Dueño_Mascotas_MascotaId",
                table: "Dueño");

            migrationBuilder.DropIndex(
                name: "IX_Dueño_MascotaId",
                table: "Dueño");

            migrationBuilder.DropColumn(
                name: "MascotaId",
                table: "Dueño");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_DueñoId",
                table: "Mascotas",
                column: "DueñoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Dueño_DueñoId",
                table: "Mascotas",
                column: "DueñoId",
                principalTable: "Dueño",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Dueño_DueñoId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_DueñoId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "DueñoId",
                table: "Mascotas");

            migrationBuilder.AddColumn<int>(
                name: "MascotaId",
                table: "Dueño",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dueño_MascotaId",
                table: "Dueño",
                column: "MascotaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dueño_Mascotas_MascotaId",
                table: "Dueño",
                column: "MascotaId",
                principalTable: "Mascotas",
                principalColumn: "Id");
        }
    }
}
