using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcsEmulatorAPI.Migrations
{
    public partial class AddChatMessageSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessage_ChatThreads_ChatThreadId",
                table: "ChatMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage");

            migrationBuilder.RenameTable(
                name: "ChatMessage",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessage_ChatThreadId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ChatThreadId");

            migrationBuilder.AddColumn<string>(
                name: "SenderRawId",
                table: "ChatMessages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderRawId",
                table: "ChatMessages",
                column: "SenderRawId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatThreads_ChatThreadId",
                table: "ChatMessages",
                column: "ChatThreadId",
                principalTable: "ChatThreads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Users_SenderRawId",
                table: "ChatMessages",
                column: "SenderRawId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatThreads_ChatThreadId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Users_SenderRawId",
                table: "ChatMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_SenderRawId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "SenderRawId",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "ChatMessage");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ChatThreadId",
                table: "ChatMessage",
                newName: "IX_ChatMessage_ChatThreadId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessage",
                table: "ChatMessage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessage_ChatThreads_ChatThreadId",
                table: "ChatMessage",
                column: "ChatThreadId",
                principalTable: "ChatThreads",
                principalColumn: "Id");
        }
    }
}
