using LTMS.Domain.Model;
using System;

namespace Schm.Domain.Model
{
    public class Transaction : Entity<int>
    {
        public int OrderId { get; set; }
        public string TrackingCode { get; set; }
        public string ReferenceCode { get; set; }
        public int PaymentStatus { get; set; }
        public string Error { get; set; }
        public DateTime Date { get; set; }
    }
}
