using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class addVentas : Migration
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
                    table.PrimaryKey("PK__Clientes__71ABD0A7CC0121A9", x => x.ClienteID);
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
                    table.PrimaryKey("PK__Concesio__CFF65D10380DF6EE", x => x.ConcesionarioID);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoID = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Anio = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__AA088620750440D2", x => x.VehiculoID);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionID = table.Column<int>(type: "int", nullable: false),
                    VehiculoID = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: true),
                    ConcesionarioID = table.Column<int>(type: "int", nullable: true),
                    FechaVenta = table.Column<DateTime>(type: "datetime", nullable: true),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transacc__86A849DE41277288", x => x.TransaccionID);
                    table.ForeignKey(
                        name: "FK__Transacci__Clien__690797E6",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID");
                    table.ForeignKey(
                        name: "FK__Transacci__Conce__69FBBC1F",
                        column: x => x.ConcesionarioID,
                        principalTable: "Concesionarios",
                        principalColumn: "ConcesionarioID");
                    table.ForeignKey(
                        name: "FK__Transacci__Vehic__681373AD",
                        column: x => x.VehiculoID,
                        principalTable: "Vehiculos",
                        principalColumn: "VehiculoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ClienteID",
                table: "Transacciones",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_ConcesionarioID",
                table: "Transacciones",
                column: "ConcesionarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_VehiculoID",
                table: "Transacciones",
                column: "VehiculoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Concesionarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");
        }
    }
}
