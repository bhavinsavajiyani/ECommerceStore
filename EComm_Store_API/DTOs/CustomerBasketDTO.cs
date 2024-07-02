using System.ComponentModel.DataAnnotations;

namespace EComm_Store_API.DTOs
{
    public class CustomerBasketDTO
    {
        [Required]
        public string ID { get; set; }
       
        public List<BasketItemDTO> Items { get; set; }
    }
}