using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class ModelType : Entity<int>
    {
        public string Title { get; set; }
        public int BrandTypeId { get; set; }
        public bool IsActive { get; set; }
        public BrandType BrandType { get; set; }
    }
}
