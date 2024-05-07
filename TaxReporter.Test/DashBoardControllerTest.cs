using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Dashboard;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Utility;

namespace TaxReporter.Test
{
    public class DashBoardControllerTest
    {
        private readonly Mock<IDashBoardInvoiceService> _dashBoardInvoiceServiceMock;
        private readonly DashBoardController _dashBoardController;

        public DashBoardControllerTest()
        {
            _dashBoardInvoiceServiceMock = new Mock<IDashBoardInvoiceService>();
            _dashBoardController = new DashBoardController(_dashBoardInvoiceServiceMock.Object);
        }

        [Fact]
        public async Task GetDashboardInvoicesCount_Successful_ReturnsOkResult()
        {
            var pendingInvoicesCount = 8;
            var approvedInvoicesCount = 2;
            var unapprovedInvoicesCount = 2;

            var expectedDashboardData = new GetDashBoardInvoice
            {
                PendingInvoices = pendingInvoicesCount,
                ApprovedInvoices = approvedInvoicesCount,
                UnapprovedInvoices = unapprovedInvoicesCount
            };

            _dashBoardInvoiceServiceMock.Setup(x => x.GetDashboardInvoicesCount())
                .ReturnsAsync(expectedDashboardData);

            var result = await _dashBoardController.GetDashboardInvoicesCount() as OkObjectResult;
            var response = result.Value as Response<GetDashBoardInvoice>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedDashboardData.PendingInvoices, response.value.PendingInvoices);
            Assert.Equal(expectedDashboardData.ApprovedInvoices, response.value.ApprovedInvoices);
            Assert.Equal(expectedDashboardData.UnapprovedInvoices, response.value.UnapprovedInvoices);
        
        }

        [Fact]
        public async Task GetDashboardInvoicesCount_Failure_ReturnsOkResult()
        {
            var errorMessage = "An error occurred while fetching dashboard data.";

            _dashBoardInvoiceServiceMock.Setup(x => x.GetDashboardInvoicesCount())
                .ThrowsAsync(new TaskCanceledException(errorMessage));

            var result = await _dashBoardController.GetDashboardInvoicesCount() as OkObjectResult;
            var response = result.Value as Response<GetDashBoardInvoice>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.False(response.status);
            Assert.Equal(errorMessage, response.message);

        }

    }

}

