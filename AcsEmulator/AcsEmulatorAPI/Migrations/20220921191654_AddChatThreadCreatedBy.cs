using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcsEmulatorAPI.Migrations
{
    public partial class AddChatThreadCreatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByRawId",
                table: "ChatThreads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatThreads_CreatedByRawId",
                table: "ChatThreads",
                column: "CreatedByRawId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatThreads_Users_CreatedByRawId",
                table: "ChatThreads",
                column: "CreatedByRawId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatThreads_Users_CreatedByRawId",
                table: "ChatThreads");

            migrationBuilder.DropIndex(
                name: "IX_ChatThreads_CreatedByRawId",
                table: "ChatThreads");

            migrationBuilder.DropColumn(
                name: "CreatedByRawId",
                table: "ChatThreads");
        }
    }
}
