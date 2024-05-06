namespace TaxReporter.Exceptions.Invoice
{
    public class DeleteInvoiceSuccessfulException : Exception
    {
        public override string Message { get; }

        public DeleteInvoiceSuccessfulException() : base()
        {
            Message = "Invoice information successfully deleted";
        }

    }

}
