namespace TaxReporter.Exceptions.User
{
    public class UserNotFoundException : Exception
    {
        public override string Message { get; }

        public UserNotFoundException() : base()
        {
            Message = "The user is not found";
        }

    }

}
