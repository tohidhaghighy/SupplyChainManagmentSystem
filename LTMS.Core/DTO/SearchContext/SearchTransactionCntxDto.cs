using LTMS.Core.DTO.SearchContext;
using System;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchTransactionCntxDto : BasePagerCntxDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Code { get; set; }
    }
}
