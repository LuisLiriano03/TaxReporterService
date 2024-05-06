namespace TaxReporter.Exceptions.Invoice
{
    public class GetInvoiceSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetInvoiceSuccessfulException() : base()
        {
            Message = "Successful Invoices";
        }

    }

}
