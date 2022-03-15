using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_2_Linq.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Lärare",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Lärare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_Kurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LärareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Kurs__Lärare_LärareId",
                        column: x => x.LärareId,
                        principalTable: "_Lärare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_Ämne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LärareId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ämne", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Ämne__Lärare_LärareId",
                        column: x => x.LärareId,
                        principalTable: "_Lärare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    KursId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Student__Kurs_KursId",
                        column: x => x.KursId,
                        principalTable: "_Kurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Kurs_LärareId",
                table: "_Kurs",
                column: "LärareId");

            migrationBuilder.CreateIndex(
                name: "IX__Student_KursId",
                table: "_Student",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX__Ämne_LärareId",
                table: "_Ämne",
                column: "LärareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Student");

            migrationBuilder.DropTable(
                name: "_Ämne");

            migrationBuilder.DropTable(
                name: "_Kurs");

            migrationBuilder.DropTable(
                name: "_Lärare");
        }
    }
}
