using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EveExchange.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TotalBalanceOfShareEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalBalanceOfShare",
                table: "UserLots",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalBalanceOfShare",
                table: "UserLots",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }
    }
}
