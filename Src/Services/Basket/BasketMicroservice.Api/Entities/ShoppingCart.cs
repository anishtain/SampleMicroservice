namespace BasketMicroservice.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }

        public List<ShoppingCartItem> Items { get; set; }

        public decimal Total
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
