using TaxReporter.DTOs.Dashboard;

namespace TaxReporter.Contracts
{
    public interface IDashBoardInvoiceService
    {
        Task<GetDashBoardInvoice> GetDashboardInvoicesCount();
        Task<int> GetPendingInvoicesCount();
        Task<int> GetApprovedInvoicesCount();
        Task<int> GetUnapprovedInvoicesCount();
    }
}
