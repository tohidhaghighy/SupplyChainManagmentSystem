using Schm.Domain.Model;

namespace Schm.UI.Infrastructure.ViewModels
{
    public class ItemViewModel
    {
        public List<BrandType> BrandList { get; set; }
        public List<ItemCatagory> CategoryList { get; set; }
        public List<ItemUnitType> UnitList { get; set; }
        public List<ItemSubCatagory> SubCategoryList { get; set; }
        public List<ModelType> ModelTypeList { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string StandardCode { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int ModelId { get; set; }
        public bool IsActive { get; set; }
        public string ModelName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
    }
}
