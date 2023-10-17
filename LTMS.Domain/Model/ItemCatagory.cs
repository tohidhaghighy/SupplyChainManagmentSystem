using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class ItemCatagory : Entity<int>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
