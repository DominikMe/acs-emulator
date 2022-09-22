using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcsEmulatorAPI.Migrations
{
    public partial class AddParticipantsAddedMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddParticipantsChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddParticipantsChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddParticipantsChatMessages_ChatMessages_Id",
                        column: x => x.Id,
                        principalTable: "ChatMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddedParticipant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ParticipantRawId = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    ShareHistoryTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    AddParticipantsChatMessageId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddedParticipant_AddParticipantsChatMessages_AddParticipantsChatMessageId",
                        column: x => x.AddParticipantsChatMessageId,
                        principalTable: "AddParticipantsChatMessages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AddedParticipant_Users_ParticipantRawId",
                        column: x => x.ParticipantRawId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddedParticipant_AddParticipantsChatMessageId",
                table: "AddedParticipant",
                column: "AddParticipantsChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_AddedParticipant_ParticipantRawId",
                table: "AddedParticipant",
                column: "ParticipantRawId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddedParticipant");

            migrationBuilder.DropTable(
                name: "AddParticipantsChatMessages");
        }
    }
}
