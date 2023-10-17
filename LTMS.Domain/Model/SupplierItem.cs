using LTMS.Domain.Model;
using System;

namespace Schm.Domain.Model
{
    public class SupplierItem : Entity<int>
    {
        public SupplierItem()
        {
            this.InsertedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public int InventoryCount { get; set; }
        public bool IsExist { get; set; }
        public bool IsActive { get; set; }
        public int ViewerCount { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string DefaultImage { get; set; }

        public Item Item { get; set; }
        public Supplier Supplier { get; set; }
    }
}
