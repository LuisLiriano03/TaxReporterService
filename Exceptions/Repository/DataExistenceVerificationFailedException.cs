namespace TaxReporter.Exceptions.Repository
{
    public class DataExistenceVerificationFailedException : Exception
    {
        public override string Message { get; }

        public DataExistenceVerificationFailedException() : base()
        {
            Message = "Sorry, there was an error while validating the data existence";
        }

    }

}
