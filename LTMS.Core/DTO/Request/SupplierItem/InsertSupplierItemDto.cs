namespace Schm.Core.DTO.Request.SupplierItem
{
    public class InsertSupplierItemDto
    {
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int InventoryCount { get; set; }
        public bool IsExist { get; set; }
        public bool IsActive { get; set; }
    }
}
