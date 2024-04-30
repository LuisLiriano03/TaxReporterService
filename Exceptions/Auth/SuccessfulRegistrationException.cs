namespace TaxReporter.Exceptions.Auth
{
    public class SuccessfulRegistrationException : Exception
    {
        public override string Message { get; }

        public SuccessfulRegistrationException() : base()
        {
            Message = "Registration successful";
        }

    }

}
