using Schm.Domain.Model;

namespace Schm.EndUser.UI.Infrastructure.ViewModels
{
    public class HomeViewModel
    {
        public List<ItemCatagory> CategoryList { get; set; }
        public List<BrandType> BrandList { get; set; }
        public List<SupplieItemViewModel> ItemList { get; set; }
    }
}
