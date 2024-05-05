namespace TaxReporter.Exceptions.InvoiceState
{
    public class GetInvoiceStateFailedException : Exception
    {
        public override string Message { get; }

        public GetInvoiceStateFailedException() : base()
        {
            Message = "No invoice state found";
        }

    }

}
