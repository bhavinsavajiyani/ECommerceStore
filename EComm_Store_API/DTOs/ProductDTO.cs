namespace EComm_Store_API.DTOs
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureURL { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}