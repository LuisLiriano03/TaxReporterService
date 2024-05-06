namespace TaxReporter.Exceptions.Invoice
{
    public class UpdateInvoiceFailedException : Exception
    {
        public override string Message { get; }

        public UpdateInvoiceFailedException() : base()
        {
            Message = "Failed to update invoice";
        }
    }
}
