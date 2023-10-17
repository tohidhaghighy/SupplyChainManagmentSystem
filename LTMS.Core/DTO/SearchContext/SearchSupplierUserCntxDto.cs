using LTMS.Core.DTO.SearchContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchSupplierUserCntxDto : BasePagerCntxDto
    {
        public string UserName { get; set; }
        public int SupplierId { get; set; }
        public bool IsActive { get; set; }
    }
}
