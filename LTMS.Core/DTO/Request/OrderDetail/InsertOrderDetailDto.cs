namespace Schm.Core.DTO.Request.OrderDetail
{
    public class InsertOrderDetailDto
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
    }
}
