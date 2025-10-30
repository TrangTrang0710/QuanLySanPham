using System.ComponentModel.DataAnnotations;

namespace QuanLySanPham.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Gia lon hon 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "so luong phai lon hon hoac bang 0")]
        public int Stock { get; set; }

        public string? Description { get; set; }
    }
}