using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillSharingApp.Migrations.AppDb
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateApplicationUserDto_DAL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerScience = table.Column<bool>(type: "bit", nullable: false),
                    Math = table.Column<bool>(type: "bit", nullable: false),
                    Medicine = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateApplicationUserDto_DAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutorials",
                columns: table => new
                {
                    TutorialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutorials", x => x.TutorialId);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<long>(type: "bigint", nullable: false),
                    isVisible = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateApplicationUserDto_DALId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workshops_CreateApplicationUserDto_DAL_CreateApplicationUserDto_DALId",
                        column: x => x.CreateApplicationUserDto_DALId,
                        principalTable: "CreateApplicationUserDto_DAL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TutorialId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tutorials_TutorialId",
                        column: x => x.TutorialId,
                        principalTable: "Tutorials",
                        principalColumn: "TutorialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    CreateApplicationUserDto_DALId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    isAttended = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => new { x.CreateApplicationUserDto_DALId, x.WorkshopId });
                    table.ForeignKey(
                        name: "FK_Attendances_CreateApplicationUserDto_DAL_CreateApplicationUserDto_DALId",
                        column: x => x.CreateApplicationUserDto_DALId,
                        principalTable: "CreateApplicationUserDto_DAL",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendances_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_WorkshopId",
                table: "Attendances",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TutorialId",
                table: "Comments",
                column: "TutorialId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_WorkshopId",
                table: "Image",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_CreateApplicationUserDto_DALId",
                table: "Workshops",
                column: "CreateApplicationUserDto_DALId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Tutorials");

            migrationBuilder.DropTable(
                name: "Workshops");

            migrationBuilder.DropTable(
                name: "CreateApplicationUserDto_DAL");
        }
    }
}
