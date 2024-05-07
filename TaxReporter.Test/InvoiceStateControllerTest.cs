using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.Utility;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.DTOs.InvoiceState;

namespace TaxReporter.Test
{
    public class InvoiceStateControllerTest
    {
        private readonly Mock<IInvoiceStateService> _invoiceStateServiceMock;
        private readonly InvoiceStateController _invoiceStateController;

        public InvoiceStateControllerTest()
        {
            _invoiceStateServiceMock = new Mock<IInvoiceStateService>();
            _invoiceStateController = new InvoiceStateController(_invoiceStateServiceMock.Object);
        }

        [Fact]
        public async Task GetInvoiveState_Successful_ReturnsOkResult()
        {
            var expectedStates = new List<GetState>
            {
                new GetState { StateId = 1, StateName = "State 1" },
                new GetState { StateId = 2, StateName = "State 2" }
            };

            _invoiceStateServiceMock.Setup(x => x.GetListAsycn())
                .ReturnsAsync(expectedStates);

            var result = await _invoiceStateController.GetInvoiveState() as OkObjectResult;
            var response = result.Value as Response<List<GetState>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedStates, response.value);

        }

    }

}
