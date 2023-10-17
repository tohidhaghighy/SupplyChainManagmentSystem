using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class Supplier : Entity<int>
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}
