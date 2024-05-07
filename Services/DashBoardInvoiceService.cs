using Microsoft.EntityFrameworkCore;
using TaxReporter.DTOs.Dashboard;
using TaxReporter.Contracts;
using TaxReporter.DBContext;
using TaxReporter.Enums;
using TaxReporter.Exceptions.DashBoard;

namespace TaxReporter.Services
{
    public class DashBoardInvoiceService : IDashBoardInvoiceService
    {
        private readonly InvoiceManagementDbContext _dbContext;

        public DashBoardInvoiceService(InvoiceManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetDashBoardInvoice> GetDashboardInvoicesCount()
        {
            try
            {
                var pendingInvoices = await GetPendingInvoicesCount();
                var approvedInvoices = await GetApprovedInvoicesCount();
                var unapprovedInvoices = await GetUnapprovedInvoicesCount();

                return new GetDashBoardInvoice
                {
                    PendingInvoices = pendingInvoices,
                    ApprovedInvoices = approvedInvoices,
                    UnapprovedInvoices = unapprovedInvoices
                };
            }
            catch
            {
                throw new GetDashboardFailedException();
            }

        }

        public async Task<int> GetPendingInvoicesCount()
        {
            return await _dbContext.InvoiceInfos.CountAsync(state => state.StateId == (int)InvoiceStatus.Pending);
        }

        public async Task<int> GetApprovedInvoicesCount()
        {
            return await _dbContext.InvoiceInfos.CountAsync(state => state.StateId == (int)InvoiceStatus.Approved);
        }

        public async Task<int> GetUnapprovedInvoicesCount()
        {
            return await _dbContext.InvoiceInfos.CountAsync(state => state.StateId == (int)InvoiceStatus.NotApproved);
        }

    }

}
