namespace Schm.Core.DTO.Request.DeliverySupplierPlan
{
    public class InsertDeliverySupplierPlanDto
    {
        public string Title { get; set; }
        public int SupplierId { get; set; }
        public int MinDayLimitation { get; set; }
        public int MaxDayLimitation { get; set; }
        public int OrderCountLimitation { get; set; }
        public string RangeOfDailyTime { get; set; }
        public bool IsActive { get; set; }
    }
}
