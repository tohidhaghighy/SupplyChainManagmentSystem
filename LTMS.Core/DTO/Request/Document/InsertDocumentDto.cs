﻿using System;

namespace Schm.Core.DTO.Request.Document
{
    public class InsertDocumentDto
    {
        public int SupplierId { get; set; }
        // type = Enter , Exit
        public int DocumentType { get; set; }
        public string DocumentCode { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsDeleted { get; set; }
        public int InsertedUserId { get; set; }
    }
}
