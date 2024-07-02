using System.ComponentModel.DataAnnotations;

namespace EComm_Store_API.DTOs
{
    public class BasketItemDTO
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
        
        [Required]
        public string PictureURL { get; set; }
        
        [Required]
        public string ProductBrand { get; set; }
        
        [Required]
        public string ProductType { get; set; }
    }
}