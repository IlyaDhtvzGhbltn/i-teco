using System;
using CRMManager.Web.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMManager.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ConferenceTheme = table.Column<string>(maxLength: 255, nullable: false),
                    ConferenceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    ConferenceID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Conferences_ConferenceID",
                        column: x => x.ConferenceID,
                        principalTable: "Conferences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContactID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Surname = table.Column<string>(maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContactForms_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ContactFormID = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(maxLength: 17, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DeactivationDate = table.Column<DateTime>(nullable: false),
                    DeactivationReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phones_ContactForms_ContactFormID",
                        column: x => x.ContactFormID,
                        principalTable: "ContactForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    СallerID = table.Column<Guid>(nullable: true),
                    CallReceiverID = table.Column<Guid>(nullable: true),
                    CallDate = table.Column<DateTime>(nullable: false),
                    CallTimeSec = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Calls_Phones_CallReceiverID",
                        column: x => x.CallReceiverID,
                        principalTable: "Phones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calls_Phones_СallerID",
                        column: x => x.СallerID,
                        principalTable: "Phones",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CallReceiverID",
                table: "Calls",
                column: "CallReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_СallerID",
                table: "Calls",
                column: "СallerID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactForms_ContactID",
                table: "ContactForms",
                column: "ContactID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ConferenceID",
                table: "Contacts",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ContactFormID",
                table: "Phones",
                column: "ContactFormID",
                unique: true);


            DbSeeder seeder = new DbSeeder(migrationBuilder);
            seeder.Seed();



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
