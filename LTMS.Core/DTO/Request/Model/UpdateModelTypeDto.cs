using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schm.Core.DTO.Request.Model
{
    public class UpdateModelTypeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BrandTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
