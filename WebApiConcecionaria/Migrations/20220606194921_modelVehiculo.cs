using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiConcecionaria.Migrations
{
    public partial class modelVehiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fechaModelo",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaModelo",
                table: "Vehiculos");
        }
    }
}
