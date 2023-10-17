using LTMS.Core.DTO.SearchContext;
using Schm.Core.Enumeration;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchShopCntxDto:BasePagerCntxDto
    {
        public SearchShopCntxDto()
        {
            Text = "";
            CategoryId = 0;
            SubCategoryId = 0;
            BrandId = 0;
            MinCost = 0;
            MaxCost = double.MaxValue;
        }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public double MinCost { get; set; }
        public double MaxCost { get; set; }
        public SearchType SearchType { get; set; }
    }
}
