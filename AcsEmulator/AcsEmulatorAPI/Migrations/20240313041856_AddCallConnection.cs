using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcsEmulatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCallConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CallConnectionState = table.Column<int>(type: "INTEGER", nullable: false),
                    CallbackUri = table.Column<string>(type: "TEXT", nullable: true),
                    CognitiveServicesEndpoint = table.Column<string>(type: "TEXT", nullable: true),
                    CorrelationId = table.Column<string>(type: "TEXT", nullable: true),
                    ServerCallId = table.Column<string>(type: "TEXT", nullable: true),
                    SourceCallerIdNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallConnections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallConnectionTargets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RawId = table.Column<string>(type: "TEXT", nullable: true),
                    CallConnectionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallConnectionTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallConnectionTargets_CallConnections_CallConnectionId",
                        column: x => x.CallConnectionId,
                        principalTable: "CallConnections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallConnectionTargets_CallConnectionId",
                table: "CallConnectionTargets",
                column: "CallConnectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallConnectionTargets");

            migrationBuilder.DropTable(
                name: "CallConnections");
        }
    }
}
