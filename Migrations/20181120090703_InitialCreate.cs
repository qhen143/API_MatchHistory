using Microsoft.EntityFrameworkCore.Migrations;

namespace API_MatchHistory.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchHistoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Game = table.Column<string>(nullable: true),
                    Home = table.Column<string>(nullable: true),
                    Opposition = table.Column<string>(nullable: true),
                    Winner = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistoryItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchHistoryItem");
        }
    }
}
