using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApp.Migrations
{
    public partial class init_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_E_TELEPHONE_TEL",
                columns: table => new
                {
                    TEL_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEL_REFERENCE = table.Column<string>(type: "char(5)", nullable: true),
                    TEL_MARQUE = table.Column<string>(nullable: true),
                    TEL_MODELE = table.Column<string>(nullable: true),
                    TEL_MEMOIRE = table.Column<int>(nullable: false, defaultValue: 64),
                    TEL_DATESORTIE = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_E_TELEPHONE_TEL", x => x.TEL_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_E_TELEPHONE_TEL");
        }
    }
}
