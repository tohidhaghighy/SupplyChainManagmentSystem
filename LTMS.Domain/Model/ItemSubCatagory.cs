using LTMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Schm.Domain.Model
{
    public class ItemSubCatagory : Entity<int>
    {
        public string Title { get; set; }
        public int ItemCatagoryId { get; set; }
        public bool IsActive { get; set; }
        public ItemCatagory ItemCatagory { get; set; }
    }
}

