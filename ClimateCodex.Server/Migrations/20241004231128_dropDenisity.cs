using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimateCodex.Server.Migrations
{
    /// <inheritdoc />
    public partial class dropDenisity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PopulationDensity",
                table: "ClimateData");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<float>(
                name: "PopulationDensity",
                table: "ClimateData",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
