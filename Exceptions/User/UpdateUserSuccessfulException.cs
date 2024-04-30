namespace TaxReporter.Exceptions.User
{
    public class UpdateUserSuccessfulException : Exception
    {
        public override string Message { get; }

        public UpdateUserSuccessfulException() :base()
        {
            Message = "User information updated successfully";
        }

    }

}
