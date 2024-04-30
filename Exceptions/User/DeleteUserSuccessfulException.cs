namespace TaxReporter.Exceptions.User
{
    public class DeleteUserSuccessfulException : Exception
    {
        public override string Message { get; }

        public DeleteUserSuccessfulException() : base()
        {
            Message = "User information successfully deleted";
        }

    }

}
