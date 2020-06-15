using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontendAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Tel = table.Column<string>(type: "varchar(20)", nullable: true),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChannelSystems",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    ContactID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelSystems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChannelSystems_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChannelMessages",
                columns: table => new
                {
                    TransactionID = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    ParentTransactionID = table.Column<Guid>(nullable: true),
                    MessageBody = table.Column<string>(nullable: true),
                    ReceivedDate = table.Column<DateTimeOffset>(nullable: false),
                    ProcessingStatus = table.Column<int>(nullable: false),
                    SourceChannelID = table.Column<Guid>(nullable: false),
                    TargetChannelID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelMessages", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_ChannelMessages_ChannelMessages_ParentTransactionID",
                        column: x => x.ParentTransactionID,
                        principalTable: "ChannelMessages",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChannelMessages_ChannelSystems_SourceChannelID",
                        column: x => x.SourceChannelID,
                        principalTable: "ChannelSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChannelMessages_ChannelSystems_TargetChannelID",
                        column: x => x.TargetChannelID,
                        principalTable: "ChannelSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    ChannelId = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true),
                    FlowType = table.Column<int>(nullable: false),
                    ChannelSystemID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.ChannelId);
                    table.ForeignKey(
                        name: "FK_Channels_ChannelSystems_ChannelSystemID",
                        column: x => x.ChannelSystemID,
                        principalTable: "ChannelSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    TransactionID = table.Column<Guid>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ServerName = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    ChannelMessageTransactionID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Logs_ChannelMessages_ChannelMessageTransactionID",
                        column: x => x.ChannelMessageTransactionID,
                        principalTable: "ChannelMessages",
                        principalColumn: "TransactionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessages_ParentTransactionID",
                table: "ChannelMessages",
                column: "ParentTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessages_SourceChannelID",
                table: "ChannelMessages",
                column: "SourceChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelMessages_TargetChannelID",
                table: "ChannelMessages",
                column: "TargetChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_Channels_ChannelSystemID",
                table: "Channels",
                column: "ChannelSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_ChannelSystems_ContactID",
                table: "ChannelSystems",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_FirstName_LastName_Email",
                table: "Contacts",
                columns: new[] { "FirstName", "LastName", "Email" });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ChannelMessageTransactionID",
                table: "Logs",
                column: "ChannelMessageTransactionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "ChannelMessages");

            migrationBuilder.DropTable(
                name: "ChannelSystems");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
