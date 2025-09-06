using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstagramClone.Migrations
{
    /// <inheritdoc />
    public partial class AddBannerField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileBannerUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileBannerUrl",
                table: "Users");
        }
    }
}
