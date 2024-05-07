namespace TaxReporter.Exceptions.Menu
{
    public class GetMenuFailedException : Exception
    {
        public override string Message { get; }

        public GetMenuFailedException() : base()
        {
            Message = "User does not exist and has no associated menus";
        }

    }

}
