using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class PaymentType : Entity<int>
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}
