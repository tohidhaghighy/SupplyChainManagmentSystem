namespace Schm.EndUser.UI.Infrastructure.Model
{
    public class Basket
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int SupplierId { get; set; }
    }
}
