namespace Schm.UI.Infrastructure.ViewModels
{
    public class SupplieItemViewModel
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int InventoryCount { get; set; }
        public bool IsExist { get; set; }
        public bool IsActive { get; set; }
        public string SupplierName { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string Image { get; set; }
    }
}
