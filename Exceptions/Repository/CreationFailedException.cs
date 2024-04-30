namespace TaxReporter.Exceptions.Repository
{
    public class CreationFailedException : Exception
    {
        public override string Message { get; }

        public CreationFailedException() : base()
        {
            Message = "Sorry, there was an error while creating the data";
        }

    }

}
