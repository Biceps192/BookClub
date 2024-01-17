using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberProfiles_MemberProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MemberProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MemberProfileId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MemberProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfiles_UserId",
                table: "MemberProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProfiles_Users_UserId",
                table: "MemberProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProfiles_Users_UserId",
                table: "MemberProfiles");

            migrationBuilder.DropIndex(
                name: "IX_MemberProfiles_UserId",
                table: "MemberProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MemberProfiles");

            migrationBuilder.AddColumn<int>(
                name: "MemberProfileId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberProfileId",
                table: "Users",
                column: "MemberProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberProfiles_MemberProfileId",
                table: "Users",
                column: "MemberProfileId",
                principalTable: "MemberProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
