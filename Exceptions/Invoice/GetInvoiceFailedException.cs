namespace TaxReporter.Exceptions.Invoice
{
    public class GetInvoiceFailedException : Exception
    {
        public override string Message { get; }

        public GetInvoiceFailedException() : base()
        {
            Message = "No invoices found";
        }
    }
}
