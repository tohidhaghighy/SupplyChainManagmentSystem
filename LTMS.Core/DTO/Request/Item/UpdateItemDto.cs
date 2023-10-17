namespace Schm.Core.DTO.Request.Item
{
    public class UpdateItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StandardCode { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public int ModelTypeId { get; set; }
        public int ItemSubCatagoryId { get; set; }
        public int ItemUnitTypeId { get; set; }
    }
}
