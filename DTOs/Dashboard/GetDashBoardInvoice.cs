namespace TaxReporter.DTOs.Dashboard
{
    public class GetDashBoardInvoice
    {
        public int PendingInvoices { get; set; }
        public int ApprovedInvoices { get; set; }
        public int UnapprovedInvoices { get; set; }

    }

}
