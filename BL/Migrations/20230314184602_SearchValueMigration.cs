using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class SearchValueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SearchCount",
                table: "TbProduct",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchCount",
                table: "TbProduct");
        }
    }
}
