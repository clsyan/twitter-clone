using Microsoft.EntityFrameworkCore.Migrations;

namespace twitter_clone.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    At = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.At, x.Email });
                });

            migrationBuilder.CreateTable(
                name: "UserUser",
                columns: table => new
                {
                    FollowersAt = table.Column<string>(type: "TEXT", nullable: false),
                    FollowersEmail = table.Column<string>(type: "TEXT", nullable: false),
                    FollowingAt = table.Column<string>(type: "TEXT", nullable: false),
                    FollowingEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUser", x => new { x.FollowersAt, x.FollowersEmail, x.FollowingAt, x.FollowingEmail });
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowersAt_FollowersEmail",
                        columns: x => new { x.FollowersAt, x.FollowersEmail },
                        principalTable: "Users",
                        principalColumns: new[] { "At", "Email" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUser_Users_FollowingAt_FollowingEmail",
                        columns: x => new { x.FollowingAt, x.FollowingEmail },
                        principalTable: "Users",
                        principalColumns: new[] { "At", "Email" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUser_FollowingAt_FollowingEmail",
                table: "UserUser",
                columns: new[] { "FollowingAt", "FollowingEmail" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUser");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
