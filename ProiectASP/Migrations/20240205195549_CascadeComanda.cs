using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectASP.Migrations
{
    public partial class CascadeComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_AspNetUsers_UserID",
                table: "Comanda");

            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Produs_ProdusID",
                table: "Comanda");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_AspNetUsers_UserID",
                table: "Comanda",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Produs_ProdusID",
                table: "Comanda",
                column: "ProdusID",
                principalTable: "Produs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_AspNetUsers_UserID",
                table: "Comanda");

            migrationBuilder.DropForeignKey(
                name: "FK_Comanda_Produs_ProdusID",
                table: "Comanda");

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_AspNetUsers_UserID",
                table: "Comanda",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comanda_Produs_ProdusID",
                table: "Comanda",
                column: "ProdusID",
                principalTable: "Produs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
