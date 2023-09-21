using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ksu.Market.Data.Migrations
{
	/// <inheritdoc />
	public partial class Initial : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: false),
					Description = table.Column<string>(type: "text", nullable: true),
					Price = table.Column<decimal>(type: "numeric", nullable: false),
					Rating = table.Column<float>(type: "real", nullable: false),
					DatePublished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					DateChanged = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Category",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: false),
					AgeRestriction = table.Column<int>(type: "integer", nullable: false),
					ProductId = table.Column<Guid>(type: "uuid", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Category", x => x.Id);
					table.ForeignKey(
						name: "FK_Category_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id");
				});

			migrationBuilder.CreateTable(
				name: "Feature",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: false),
					Value = table.Column<string>(type: "text", nullable: false),
					ProductId = table.Column<Guid>(type: "uuid", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Feature", x => x.Id);
					table.ForeignKey(
						name: "FK_Feature_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id");
				});

			migrationBuilder.CreateIndex(
				name: "IX_Category_ProductId",
				table: "Category",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_Feature_ProductId",
				table: "Feature",
				column: "ProductId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Category");

			migrationBuilder.DropTable(
				name: "Feature");

			migrationBuilder.DropTable(
				name: "Products");
		}
	}
}