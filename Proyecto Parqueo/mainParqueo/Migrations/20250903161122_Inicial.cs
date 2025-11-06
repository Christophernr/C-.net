using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mainParqueo.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PARQUEO",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    capacidadMaxima = table.Column<int>(type: "int", nullable: false),
                    capacidadLey7600 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARQUEO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "SPOTS",
                columns: table => new
                {
                    id_spot = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Parqueo_id_fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPOTS", x => x.id_spot);
                    table.ForeignKey(
                        name: "FK_SPOTS_PARQUEO_Parqueo_id_fk",
                        column: x => x.Parqueo_id_fk,
                        principalTable: "PARQUEO",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ROLESUSUARIO",
                columns: table => new
                {
                    id_rol_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario_fk = table.Column<int>(type: "int", nullable: false),
                    id_role_fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLESUSUARIO", x => x.id_rol_usuario);
                    table.ForeignKey(
                        name: "FK_ROLESUSUARIO_ROLES_id_role_fk",
                        column: x => x.id_role_fk,
                        principalTable: "ROLES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROLESUSUARIO_Usuario_id_usuario_fk",
                        column: x => x.id_usuario_fk,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VEHICULOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_usuario_fkVehiculo = table.Column<int>(type: "int", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_parqueo_fk = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICULOS", x => x.id);
                    table.ForeignKey(
                        name: "FK_VEHICULOS_PARQUEO_id_parqueo_fk",
                        column: x => x.id_parqueo_fk,
                        principalTable: "PARQUEO",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_VEHICULOS_Usuario_id_usuario_fkVehiculo",
                        column: x => x.id_usuario_fkVehiculo,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LOGS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_vehiculo_fk = table.Column<int>(type: "int", nullable: false),
                    placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGS", x => x.id);
                    table.ForeignKey(
                        name: "FK_LOGS_VEHICULOS_id_vehiculo_fk",
                        column: x => x.id_vehiculo_fk,
                        principalTable: "VEHICULOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OCUPACION",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_vehiculo_fk = table.Column<int>(type: "int", nullable: false),
                    id_spot_fk = table.Column<int>(type: "int", nullable: false),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCUPACION", x => x.id);
                    table.ForeignKey(
                        name: "FK_OCUPACION_SPOTS_id_spot_fk",
                        column: x => x.id_spot_fk,
                        principalTable: "SPOTS",
                        principalColumn: "id_spot",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OCUPACION_VEHICULOS_id_vehiculo_fk",
                        column: x => x.id_vehiculo_fk,
                        principalTable: "VEHICULOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LOGS_id_vehiculo_fk",
                table: "LOGS",
                column: "id_vehiculo_fk");

            migrationBuilder.CreateIndex(
                name: "IX_OCUPACION_id_spot_fk",
                table: "OCUPACION",
                column: "id_spot_fk");

            migrationBuilder.CreateIndex(
                name: "IX_OCUPACION_id_vehiculo_fk",
                table: "OCUPACION",
                column: "id_vehiculo_fk");

            migrationBuilder.CreateIndex(
                name: "IX_ROLESUSUARIO_id_role_fk",
                table: "ROLESUSUARIO",
                column: "id_role_fk");

            migrationBuilder.CreateIndex(
                name: "IX_ROLESUSUARIO_id_usuario_fk",
                table: "ROLESUSUARIO",
                column: "id_usuario_fk");

            migrationBuilder.CreateIndex(
                name: "IX_SPOTS_Parqueo_id_fk",
                table: "SPOTS",
                column: "Parqueo_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_usuario",
                table: "Usuario",
                column: "usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VEHICULOS_id_parqueo_fk",
                table: "VEHICULOS",
                column: "id_parqueo_fk");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICULOS_id_usuario_fkVehiculo",
                table: "VEHICULOS",
                column: "id_usuario_fkVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICULOS_placa",
                table: "VEHICULOS",
                column: "placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGS");

            migrationBuilder.DropTable(
                name: "OCUPACION");

            migrationBuilder.DropTable(
                name: "ROLESUSUARIO");

            migrationBuilder.DropTable(
                name: "SPOTS");

            migrationBuilder.DropTable(
                name: "VEHICULOS");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "PARQUEO");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
