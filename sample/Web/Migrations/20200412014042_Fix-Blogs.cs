using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class FixBlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_T",
                table: "T");

            migrationBuilder.RenameTable(
                name: "T",
                newName: "Blog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "T");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T",
                table: "T",
                column: "Id");
        }
    }
}
