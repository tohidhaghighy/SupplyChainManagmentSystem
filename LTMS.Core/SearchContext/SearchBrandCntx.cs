using LTMS.Core.SearchContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schm.Core.SearchContext
{
    public class SearchBrandCntx:BasePagerCntx
    {
        public long? BrandId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
