using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EveExchange.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EntitiesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NormalizedShareName",
                table: "Shares",
                newName: "ShortShareName");

            migrationBuilder.AddColumn<int>(
                name: "UserLotId",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLotId",
                table: "Portfolios");

            migrationBuilder.RenameColumn(
                name: "ShortShareName",
                table: "Shares",
                newName: "NormalizedShareName");
        }
    }
}
