using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlancherExpertWebServices.Migrations
{
    /// <inheritdoc />
    public partial class PlancherExpert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CouvrePlancher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrixMa = table.Column<float>(type: "real", nullable: false),
                    PrixMo = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouvrePlancher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    CommandeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Largeur = table.Column<double>(type: "float", nullable: false),
                    Longueur = table.Column<double>(type: "float", nullable: false),
                    ClientData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CPId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.CommandeId);
                    table.ForeignKey(
                        name: "FK_Commande_CouvrePlancher_CPId",
                        column: x => x.CPId,
                        principalTable: "CouvrePlancher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commande_CPId",
                table: "Commande",
                column: "CPId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "CouvrePlancher");
        }
    }
}
