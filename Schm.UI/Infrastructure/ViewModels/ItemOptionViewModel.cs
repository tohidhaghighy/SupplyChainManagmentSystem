using Schm.Domain.Model;

namespace Schm.UI.Infrastructure.ViewModels
{
    public class ItemOptionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OptionName { get; set; }
        public string OptionGroupName { get; set; }
        public List<OptionType> OptionTypeList { get; set; }
        public List<OptionGroupType> OptionGroupTypeList { get; set; }
    }
}
