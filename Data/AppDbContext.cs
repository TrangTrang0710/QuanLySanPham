using Microsoft.EntityFrameworkCore;
using QuanLySanPham.Models;

namespace QuanLySanPham.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            // Seed dữ liệu mẫu 
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop Dell", Price = 20000000, Stock = 10, Description = "Laptop hiệu suất cao" },
                new Product { Id = 2, Name = "Chuột Logitech", Price = 500000, Stock = 50, Description = "Chuột không dây" },
                new Product { Id = 3, Name = "Bình giữ nhiệt", Price = 500000, Stock = 50, Description = "Bình giữ nhiệt" },
                new Product { Id = 4, Name = "Sách - Đắc Nhân Tâm", Price = 89000, Stock = 100, Description = "Tác phẩm kinh điển về nghệ thuật ứng xử và giao tiếp" },
                new Product { Id = 5, Name = "Sách - Nhà Giả Kim", Price = 99000, Stock = 80, Description = "Tiểu thuyết triết lý nổi tiếng của Paulo Coelho" },
                new Product { Id = 6, Name = "Bộ Lego Classic 500 chi tiết", Price = 850000, Stock = 25, Description = "Đồ chơi sáng tạo, giúp phát triển tư duy trẻ nhỏ" },
                new Product { Id = 7, Name = "Gấu bông Brown Line Friends 60cm", Price = 350000, Stock = 15, Description = "Chất liệu mềm mịn, đáng yêu, phù hợp làm quà tặng" }
            );
        }
    }
}