namespace TaxReporter.Exceptions.Invoice
{
    public class GetInvoiceFailedByUserException : Exception
    {
        public override string Message { get; }

        public GetInvoiceFailedByUserException() : base()
        {
            Message = "No invoices found for this user";
        }

    }

}
