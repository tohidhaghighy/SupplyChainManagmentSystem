using LTMS.Core.DTO.SearchContext;
using System;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchSubDocumentCntxDto: BasePagerCntxDto
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public int MinCount { get; set; }
        public int MaxCount { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
