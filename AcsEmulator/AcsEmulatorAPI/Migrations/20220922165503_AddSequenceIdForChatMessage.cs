﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcsEmulatorAPI.Migrations
{
    public partial class AddSequenceIdForChatMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SequenceId",
                table: "ChatMessages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "ChatMessages");
        }
    }
}
