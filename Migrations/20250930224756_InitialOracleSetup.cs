using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialOracleSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Patios",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Patios",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Patios",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicalInfo",
                table: "Motos",
                type: "NVARCHAR2(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Motos",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Motos",
                type: "NVARCHAR2(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "PatioId",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NextMaintenanceDate",
                table: "Motos",
                type: "NVARCHAR2(19)",
                maxLength: 19,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT(19)",
                oldMaxLength: 19,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModeloId",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Mileage",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "LocationY",
                table: "Motos",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "LocationX",
                table: "Motos",
                type: "BINARY_DOUBLE",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Motos",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "FuelLevel",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistro",
                table: "Motos",
                type: "TIMESTAMP(7)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Motos",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "BatteryLevel",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedBranch",
                table: "Motos",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Motos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Modelos",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Fabricante",
                table: "Modelos",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Modelos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Patios",
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Patios",
                type: "TEXT(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Patios",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicalInfo",
                table: "Motos",
                type: "TEXT(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Motos",
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Motos",
                type: "TEXT(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "PatioId",
                table: "Motos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "NextMaintenanceDate",
                table: "Motos",
                type: "TEXT(19)",
                maxLength: 19,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(19)",
                oldMaxLength: 19,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModeloId",
                table: "Motos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "Mileage",
                table: "Motos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<double>(
                name: "LocationY",
                table: "Motos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<double>(
                name: "LocationX",
                table: "Motos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "BINARY_DOUBLE");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Motos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<int>(
                name: "FuelLevel",
                table: "Motos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataRegistro",
                table: "Motos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TIMESTAMP(7)");

            migrationBuilder.AlterColumn<string>(
                name: "Cor",
                table: "Motos",
                type: "TEXT(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "BatteryLevel",
                table: "Motos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedBranch",
                table: "Motos",
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Motos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Modelos",
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Fabricante",
                table: "Modelos",
                type: "TEXT(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Modelos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }
    }
}
