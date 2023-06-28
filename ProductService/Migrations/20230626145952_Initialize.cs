using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Fantastic Rubber Car", 56m },
                    { 2, "Intelligent Concrete Keyboard", 50m },
                    { 3, "Awesome Plastic Salad", 54m },
                    { 4, "Intelligent Fresh Bike", 55m },
                    { 5, "Awesome Soft Chips", 55m },
                    { 6, "Practical Frozen Cheese", 56m },
                    { 7, "Handcrafted Frozen Bacon", 54m },
                    { 8, "Fantastic Fresh Computer", 49m },
                    { 9, "Ergonomic Plastic Mouse", 57m },
                    { 10, "Small Concrete Hat", 57m },
                    { 11, "Ergonomic Soft Chicken", 57m },
                    { 12, "Small Soft Bike", 51m },
                    { 13, "Sleek Granite Mouse", 49m },
                    { 14, "Generic Rubber Table", 52m },
                    { 15, "Licensed Wooden Keyboard", 50m },
                    { 16, "Practical Cotton Pizza", 55m },
                    { 17, "Gorgeous Soft Soap", 56m },
                    { 18, "Handcrafted Wooden Tuna", 50m },
                    { 19, "Gorgeous Steel Soap", 54m },
                    { 20, "Gorgeous Metal Pizza", 56m },
                    { 21, "Handmade Granite Mouse", 57m },
                    { 22, "Handcrafted Frozen Shoes", 52m },
                    { 23, "Unbranded Metal Gloves", 56m },
                    { 24, "Ergonomic Plastic Hat", 54m },
                    { 25, "Unbranded Frozen Pizza", 50m },
                    { 26, "Rustic Plastic Tuna", 51m },
                    { 27, "Licensed Fresh Salad", 53m },
                    { 28, "Small Soft Bike", 49m },
                    { 29, "Incredible Concrete Hat", 57m },
                    { 30, "Gorgeous Fresh Car", 50m },
                    { 31, "Incredible Wooden Chips", 57m },
                    { 32, "Refined Soft Mouse", 57m },
                    { 33, "Sleek Frozen Cheese", 51m },
                    { 34, "Licensed Metal Fish", 51m },
                    { 35, "Refined Soft Keyboard", 55m },
                    { 36, "Small Fresh Table", 49m },
                    { 37, "Sleek Wooden Towels", 56m },
                    { 38, "Licensed Rubber Table", 50m },
                    { 39, "Refined Rubber Salad", 57m },
                    { 40, "Fantastic Metal Towels", 57m },
                    { 41, "Handcrafted Frozen Car", 52m },
                    { 42, "Tasty Frozen Gloves", 54m },
                    { 43, "Sleek Wooden Car", 52m },
                    { 44, "Handmade Plastic Ball", 52m },
                    { 45, "Handmade Fresh Shoes", 54m },
                    { 46, "Gorgeous Plastic Computer", 57m },
                    { 47, "Awesome Soft Table", 50m },
                    { 48, "Handmade Soft Chips", 50m },
                    { 49, "Gorgeous Wooden Keyboard", 53m },
                    { 50, "Refined Cotton Mouse", 53m },
                    { 51, "Refined Fresh Gloves", 54m },
                    { 52, "Sleek Frozen Bike", 53m },
                    { 53, "Gorgeous Granite Ball", 53m },
                    { 54, "Intelligent Fresh Cheese", 51m },
                    { 55, "Refined Wooden Hat", 49m },
                    { 56, "Sleek Steel Sausages", 55m },
                    { 57, "Intelligent Fresh Keyboard", 54m },
                    { 58, "Rustic Concrete Towels", 51m },
                    { 59, "Handcrafted Frozen Cheese", 51m },
                    { 60, "Small Granite Table", 53m },
                    { 61, "Awesome Fresh Chips", 50m },
                    { 62, "Practical Cotton Car", 51m },
                    { 63, "Fantastic Soft Mouse", 54m },
                    { 64, "Unbranded Frozen Computer", 56m },
                    { 65, "Unbranded Rubber Shoes", 54m },
                    { 66, "Refined Rubber Table", 56m },
                    { 67, "Unbranded Frozen Sausages", 50m },
                    { 68, "Ergonomic Cotton Ball", 51m },
                    { 69, "Handcrafted Frozen Tuna", 54m },
                    { 70, "Small Metal Gloves", 55m },
                    { 71, "Licensed Soft Bike", 51m },
                    { 72, "Small Fresh Shirt", 54m },
                    { 73, "Refined Frozen Shoes", 52m },
                    { 74, "Tasty Soft Fish", 57m },
                    { 75, "Practical Fresh Gloves", 52m },
                    { 76, "Practical Soft Gloves", 57m },
                    { 77, "Sleek Soft Chips", 57m },
                    { 78, "Incredible Granite Cheese", 50m },
                    { 79, "Intelligent Metal Pizza", 54m },
                    { 80, "Fantastic Steel Car", 50m },
                    { 81, "Awesome Concrete Table", 49m },
                    { 82, "Unbranded Soft Shirt", 57m },
                    { 83, "Gorgeous Soft Mouse", 49m },
                    { 84, "Fantastic Fresh Pants", 49m },
                    { 85, "Sleek Concrete Bacon", 50m },
                    { 86, "Unbranded Granite Pants", 51m },
                    { 87, "Rustic Concrete Ball", 51m },
                    { 88, "Unbranded Metal Hat", 51m },
                    { 89, "Refined Plastic Salad", 49m },
                    { 90, "Fantastic Wooden Car", 55m },
                    { 91, "Fantastic Steel Chicken", 53m },
                    { 92, "Incredible Rubber Bacon", 51m },
                    { 93, "Incredible Fresh Soap", 49m },
                    { 94, "Gorgeous Fresh Computer", 56m },
                    { 95, "Unbranded Steel Chips", 54m },
                    { 96, "Awesome Steel Chips", 54m },
                    { 97, "Intelligent Fresh Gloves", 56m },
                    { 98, "Unbranded Wooden Tuna", 51m },
                    { 99, "Intelligent Steel Pizza", 56m },
                    { 100, "Licensed Soft Chair", 53m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
