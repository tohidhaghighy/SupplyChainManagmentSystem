using LTMS.Core.DTO.SearchContext;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchSupplierItemCntxDto: BasePagerCntxDto
    {
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int InventoryCount { get; set; }
        public bool IsExist { get; set; }
        public bool IsActive { get; set; }
    }
}
