namespace TaxReporter.Exceptions.InvoiceState
{
    public class GetInvoiceStateSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetInvoiceStateSuccessfulException() : base() 
        {
            Message = "Successful invoice state";
        }

    }

}
