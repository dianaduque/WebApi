using System;
using System.Collections.Generic;

namespace FilesBatchService.Models
{
    public partial class CreditRequest
    {
        public int Id { get; set; }
        public int? Customer { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? Imagen { get; set; }
        public string? ImagenWaterMark { get; set; }
        public string? PdfGeneral { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
