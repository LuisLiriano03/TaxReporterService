namespace TaxReporter.Exceptions.Repository
{
    public class UpdateFailedException : Exception
    {
        public override string Message { get; }

        public UpdateFailedException() : base() 
        {
            Message = "Sorry, there was an error while updating the data";
        }

    }

}
