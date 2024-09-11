using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrimaryInfos",
                columns: table => new
                {
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Employee_Id = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Employee_Name = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DateOfJoining = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryInfos", x => x.PrimaryInfoId);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSkills",
                columns: table => new
                {
                    Technical_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSkills", x => x.Technical_Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    Address_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoorNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandMark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.Address_Id);
                    table.ForeignKey(
                        name: "FK_AddressDetails_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    Bank_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNo = table.Column<long>(type: "bigint", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSC_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Bank_Id);
                    table.ForeignKey(
                        name: "FK_BankDetails_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Contact_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Contact_Id);
                    table.ForeignKey(
                        name: "FK_Contacts_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationDetails",
                columns: table => new
                {
                    Education_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfPassing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDetails", x => x.Education_Id);
                    table.ForeignKey(
                        name: "FK_EducationDetails_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Experience_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfExperience = table.Column<int>(type: "int", nullable: false),
                    DateOfJoing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfRelieving = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Experience_Id);
                    table.ForeignKey(
                        name: "FK_Experiences_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryInfos",
                columns: table => new
                {
                    Secondary_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharNo = table.Column<long>(type: "bigint", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryInfos", x => x.Secondary_Id);
                    table.ForeignKey(
                        name: "FK_SecondaryInfos_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryInfoTechnicalSkills",
                columns: table => new
                {
                    PrimaryInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicalSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryInfoTechnicalSkills", x => new { x.PrimaryInfoId, x.TechnicalSkillId });
                    table.ForeignKey(
                        name: "FK_PrimaryInfoTechnicalSkills_PrimaryInfos_PrimaryInfoId",
                        column: x => x.PrimaryInfoId,
                        principalTable: "PrimaryInfos",
                        principalColumn: "PrimaryInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrimaryInfoTechnicalSkills_TechnicalSkills_TechnicalSkillId",
                        column: x => x.TechnicalSkillId,
                        principalTable: "TechnicalSkills",
                        principalColumn: "Technical_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_PrimaryInfoId",
                table: "AddressDetails",
                column: "PrimaryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDetails_PrimaryInfoId",
                table: "BankDetails",
                column: "PrimaryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PrimaryInfoId",
                table: "Contacts",
                column: "PrimaryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationDetails_PrimaryInfoId",
                table: "EducationDetails",
                column: "PrimaryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PrimaryInfoId",
                table: "Experiences",
                column: "PrimaryInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryInfoTechnicalSkills_TechnicalSkillId",
                table: "PrimaryInfoTechnicalSkills",
                column: "TechnicalSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondaryInfos_PrimaryInfoId",
                table: "SecondaryInfos",
                column: "PrimaryInfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "EducationDetails");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "PrimaryInfoTechnicalSkills");

            migrationBuilder.DropTable(
                name: "SecondaryInfos");

            migrationBuilder.DropTable(
                name: "TechnicalSkills");

            migrationBuilder.DropTable(
                name: "PrimaryInfos");
        }
    }
}
