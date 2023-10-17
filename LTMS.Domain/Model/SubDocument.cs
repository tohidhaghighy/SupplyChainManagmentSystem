using LTMS.Domain.Model;
using System;

namespace Schm.Domain.Model
{
    public class SubDocument : Entity<int>
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public DateTime InsertedDate { get; set; }
        public bool IsDeleted { get; set; }

        public Document Document { get; set; }
        public Item Item { get; set; }
    }
}
