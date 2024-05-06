namespace TaxReporter.Exceptions.Invoice
{
    public class SuccessfulRegistrationInvoiceException : Exception
    {
        public override string Message { get; }

        public SuccessfulRegistrationInvoiceException() : base()
        {
            Message = "Registration successful";
        }

    }

}
