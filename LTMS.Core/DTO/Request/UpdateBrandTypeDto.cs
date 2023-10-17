using Microsoft.AspNetCore.Http;

namespace Schm.Core.DTO.Request
{
    public class UpdateBrandTypeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
