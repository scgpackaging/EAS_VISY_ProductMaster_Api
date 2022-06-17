namespace ProductCodeOldAPIs.Models.ViewModel
{
    public class ProductCodeViewModel
    {
        public int Id { get; set; }
        public string SapCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public int? CupStack { get; set; }  
        public int? StackBox { get; set; }
        public int? CupBox { get; set; }
        public int? CupPallet { get; set; }
        public int? CupCon { get; set; }
        public string PalletizerPattern { get; set; }
        public string UpdateDate { get; set; }
    }
}
