using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberProfiles_UserId",
                table: "MemberProfiles");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfiles_UserId",
                table: "MemberProfiles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberProfiles_UserId",
                table: "MemberProfiles");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfiles_UserId",
                table: "MemberProfiles",
                column: "UserId",
                unique: true);
        }
    }
}
