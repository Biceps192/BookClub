using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookClubApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberProfileTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberProfileId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MemberProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberProfileGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberProfileId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberProfileGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberProfileGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberProfileGenres_MemberProfiles_MemberProfileId",
                        column: x => x.MemberProfileId,
                        principalTable: "MemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberProfileId",
                table: "Users",
                column: "MemberProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfileGenres_GenreId",
                table: "MemberProfileGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProfileGenres_MemberProfileId",
                table: "MemberProfileGenres",
                column: "MemberProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MemberProfiles_MemberProfileId",
                table: "Users",
                column: "MemberProfileId",
                principalTable: "MemberProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MemberProfiles_MemberProfileId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "MemberProfileGenres");

            migrationBuilder.DropTable(
                name: "MemberProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_MemberProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MemberProfileId",
                table: "Users");
        }
    }
}
