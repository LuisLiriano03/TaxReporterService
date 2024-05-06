namespace TaxReporter.Exceptions.Invoice
{
    public class InvoiceNotFoundException : Exception
    {
        public override string Message { get; }

        public InvoiceNotFoundException() : base()
        {
            Message = "The invoice is not found";
        }
    }
}
