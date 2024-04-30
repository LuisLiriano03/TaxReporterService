namespace TaxReporter.Exceptions.Repository
{
    public class DeletionFailedException : Exception
    {
        public override string Message { get; }

        public DeletionFailedException() : base() 
        { 
            Message = "Sorry, there was an error while removing the data";
        }

    }

}
