namespace TaxReporter.Exceptions.Invoice
{
    public class GetApprovedInvoiceSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetApprovedInvoiceSuccessfulException() : base()
        {
            Message = "successful approved invoices";
        }

    }

}
