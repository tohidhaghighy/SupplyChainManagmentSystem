using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class DeliverySupplierPlan : Entity<int>
    {
        public int SupplierId { get; set; }
        public int MinDayLimitation { get; set; }
        public int MaxDayLimitation { get; set; }
        public int OrderCountLimitation { get; set; }
        public string RangeOfDailyTime { get; set; }
        public bool IsActive { get; set; }

        public Supplier Supplier { get; set; }
    }
}
