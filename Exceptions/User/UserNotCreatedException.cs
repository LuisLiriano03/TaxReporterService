namespace TaxReporter.Exceptions.User
{
    public class UserNotCreatedException : Exception
    {
        public override string Message { get; }

        public UserNotCreatedException() : base()
        {
            Message = "User could not be created";
        }

    }

}
