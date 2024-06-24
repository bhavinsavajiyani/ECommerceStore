namespace EComm_Store_Core.Entities.Basket
{
    public class BasketItem
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureURL { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }
    }
}