namespace TaxReporter.Exceptions.Invoice
{
    public class DeleteInvoiceFailedException : Exception
    {
        public override string Message { get; }

        public DeleteInvoiceFailedException() : base()
        {
            Message = "Failed to delete the invoice";
        }
    }
}
