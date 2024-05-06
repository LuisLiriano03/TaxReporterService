namespace TaxReporter.Exceptions.Invoice
{
    public class DeleteInvoiceErrorFailedException : Exception
    {
        public override string Message { get; }

        public DeleteInvoiceErrorFailedException() : base()
        {
            Message = "The invoice is no found with that ID";
        }
    }
}
