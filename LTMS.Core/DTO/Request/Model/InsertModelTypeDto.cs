using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schm.Core.DTO.Request.Model
{
    public class InsertModelTypeDto
    {
        public string Title { get; set; }
        public int BrandTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
