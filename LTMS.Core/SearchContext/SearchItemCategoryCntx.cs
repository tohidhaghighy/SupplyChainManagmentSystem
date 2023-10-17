using LTMS.Core.SearchContext;

namespace Schm.Core.SearchContext
{
    public class SearchItemCategoryCntx:BasePagerCntx
    {
        public long? CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
