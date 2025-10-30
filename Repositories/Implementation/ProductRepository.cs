using System.Collections.Generic;
using System.Linq;
using QuanLySanPham.Data;
using QuanLySanPham.Models;
using QuanLySanPham.Repositories.Interfaces;

namespace QuanLySanPham.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Lấy toàn bộ sản phẩm
        public IEnumerable<Product> GetAll() => _context.Products.ToList();

        // ✅ Lấy theo ID
        public Product? GetById(int id) => _context.Products.Find(id);


        // ✅ Thêm sản phẩm
        public void Add(Product product)
        {
            _context.Products.Add(product);
            Save();
        }

        // ✅ Cập nhật sản phẩm
        public void Update(Product product)
        {
            _context.Products.Update(product);
            Save();
        }

        // ✅ Xóa sản phẩm
        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                Save();
            }
        }

        // ✅ Lưu thay đổi
        public void Save() => _context.SaveChanges();
    }
}
