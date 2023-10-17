using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class SupplierUser : Entity<int>
    {
        public int UserId { get; set; }
        public int SupplierId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }

        public Supplier Supplier { get; set; }
    }
}
