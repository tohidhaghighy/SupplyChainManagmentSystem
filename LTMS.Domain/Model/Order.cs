using LTMS.Domain.Model;
using System;

namespace Schm.Domain.Model
{
    public class Order : Entity<int>
    {
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
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
        public bool IsCanceled { get; set; }

        public PaymentType PaymentType { get; set; }
        public LogesticType LogesticType { get; set; }
        public Supplier Supplier { get; set; }
    }
}
