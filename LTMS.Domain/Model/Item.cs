using LTMS.Domain.Model;

namespace Schm.Domain.Model
{
    public class Item : Entity<int>
    {
        public string Title { get; set; }
        public string StandardCode { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public int ModelTypeId { get; set; }
        public int ItemSubCatagoryId { get; set; }
        public int ItemUnitTypeId { get; set; }
        public bool IsActive { get; set; }
        public ModelType ModelType { get; set; }
        public ItemSubCatagory ItemSubCatagory { get; set; }
        public ItemUnitType ItemUnitType { get; set; }
    }
}
