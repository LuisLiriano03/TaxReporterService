namespace TaxReporter.Exceptions.User
{
    public class GetUsersFailedException : Exception
    {
        public override string Message { get; }

        public GetUsersFailedException() : base()
        {
            Message = "No data found";
        }

    }
}
