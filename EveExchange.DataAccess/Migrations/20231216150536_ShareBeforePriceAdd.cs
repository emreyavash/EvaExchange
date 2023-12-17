using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EveExchange.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ShareBeforePriceAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BeforePrice",
                table: "Shares",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeforePrice",
                table: "Shares");
        }
    }
}
