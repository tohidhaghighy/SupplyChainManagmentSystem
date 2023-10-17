using LTMS.Core.SearchContext;

namespace Schm.Core.SearchContext
{
    public class SearchModelCntx : BasePagerCntx
    {
        public int? ModelId { get; set; }
        public string Title { get; set; }
        public int? BrandTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
