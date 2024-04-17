using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOnly = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NeededItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialPrice = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeededItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NeededItems_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectionCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectionCommittees_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecifictionCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecifictionCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecifictionCommittees_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCommittees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCommittees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalCommittees_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Offers_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeededItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_ValidItems_NeededItems_NeededItemId",
                        column: x => x.NeededItemId,
                        principalTable: "NeededItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectionCommitteeMembers",
                columns: table => new
                {
                    SelectionCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionCommitteeMembers", x => new { x.MemberId, x.SelectionCommitteeId });
                    table.ForeignKey(
                        name: "FK_SelectionCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectionCommitteeMembers_SelectionCommittees_SelectionCommitteeId",
                        column: x => x.SelectionCommitteeId,
                        principalTable: "SelectionCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecifictionCommitteeMembers",
                columns: table => new
                {
                    SpecifictionCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecifictionCommitteeMembers", x => new { x.MemberId, x.SpecifictionCommitteeId });
                    table.ForeignKey(
                        name: "FK_SpecifictionCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecifictionCommitteeMembers_SpecifictionCommittees_SpecifictionCommitteeId",
                        column: x => x.SpecifictionCommitteeId,
                        principalTable: "SpecifictionCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCommitteeMembers",
                columns: table => new
                {
                    TechnicalCommitteeId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCommitteeMembers", x => new { x.MemberId, x.TechnicalCommitteeId });
                    table.ForeignKey(
                        name: "FK_TechnicalCommitteeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicalCommitteeMembers_TechnicalCommittees_TechnicalCommitteeId",
                        column: x => x.TechnicalCommitteeId,
                        principalTable: "TechnicalCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepnItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValidItemId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepnItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepnItems_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepnItems_ValidItems_ValidItemId",
                        column: x => x.ValidItemId,
                        principalTable: "ValidItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValidItemOffers",
                columns: table => new
                {
                    ValidItemId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidItemOffers", x => new { x.OfferId, x.ValidItemId });
                    table.ForeignKey(
                        name: "FK_ValidItemOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidItemOffers_ValidItems_ValidItemId",
                        column: x => x.ValidItemId,
                        principalTable: "ValidItems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Num = table.Column<int>(type: "int", nullable: false),
                    StepnItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_AcceptedItems_StepnItems_StepnItemId",
                        column: x => x.StepnItemId,
                        principalTable: "StepnItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Ahmed Mohamed", "Ahmed000@111" },
                    { 2, "Ahmed Shapaan", "Ahmed000@111" },
                    { 3, "Ahmed Tamer", "Ahmed000@111" },
                    { 4, "Safwa Mohamed", "Safwa000@111" },
                    { 5, "Sohila Amr", "Sohila000@111" },
                    { 6, "Yasmine Abdelrhman", "Yasmine000@111" },
                    { 7, "Zaid Adel", "Zaid000@111" },
                    { 8, "Amal Sabry", "Amal000@111" },
                    { 9, "Tarek Elsheshtawy", "Tarek000@111" },
                    { 10, "Amainy Saaed", "Amainy000@111" },
                    { 11, "Fady Fady", "Fady000@111" },
                    { 12, "Mohamed Abdelfataah", "Mohamed000@111" },
                    { 13, "Karam Karam", "Ahmed000@111" },
                    { 14, "Ahmed Shalaby", "Ahmed000@111" },
                    { 15, "Ahmed Taha", "Ahmed000@111" },
                    { 16, "Mahmmud Ghonam", null },
                    { 17, "Rayan Ghonam", null },
                    { 18, "Yousef Hiatham", null },
                    { 19, "Ahmed Hosny", null }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "Ahmed Shapaan" },
                    { 2, "Safwa Mohamed" },
                    { 3, "Ahmed Mohamed" },
                    { 4, "Sohila Amr" },
                    { 5, "Amal Sabry" },
                    { 6, "Yasmine Abdelrhman" },
                    { 7, "Ahmed Ramadan" },
                    { 8, "Zaid Adel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedItems_StepnItemId",
                table: "AcceptedItems",
                column: "StepnItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NeededItems_TenderId",
                table: "NeededItems",
                column: "TenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_VendorId",
                table: "Offers",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectionCommitteeMembers_SelectionCommitteeId",
                table: "SelectionCommitteeMembers",
                column: "SelectionCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectionCommittees_TenderId",
                table: "SelectionCommittees",
                column: "TenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecifictionCommitteeMembers_SpecifictionCommitteeId",
                table: "SpecifictionCommitteeMembers",
                column: "SpecifictionCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecifictionCommittees_TenderId",
                table: "SpecifictionCommittees",
                column: "TenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StepnItems_OfferId",
                table: "StepnItems",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_StepnItems_ValidItemId",
                table: "StepnItems",
                column: "ValidItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalCommitteeMembers_TechnicalCommitteeId",
                table: "TechnicalCommitteeMembers",
                column: "TechnicalCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalCommittees_TenderId",
                table: "TechnicalCommittees",
                column: "TenderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ValidItemOffers_ValidItemId",
                table: "ValidItemOffers",
                column: "ValidItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ValidItems_NeededItemId",
                table: "ValidItems",
                column: "NeededItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedItems");

            migrationBuilder.DropTable(
                name: "SelectionCommitteeMembers");

            migrationBuilder.DropTable(
                name: "SpecifictionCommitteeMembers");

            migrationBuilder.DropTable(
                name: "TechnicalCommitteeMembers");

            migrationBuilder.DropTable(
                name: "ValidItemOffers");

            migrationBuilder.DropTable(
                name: "StepnItems");

            migrationBuilder.DropTable(
                name: "SelectionCommittees");

            migrationBuilder.DropTable(
                name: "SpecifictionCommittees");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "TechnicalCommittees");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "ValidItems");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "NeededItems");

            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
