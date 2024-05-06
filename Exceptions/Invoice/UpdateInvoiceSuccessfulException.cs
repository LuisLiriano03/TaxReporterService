namespace TaxReporter.Exceptions.Invoice
{
    public class UpdateInvoiceSuccessfulException : Exception
    {
        public override string Message { get; }

        public UpdateInvoiceSuccessfulException() : base()
        {
            Message = "Invoice information updated successfully";
        }

    }

}
