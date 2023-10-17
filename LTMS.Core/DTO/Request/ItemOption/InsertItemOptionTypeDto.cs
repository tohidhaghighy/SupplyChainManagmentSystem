namespace Schm.Core.DTO.Request.ItemOption
{
    public class InsertItemOptionTypeDto
    {
        public int ItemId { get; set; }
        public int OptionTypeId { get; set; }
        public int OptionGroupTypeId { get; set; }
        public string OptionValue { get; set; }
    }
}
