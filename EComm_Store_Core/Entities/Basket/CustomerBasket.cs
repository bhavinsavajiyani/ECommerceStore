namespace EComm_Store_Core.Entities.Basket
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(string id)
        {
            ID = id;
        }

        public string ID { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}