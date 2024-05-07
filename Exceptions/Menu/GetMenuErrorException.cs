namespace TaxReporter.Exceptions.Menu
{
    public class GetMenuErrorException : Exception
    {
        public override string Message { get; }

        public GetMenuErrorException() : base()
        {
            Message = "Error to retrieve menu items";
        }

    }
}
