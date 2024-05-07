namespace TaxReporter.Exceptions.Menu
{
    public class GetMenuSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetMenuSuccessfulException() : base()
        {
            Message = "Menu items retrieval operation completed successfully";
        }
    }
}
