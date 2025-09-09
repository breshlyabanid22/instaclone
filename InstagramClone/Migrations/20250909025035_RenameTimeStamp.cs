using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InstagramClone.Migrations
{
    /// <inheritdoc />
    public partial class RenameTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "Posts",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Posts",
                newName: "TimeStamp");
        }
    }
}
