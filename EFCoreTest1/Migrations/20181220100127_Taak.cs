using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreTest1.Migrations
{
    public partial class Taak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    TaakId = table.Column<int>(nullable: true),
                    TaakId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusHistories_Taken_TaakId",
                        column: x => x.TaakId,
                        principalTable: "Taken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_TaakId",
                table: "StatusHistories",
                column: "TaakId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusHistories_TaakId1",
                table: "StatusHistories",
                column: "TaakId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusHistories");

            migrationBuilder.DropTable(
                name: "Taken");
        }
    }
}
