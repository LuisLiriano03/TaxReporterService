namespace TaxReporter.Exceptions.Menu
{
    public class GetMenuFailedException : Exception
    {
        public override string Message { get; }

        public GetMenuFailedException() : base()
        {
            Message = "Failed to get menus";
        }

    }

}
