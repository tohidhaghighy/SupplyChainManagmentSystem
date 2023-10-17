using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchSupplierCntxDto : BasePagerCntxDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
