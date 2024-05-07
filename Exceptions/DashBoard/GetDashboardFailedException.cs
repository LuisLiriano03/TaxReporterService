namespace TaxReporter.Exceptions.DashBoard
{
    public class GetDashboardFailedException : Exception
    {
        public override string Message { get; }

        public GetDashboardFailedException() : base() 
        {
            Message = "Failed to get dashboard invoices";
        }

    }

}
