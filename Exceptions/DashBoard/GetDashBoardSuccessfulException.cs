namespace TaxReporter.Exceptions.DashBoard
{
    public class GetDashBoardSuccessfulException : Exception
    {
        public override string Message { get; }

        public GetDashBoardSuccessfulException() : base()
        {
            Message = "Amount of successful invoices";
        }

    }

}
