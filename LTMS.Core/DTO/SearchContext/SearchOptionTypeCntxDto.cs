using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchOptionTypeCntxDto : BasePagerCntxDto
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
