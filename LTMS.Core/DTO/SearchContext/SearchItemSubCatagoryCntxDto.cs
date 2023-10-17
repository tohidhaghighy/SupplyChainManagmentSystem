using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchItemSubCatagoryCntxDto : BasePagerCntxDto
    {
        public string Title { get; set; }
        public int ItemCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
