namespace Schm.Core.DTO.Request.Transaction
{
    public class InsertTransactionDto
    {
        public int OrderId { get; set; }
        public string TrackingCode { get; set; }
        public string ReferenceCode { get; set; }
        public int PaymentStatus { get; set; }
        public string Error { get; set; }
    }
}
