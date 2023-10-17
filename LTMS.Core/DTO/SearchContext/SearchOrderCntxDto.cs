using LTMS.Core.DTO.SearchContext;
using System;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchOrderCntxDto:BasePagerCntxDto
    {
        public SearchOrderCntxDto()
        {
            OrderNumber = "";
        }
        public string OrderNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int OrderStatus { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
    }
}
