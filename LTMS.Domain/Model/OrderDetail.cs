using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class OrderDetail : Entity<int>
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }
    }
}
