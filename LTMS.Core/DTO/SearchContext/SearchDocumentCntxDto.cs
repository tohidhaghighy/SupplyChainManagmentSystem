using LTMS.Core.DTO.SearchContext;
using System;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchDocumentCntxDto : BasePagerCntxDto
    {
        public int supplierId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DocType { get; set; }
        public string Code { get; set; }
    }
}
