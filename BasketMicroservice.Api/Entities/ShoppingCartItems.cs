namespace BasketMicroservice.Api.Entities
{
    public class ShoppingCartItems
    {
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
