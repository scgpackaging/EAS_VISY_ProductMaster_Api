using System;
using System.Collections.Generic;

namespace ProductCodeOldAPIs.Models
{
    public partial class ProductSpecification : BaseEntity
    {
        //public int Id { get; set; }
        public string? SapCode { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? CupStack { get; set; }
        public int? StackBox { get; set; }
        public int? CupBox { get; set; }
        public int? CupPallet { get; set; }
        public int? CupCon { get; set; }
        public string? PalletizerPattern { get; set; }
        //public DateTime? UpdateDate { get; set; }
    }
}
