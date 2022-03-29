namespace BasketMicroservice.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

        public List<ShoppingCartItems> Items { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                    total += item.Price * item.Quantity;
                return total;
            }
        }
    }
}
