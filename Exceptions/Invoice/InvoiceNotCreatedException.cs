namespace TaxReporter.Exceptions.Invoice
{
    public class InvoiceNotCreatedException : Exception
    {
        public override string Message { get; }

        public InvoiceNotCreatedException() : base()
        {
            Message = "Invoice could not be created";
        }

    }

}
