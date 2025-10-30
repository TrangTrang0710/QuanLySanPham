using Microsoft.AspNetCore.Mvc;
using QuanLySanPham.Models;
using QuanLySanPham.Services; 

namespace QuanLySanPham.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // Hiển thị danh sách sản phẩm
        public IActionResult IndexSP()
        {
            var products = _service.GetAll(); // sửa getAll -> GetAll
            return View(products);
        }

        // Xem chi tiết sản phẩm
        public IActionResult DetailsSP(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Tạo sản phẩm
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tạo sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _service.Create(product);
                return RedirectToAction(nameof(IndexSP));
            }
            return View(product);
        }

        // GET: Sửa sản phẩm
        public IActionResult Edit(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Sửa sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _service.Update(product);
                return RedirectToAction(nameof(IndexSP));
            }
            return View(product);
        }

        // GET: Xóa sản phẩm
        public IActionResult DeleteSP(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Xác nhận xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(IndexSP));
        }
    }
}
