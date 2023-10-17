using LTMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Schm.Domain.Model
{
    public class ItemOption : Entity<int>
    {
        public int ItemId { get; set; }
        public int OptionTypeId { get; set; }
        public int OptionGroupTypeId { get; set; }
        public string OptionValue { get; set; }
        
        public Item Item { get; set; }
        public OptionType OptionType { get; set; }
        public OptionGroupType OptionGroupType { get; set; }
    }
}
