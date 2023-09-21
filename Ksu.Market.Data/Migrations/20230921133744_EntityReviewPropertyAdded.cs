using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ksu.Market.Data.Migrations
{
	/// <inheritdoc />
	public partial class EntityReviewPropertyAdded : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<float>(
				name: "Rating",
				table: "Reviews",
				type: "real",
				nullable: false,
				defaultValue: 0f);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Rating",
				table: "Reviews");
		}
	}
}