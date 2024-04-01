using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Adding_sqlTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__71ABD0A71631344F", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Concesionarios",
                columns: table => new
                {
                    ConcesionarioID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Concesio__CFF65D10543D01CC", x => x.ConcesionarioID);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoID = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ConcesionarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__AA08862047037CFC", x => x.VehiculoID);
                    table.ForeignKey(
                        name: "FK__Vehiculos__Conce__1A69E950",
                        column: x => x.ConcesionarioID,
                        principalTable: "Concesionarios",
                        principalColumn: "ConcesionarioID");
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoID = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    FechaVenta = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transacc__86A849DECBBD3BC0", x => x.TransaccionID);
                    table.ForeignKey(
                        name: "FK__Transacci__Clien__2116E6DF",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK__Transacci__Vehic__2022C2A6",
                        column: x => x.VehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "VehiculoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ClienteID",
                table: "Transacciones",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "UQ__Transacc__AA08862182B70625",
                table: "Transacciones",
                column: "VehiculoID",
                unique: true,
                filter: "[VehiculoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_ConcesionarioID",
                table: "Vehiculos",
                column: "ConcesionarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Concesionarios");
        }
    }
}
