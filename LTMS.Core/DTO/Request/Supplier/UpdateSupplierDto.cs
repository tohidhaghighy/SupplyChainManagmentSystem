namespace Schm.Core.DTO.Request.Supplier
{
    public class UpdateSupplierDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
    }
}
