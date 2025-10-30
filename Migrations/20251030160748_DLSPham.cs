using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuanLySanPham.Migrations
{
    /// <inheritdoc />
    public partial class DLSPham : Migration
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Laptop hiệu suất cao", "Laptop Dell", 20000000m, 10 },
                    { 2, "Chuột không dây", "Chuột Logitech", 500000m, 50 },
                    { 3, "Bình giữ nhiệt", "Bình giữ nhiệt", 500000m, 50 },
                    { 4, "Tác phẩm kinh điển về nghệ thuật ứng xử và giao tiếp", "Sách - Đắc Nhân Tâm", 89000m, 100 },
                    { 5, "Tiểu thuyết triết lý nổi tiếng của Paulo Coelho", "Sách - Nhà Giả Kim", 99000m, 80 },
                    { 6, "Đồ chơi sáng tạo, giúp phát triển tư duy trẻ nhỏ", "Bộ Lego Classic 500 chi tiết", 850000m, 25 },
                    { 7, "Chất liệu mềm mịn, đáng yêu, phù hợp làm quà tặng", "Gấu bông Brown Line Friends 60cm", 350000m, 15 }
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
