namespace TaxReporter.Exceptions.User
{
    public class GetUserSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetUserSuccessfulException() : base()
        {
            Message = "Successful data";
        }

    }

}
