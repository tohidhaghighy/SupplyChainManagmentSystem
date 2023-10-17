using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchSubOptionCntxDto : BasePagerCntxDto
    {
        public string Title { get; set; }
        public int OptionId { get; set; }
        public bool IsActive { get; set; }
    }
}
