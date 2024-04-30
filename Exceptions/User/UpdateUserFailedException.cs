namespace TaxReporter.Exceptions.User
{
    public class UpdateUserFailedException : Exception
    {
        public override string Message { get; }

        public UpdateUserFailedException() : base()
        {
            Message = "Failed to update user";
        }

    }

}
