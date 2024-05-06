namespace TaxReporter.Exceptions.Invoice
{
    public class GetUnapprovedInvoiceSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetUnapprovedInvoiceSuccessfulException() : base()
        {
            Message = "successful unapproved invoices";
        }

    }

}
