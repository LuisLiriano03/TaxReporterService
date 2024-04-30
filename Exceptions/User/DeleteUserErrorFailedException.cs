namespace TaxReporter.Exceptions.User
{
    public class DeleteUserErrorFailedException : Exception
    {
        public override string Message { get; }

        public DeleteUserErrorFailedException() : base() 
        {
            Message = "No user found with that ID";
        }

    }

}
