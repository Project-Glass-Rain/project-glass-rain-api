using GlassRain.Domain.Catalog;

namespace GlassRain.Domain.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; } = null!;

        public decimal Price => Item.Price;
    }
}