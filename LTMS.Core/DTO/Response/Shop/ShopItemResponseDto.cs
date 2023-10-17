using System.Collections.Generic;

namespace Schm.Core.DTO.Response.Shop
{
    public class ShopItemResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public int DefaultSupplierId { get; set; }
        public List<string> Options { get; set; }
        public List<SupplierItemResponseDto> SupplierItem { get; set; }
    }
}
