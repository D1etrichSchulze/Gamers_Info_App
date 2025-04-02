using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersInfoApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameGenre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Gamer",
                columns: table => new
                {
                    GamerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GamerAge = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamer", x => x.GamerID);
                });

            migrationBuilder.CreateTable(
                name: "Gamer_Game",
                columns: table => new
                {
                    GamerGameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamerID = table.Column<int>(type: "int", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    HoursPlayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamer_Game", x => x.GamerGameID);
                    table.ForeignKey(
                        name: "FK_Gamer_Game_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gamer_Game_Gamer_GamerID",
                        column: x => x.GamerID,
                        principalTable: "Gamer",
                        principalColumn: "GamerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gamer_Game_GameID",
                table: "Gamer_Game",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Gamer_Game_GamerID",
                table: "Gamer_Game",
                column: "GamerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gamer_Game");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Gamer");
        }
    }
}
