namespace CartService.Api.DataAccessLayer.Models
{
    public class Cart
    {
        public long CartId { get; set; }

        public List<CartItem>? CartItems { get; set; }
    }
}
