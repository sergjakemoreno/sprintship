using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SprintTek.Migrations
{
    public partial class Added_Phone_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_phones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    Number = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_phones_tbl_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "tbl_persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_phones_PersonId",
                table: "tbl_phones",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_phones");
        }
    }
}
