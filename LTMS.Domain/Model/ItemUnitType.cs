using LTMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Domain.Model
{
    public class ItemUnitType : Entity<int>
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
