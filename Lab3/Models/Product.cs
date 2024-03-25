using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        [DisplayName("Tên sách")]
        public string Name { get; set; }

        [DisplayName("Giá")]
        public decimal Price { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        [DisplayName("Ảnh sách")]
        public string? ImageUrl { get; set; }
        public List<ProductImage>? Images { get; set; }
        [DisplayName("Thể loại")]
        public int CategoryId { get; set; }
        [DisplayName("Thể loại")]
        public Category? Category { get; set; }
    }
}
