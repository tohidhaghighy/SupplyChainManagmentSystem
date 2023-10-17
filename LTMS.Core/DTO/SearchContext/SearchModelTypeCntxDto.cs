using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchModelTypeCntxDto : BasePagerCntxDto
    {
        public string Title { get; set; }
        public int BrandTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
