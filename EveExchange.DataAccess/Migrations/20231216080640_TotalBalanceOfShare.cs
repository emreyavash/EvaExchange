using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EveExchange.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TotalBalanceOfShare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalBalanceOfShare",
                table: "UserLots",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalBalanceOfShare",
                table: "UserLots");
        }
    }
}
