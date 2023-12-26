using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectASP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdresaLivrare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresaLivrare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppReview",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataReview = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppReview", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataComenzii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProdusID = table.Column<int>(type: "int", nullable: false),
                    pret = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppReviewID = table.Column<int>(type: "int", nullable: true),
                    ComandaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_AppReview_AppReviewID",
                        column: x => x.AppReviewID,
                        principalTable: "AppReview",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_User_Comanda_ComandaID",
                        column: x => x.ComandaID,
                        principalTable: "Comanda",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ComandaProdus",
                columns: table => new
                {
                    ComenziID = table.Column<int>(type: "int", nullable: false),
                    ProduseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaProdus", x => new { x.ComenziID, x.ProduseID });
                    table.ForeignKey(
                        name: "FK_ComandaProdus_Comanda_ComenziID",
                        column: x => x.ComenziID,
                        principalTable: "Comanda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaProdus_Produs_ProduseID",
                        column: x => x.ProduseID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdresaLivrareUser",
                columns: table => new
                {
                    AdreseLivrareID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresaLivrareUser", x => new { x.AdreseLivrareID, x.UsersID });
                    table.ForeignKey(
                        name: "FK_AdresaLivrareUser_AdresaLivrare_AdreseLivrareID",
                        column: x => x.AdreseLivrareID,
                        principalTable: "AdresaLivrare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdresaLivrareUser_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdresaLivrareUser_UsersID",
                table: "AdresaLivrareUser",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProdus_ProduseID",
                table: "ComandaProdus",
                column: "ProduseID");

            migrationBuilder.CreateIndex(
                name: "IX_User_AppReviewID",
                table: "User",
                column: "AppReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_User_ComandaID",
                table: "User",
                column: "ComandaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdresaLivrareUser");

            migrationBuilder.DropTable(
                name: "ComandaProdus");

            migrationBuilder.DropTable(
                name: "AdresaLivrare");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Produs");

            migrationBuilder.DropTable(
                name: "AppReview");

            migrationBuilder.DropTable(
                name: "Comanda");
        }
    }
}
