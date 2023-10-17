using LTMS.Domain.Model;
using System;

namespace Schm.Domain.Model
{
    public class BrandType : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
