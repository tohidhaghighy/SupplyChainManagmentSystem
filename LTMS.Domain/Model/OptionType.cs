using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class OptionType : Entity<int>
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
