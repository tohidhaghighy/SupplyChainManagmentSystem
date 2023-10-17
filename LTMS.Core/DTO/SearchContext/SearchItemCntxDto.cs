using LTMS.Core.DTO.SearchContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Core.DTO.SearchContext
{
    public class SearchItemCntxDto : BasePagerCntxDto
    {
        public string Title { get; set; }
        public string StandardCode { get; set; }
        public string InternalCode { get; set; }
        public string Description { get; set; }
        public string ModelType { get; set; }
        public string ItemSubCatagory { get; set; }
        public string ItemUnitType { get; set; }
        public bool IsActive { get; set; }
    }
}
