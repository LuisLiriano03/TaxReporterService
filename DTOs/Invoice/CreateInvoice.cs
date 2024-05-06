namespace TaxReporter.DTOs.Invoice
{
    public class CreateInvoice
    {
        public int? UserId { get; set; }

        public string? BusinessName { get; set; }

        public string? Rnc { get; set; }

        public string? Nfc { get; set; }

        public decimal? AmountWithoutItbis { get; set; }

        public decimal? Itbis { get; set; }

        public decimal? ServicePercentage { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? ImageUrl { get; set; }


    }

}
