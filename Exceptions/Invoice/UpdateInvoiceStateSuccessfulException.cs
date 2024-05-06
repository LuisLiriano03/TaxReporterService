namespace TaxReporter.Exceptions.Invoice
{
    public class UpdateInvoiceStateSuccessfulException : Exception
    {
        public override string Message { get; }

        public UpdateInvoiceStateSuccessfulException() : base()
        {
            Message = "Invoice state information updated successfully";
        }

    }

}
