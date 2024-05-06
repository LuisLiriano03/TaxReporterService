namespace TaxReporter.Exceptions.Invoice
{
    public class GetPendingInvoiceSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetPendingInvoiceSuccessfulException() : base() 
        {
            Message = "successful pending invoices";
        }

    }

}
