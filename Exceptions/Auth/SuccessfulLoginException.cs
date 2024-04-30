namespace TaxReporter.Exceptions.Auth
{
    public class SuccessfulLoginException : Exception
    {
        public override string Message { get; }

        public SuccessfulLoginException() : base() 
        {
            Message = "User logged in successfully";
        }

    }

}
