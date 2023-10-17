using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchItemOptionCntxDto : BasePagerCntxDto
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
    }
}
