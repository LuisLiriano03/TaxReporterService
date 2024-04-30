namespace TaxReporter.Exceptions.Repository
{
    public class NoDataFoundException : Exception
    {
        public override string Message { get; }

        public NoDataFoundException() : base() 
        {
            Message = "Sorry, there are no available data";
        }

    }

}
