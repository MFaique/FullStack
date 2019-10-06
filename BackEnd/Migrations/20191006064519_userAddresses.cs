using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Migrations
{
    public partial class userAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    address = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserAddress_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_userId",
                table: "UserAddress",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddress");
        }
    }
}
