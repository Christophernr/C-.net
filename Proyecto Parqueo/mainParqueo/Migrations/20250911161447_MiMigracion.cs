using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mainParqueo.Migrations
{
    /// <inheritdoc />
    public partial class MiMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPOTS_PARQUEO_Parqueo_id_fk",
                table: "SPOTS");

            migrationBuilder.DropForeignKey(
                name: "FK_VEHICULOS_PARQUEO_id_parqueo_fk",
                table: "VEHICULOS");

            migrationBuilder.DropIndex(
                name: "IX_VEHICULOS_id_parqueo_fk",
                table: "VEHICULOS");

            migrationBuilder.DropIndex(
                name: "IX_SPOTS_Parqueo_id_fk",
                table: "SPOTS");

            migrationBuilder.DropColumn(
                name: "id_parqueo_fk",
                table: "VEHICULOS");

            migrationBuilder.DropColumn(
                name: "Parqueo_id_fk",
                table: "SPOTS");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "VEHICULOS",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "VEHICULOS");

            migrationBuilder.AddColumn<int>(
                name: "id_parqueo_fk",
                table: "VEHICULOS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Parqueo_id_fk",
                table: "SPOTS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VEHICULOS_id_parqueo_fk",
                table: "VEHICULOS",
                column: "id_parqueo_fk");

            migrationBuilder.CreateIndex(
                name: "IX_SPOTS_Parqueo_id_fk",
                table: "SPOTS",
                column: "Parqueo_id_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_SPOTS_PARQUEO_Parqueo_id_fk",
                table: "SPOTS",
                column: "Parqueo_id_fk",
                principalTable: "PARQUEO",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VEHICULOS_PARQUEO_id_parqueo_fk",
                table: "VEHICULOS",
                column: "id_parqueo_fk",
                principalTable: "PARQUEO",
                principalColumn: "id");
        }
    }
}
