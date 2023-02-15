using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TodoBackendDAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoCollectionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IconColor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IconType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoCollectionTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoCollectionTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    About = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CollectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoTable_ToDoCollectionTable_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "ToDoCollectionTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnerToDoTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerToDoTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnerToDoTable_ToDoTable_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "ToDoTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserTable",
                columns: new[] { "Id", "Email", "Login", "Password" },
                values: new object[,]
                {
                    { 1, "Bender03@gmail.com", "BenderRobot", "qwerty01" },
                    { 2, "JackD@gmail.com", "Jack", "qwerty02" }
                });

            migrationBuilder.InsertData(
                table: "ToDoCollectionTable",
                columns: new[] { "Id", "IconColor", "IconType", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Red", "Home", "Home", 1 },
                    { 2, "Red", "Home", "Sport", 1 },
                    { 3, "Red", "Home", "Home", 2 },
                    { 4, "Red", "Home", "Learn", 2 }
                });

            migrationBuilder.InsertData(
                table: "ToDoTable",
                columns: new[] { "Id", "About", "CollectionId", "CreationDate", "IsComplete", "Name" },
                values: new object[,]
                {
                    { 1, "Do math and english", 4, new DateTime(2023, 2, 15, 9, 50, 37, 388, DateTimeKind.Local).AddTicks(5693), false, "Do homework" },
                    { 2, "Do history", 4, new DateTime(2023, 2, 14, 9, 50, 37, 388, DateTimeKind.Local).AddTicks(5750), true, "Do homework" },
                    { 3, "Bake chiken and potato ", 3, new DateTime(2023, 2, 15, 19, 50, 37, 388, DateTimeKind.Local).AddTicks(5756), false, "Cook supper" },
                    { 4, "-", 3, new DateTime(2023, 2, 15, 9, 50, 37, 388, DateTimeKind.Local).AddTicks(5760), false, "Clean up home" },
                    { 5, "Go on training at next tuesday", 2, new DateTime(2023, 2, 15, 20, 50, 37, 388, DateTimeKind.Local).AddTicks(5764), false, "Training" }
                });

            migrationBuilder.InsertData(
                table: "InnerToDoTable",
                columns: new[] { "Id", "CreationDate", "IsComplete", "Name", "ToDoId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 15, 10, 20, 37, 388, DateTimeKind.Local).AddTicks(6722), true, "Do english", 1 },
                    { 2, new DateTime(2023, 2, 15, 10, 14, 37, 388, DateTimeKind.Local).AddTicks(6741), false, "Do math", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InnerToDoTable_ToDoId",
                table: "InnerToDoTable",
                column: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoCollectionTable_UserId",
                table: "ToDoCollectionTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTable_CollectionId",
                table: "ToDoTable",
                column: "CollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InnerToDoTable");

            migrationBuilder.DropTable(
                name: "ToDoTable");

            migrationBuilder.DropTable(
                name: "ToDoCollectionTable");

            migrationBuilder.DropTable(
                name: "UserTable");
        }
    }
}
