using QuanLySanPham.Models;
using System.Collections.Generic;

namespace QuanLySanPham.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
