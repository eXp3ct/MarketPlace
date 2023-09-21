using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ksu.Market.Data.Migrations
{
	/// <inheritdoc />
	public partial class EntityReviewChanged : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Category_Products_ProductId",
				table: "Category");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Category",
				table: "Category");

			migrationBuilder.RenameTable(
				name: "Category",
				newName: "Categories");

			migrationBuilder.RenameIndex(
				name: "IX_Category_ProductId",
				table: "Categories",
				newName: "IX_Categories_ProductId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Categories",
				table: "Categories",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Categories_Products_ProductId",
				table: "Categories",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Categories_Products_ProductId",
				table: "Categories");

			migrationBuilder.DropPrimaryKey(
				name: "PK_Categories",
				table: "Categories");

			migrationBuilder.RenameTable(
				name: "Categories",
				newName: "Category");

			migrationBuilder.RenameIndex(
				name: "IX_Categories_ProductId",
				table: "Category",
				newName: "IX_Category_ProductId");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Category",
				table: "Category",
				column: "Id");

			migrationBuilder.AddForeignKey(
				name: "FK_Category_Products_ProductId",
				table: "Category",
				column: "ProductId",
				principalTable: "Products",
				principalColumn: "Id");
		}
	}
}