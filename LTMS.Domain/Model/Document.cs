using LTMS.Domain.Model;
using System;

namespace Schm.Domain.Model
{
    public class Document:Entity<int>
    {
        public int SupplierId { get; set; }
        // type = Enter , Exit
        public int DocumentType { get; set; }
        public string DocumentCode { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsDeleted { get; set; }
        public int InsertedUserId { get; set; }
        public bool IsFinal { get; set; }

        public Supplier Supplier { get; set; }
    }
}
