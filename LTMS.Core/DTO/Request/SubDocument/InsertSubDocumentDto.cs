using System;

namespace Schm.Core.DTO.Request.SubDocument
{
    public class InsertSubDocumentDto
    {
        public int DocumentId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public DateTime InsertedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
