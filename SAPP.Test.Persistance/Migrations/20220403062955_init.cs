using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAPP.Test.Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestParent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    TestParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestChild_TestParent_TestParentId",
                        column: x => x.TestParentId,
                        principalTable: "TestParent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestChild_TestParentId",
                table: "TestChild",
                column: "TestParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestChild");

            migrationBuilder.DropTable(
                name: "TestParent");
        }
    }
}
