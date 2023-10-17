namespace Schm.Core.DTO.Request.Order
{
    public class InsertOrderDto
    {
        public string OrderNumber { get; set; }
        public double Tax { get; set; }
        public double PayCost { get; set; }
        public double DiscountCost { get; set; }
        public int PaymentTypeId { get; set; }
        public int LogenticTypeId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        public int SupplierId { get; set; }
        public int OrderStatus { get; set; }
    }
}
