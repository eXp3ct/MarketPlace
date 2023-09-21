using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ksu.Market.Data.Migrations
{
	/// <inheritdoc />
	public partial class ProductPropertyNullable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DateChanged",
				table: "Products",
				type: "timestamp with time zone",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "DateChanged",
				table: "Products",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone",
				oldNullable: true);
		}
	}
}