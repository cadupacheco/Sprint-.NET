using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_NET.Migrations
{
    /// <inheritdoc />
    public partial class AddMobileCompatibilityFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Fabricante = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Cor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    LocationX = table.Column<double>(type: "REAL", nullable: false),
                    LocationY = table.Column<double>(type: "REAL", nullable: false),
                    BatteryLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    Mileage = table.Column<int>(type: "INTEGER", nullable: false),
                    NextMaintenanceDate = table.Column<string>(type: "TEXT", maxLength: 19, nullable: true),
                    AssignedBranch = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TechnicalInfo = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    ModeloId = table.Column<int>(type: "INTEGER", nullable: false),
                    PatioId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motos_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motos_Patios_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motos_ModeloId",
                table: "Motos",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_PatioId",
                table: "Motos",
                column: "PatioId");

            migrationBuilder.CreateIndex(
                name: "IX_Motos_Placa",
                table: "Motos",
                column: "Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motos");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Patios");
        }
    }
}
