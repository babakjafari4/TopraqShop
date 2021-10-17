using Microsoft.EntityFrameworkCore.Migrations;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Migrations
{
    public partial class LinkAddedToSlide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Slides",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Slides");
        }
    }
}
