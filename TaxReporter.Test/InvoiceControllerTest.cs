using Moq;
using TaxReporter.Controllers;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Invoice;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Utility;

namespace TaxReporter.Test
{
    public class InvoiceControllerTest
    {
        private readonly Mock<IInvoiceService> _invoiceServiceMock;
        private readonly InvoiceController _invoiceController;

        public InvoiceControllerTest()
        {
            _invoiceServiceMock = new Mock<IInvoiceService>();
            _invoiceController = new InvoiceController(_invoiceServiceMock.Object);
        }

        [Fact]
        public async Task Register_ValidInvoice_ReturnsOkResult()
        {
            var createInvoiceRequest = new CreateInvoice
            {
                UserId = 1,
                BusinessName = "Example Business",
                Rnc = "123456789",
                Nfc = "987654321",
                AmountWithoutItbis = 100.50m,
                Itbis = 18.09m,
                ServicePercentage = 10.25m,
                TotalAmount = 128.84m,
                ImageUrl = "https://example.com/image.jpg"
            };

            var expectedInvoice = new GetInvoice
            {
                InvoiceId = 1,
                UserId = createInvoiceRequest.UserId,
                BusinessName = createInvoiceRequest.BusinessName,
                Rnc = createInvoiceRequest.Rnc,
                Nfc = createInvoiceRequest.Nfc,
                AmountWithoutItbis = createInvoiceRequest.AmountWithoutItbis,
                Itbis = createInvoiceRequest.Itbis,
                ServicePercentage = createInvoiceRequest.ServicePercentage,
                TotalAmount = createInvoiceRequest.TotalAmount,
                ImageUrl = createInvoiceRequest.ImageUrl,
                StateId = 1,
                StateName = "Pending"
            };

            _invoiceServiceMock.Setup(x => x.Register(createInvoiceRequest))
                .ReturnsAsync(expectedInvoice);

            var result = await _invoiceController.register(createInvoiceRequest) as OkObjectResult;
            var response = result.Value as Response<GetInvoice>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoice, response.value);

        }

        [Fact]
        public async Task Register_InvalidInvoice_ReturnsErrorResult()
        {
            var createInvoiceRequest = new CreateInvoice
            {
                UserId = 1,
                BusinessName = "Mi Empresa",
                Rnc = "123456789",
                Nfc = "987654321",
                AmountWithoutItbis = 100.0m,
                Itbis = 18.0m,
                ServicePercentage = 10.0m,
                TotalAmount = 118.0m,
                ImageUrl = "https://example.com/invoice_image.jpg"
            };

            var expectedErrorMessage = "Error al registrar la factura";

            _invoiceServiceMock.Setup(x => x.Register(createInvoiceRequest))
                .ThrowsAsync(new Exception(expectedErrorMessage));

            var result = await _invoiceController.register(createInvoiceRequest) as OkObjectResult;
            var response = result.Value as Response<GetInvoice>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.False(response.status);
            Assert.Equal(expectedErrorMessage, response.message);

        }

        [Fact]
        public async Task GetAllInvoice_Successful_ReturnsOkResult()
        {
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice {
                    InvoiceId = 1,
                    UserId = 123,
                    UserName = "John Doe",
                    BusinessName = "ABC Company",
                    Rnc = "123456789",
                    Nfc = "987654321",
                    AmountWithoutItbis = 100.00m,
                    Itbis = 18.00m,
                    ServicePercentage = 5.00m,
                    TotalAmount = 123.00m,
                    ImageUrl = "https://example.com/invoice1.jpg",
                    StateId = 1,
                    StateName = "Approved"
                },
                new GetInvoice {
                    InvoiceId = 2,
                    UserId = 456,
                    UserName = "Jane Smith",
                    BusinessName = "XYZ Inc.",
                    Rnc = "987654321",
                    Nfc = "123456789",
                    AmountWithoutItbis = 150.00m,
                    Itbis = 27.00m,
                    ServicePercentage = 7.00m,
                    TotalAmount = 177.00m,
                    ImageUrl = "https://example.com/invoice2.jpg",
                    StateId = 2,
                    StateName = "Pending"
                },

            };

            _invoiceServiceMock.Setup(x => x.GetAsync()).ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetAllInvoice() as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices, response.value);

        }

        [Fact]
        public async Task GetPendingInvoices_Successful_ReturnsOkResult()
        {
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice
                {
                    InvoiceId = 1,
                    UserId = 1,
                    UserName = "John Doe",
                    BusinessName = "ABC Company",
                    Rnc = "123456789",
                    Nfc = "NFC123",
                    AmountWithoutItbis = 100.00m,
                    Itbis = 18.00m,
                    ServicePercentage = 10.00m,
                    TotalAmount = 128.00m,
                    ImageUrl = "https://example.com/image1.jpg",
                    StateId = 1,
                    StateName = "Pending"
                },
                new GetInvoice
                {
                    InvoiceId = 2,
                    UserId = 2,
                    UserName = "Jane Smith",
                    BusinessName = "XYZ Corporation",
                    Rnc = "987654321",
                    Nfc = "NFC456",
                    AmountWithoutItbis = 150.00m,
                    Itbis = 27.00m,
                    ServicePercentage = 15.00m,
                    TotalAmount = 192.00m,
                    ImageUrl = "https://example.com/image2.jpg",
                    StateId = 1,
                    StateName = "Pending"
                }

            };

            _invoiceServiceMock.Setup(x => x.GetPendingInvoicesAsync()).ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetPendingInvoices() as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices, response.value);

        }

        [Fact]
        public async Task GetApprovedInvoices_Successful_ReturnsOkResult()
        {
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice
                {
                    InvoiceId = 1,
                    UserId = 1,
                    UserName = "John Doe",
                    BusinessName = "ABC Company",
                    Rnc = "123456789",
                    Nfc = "NFC123",
                    AmountWithoutItbis = 100.00m,
                    Itbis = 18.00m,
                    ServicePercentage = 10.00m,
                    TotalAmount = 128.00m,
                    ImageUrl = "https://example.com/image1.jpg",
                    StateId = 2,
                    StateName = "Approved"
                },
                new GetInvoice
                {
                    InvoiceId = 2,
                    UserId = 2,
                    UserName = "Jane Smith",
                    BusinessName = "XYZ Corporation",
                    Rnc = "987654321",
                    Nfc = "NFC456",
                    AmountWithoutItbis = 150.00m,
                    Itbis = 27.00m,
                    ServicePercentage = 15.00m,
                    TotalAmount = 192.00m,
                    ImageUrl = "https://example.com/image2.jpg",
                    StateId = 2,
                    StateName = "Approved"
                }

            };

            _invoiceServiceMock.Setup(x => x.GetApprovedInvoicesAsync())
                .ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetApprovedInvoices() as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices.Count, response.value.Count);

        }

        [Fact]
        public async Task GetUnapprovedInvoices_Successful_ReturnsOkResult()
        {
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice
                {
                    InvoiceId = 3,
                    UserId = 3,
                    UserName = "Alice Johnson",
                    BusinessName = "123 Corporation",
                    Rnc = "789456123",
                    Nfc = "NFC789",
                    AmountWithoutItbis = 200.00m,
                    Itbis = 36.00m,
                    ServicePercentage = 20.00m,
                    TotalAmount = 256.00m,
                    ImageUrl = "https://example.com/image3.jpg",
                    StateId = 3,
                    StateName = "Not Approved"
                },
                new GetInvoice
                {
                    InvoiceId = 4,
                    UserId = 4,
                    UserName = "Bob Williams",
                    BusinessName = "456 Enterprises",
                    Rnc = "987123654",
                    Nfc = "NFC987",
                    AmountWithoutItbis = 250.00m,
                    Itbis = 45.00m,
                    ServicePercentage = 25.00m,
                    TotalAmount = 320.00m,
                    ImageUrl = "https://example.com/image4.jpg",
                    StateId = 3,
                    StateName = "Not Approved"
                }

            };

            _invoiceServiceMock.Setup(x => x.GetUnapprovedInvoicesAsync())
                .ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetUnapprovedInvoices() as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices.Count, response.value.Count);

        }

        [Fact]
        public async Task GetPendingInvoiceByUser_Successful_ReturnsOkResult()
        {
            int userId = 1;
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice
                {
                    InvoiceId = 1,
                    UserId = userId,
                    UserName = "John Doe",
                    BusinessName = "ACME Corporation",
                    Rnc = "123456789",
                    Nfc = "NFC123",
                    AmountWithoutItbis = 100.00m,
                    Itbis = 18.00m,
                    ServicePercentage = 10.00m,
                    TotalAmount = 128.00m,
                    ImageUrl = "https://example.com/image1.jpg",
                    StateId = 1,
                    StateName = "Pending"
                },
                new GetInvoice
                {
                    InvoiceId = 2,
                    UserId = userId,
                    UserName = "John Doe",
                    BusinessName = "ACME Corporation",
                    Rnc = "123456789",
                    Nfc = "NFC456",
                    AmountWithoutItbis = 150.00m,
                    Itbis = 27.00m,
                    ServicePercentage = 15.00m,
                    TotalAmount = 192.00m,
                    ImageUrl = "https://example.com/image2.jpg",
                    StateId = 1,
                    StateName = "Pending"
                }

            };

            _invoiceServiceMock.Setup(x => x.GetPendingInvoiceByUser(userId))
                .ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetPendingInvoiceByUser(userId) as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices.Count, response.value.Count);

        }

        [Fact]
        public async Task GetApprovedInvoiceByUser_Successful_ReturnsOkResult()
        {
            int userId = 1; 
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice
                {
                    InvoiceId = 1,
                    UserId = userId,
                    UserName = "John Doe",
                    BusinessName = "ACME Corporation",
                    Rnc = "123456789",
                    Nfc = "NFC123",
                    AmountWithoutItbis = 100.00m,
                    Itbis = 18.00m,
                    ServicePercentage = 10.00m,
                    TotalAmount = 128.00m,
                    ImageUrl = "https://example.com/image1.jpg",
                    StateId = 2,
                    StateName = "Approved"
                },
                new GetInvoice
                {
                    InvoiceId = 2,
                    UserId = userId,
                    UserName = "John Doe",
                    BusinessName = "ACME Corporation",
                    Rnc = "123456789",
                    Nfc = "NFC456",
                    AmountWithoutItbis = 150.00m,
                    Itbis = 27.00m,
                    ServicePercentage = 15.00m,
                    TotalAmount = 192.00m,
                    ImageUrl = "https://example.com/image2.jpg",
                    StateId = 2,
                    StateName = "Approved"
                }

            };

            _invoiceServiceMock.Setup(x => x.GetApprovedInvoiceByUser(userId))
                .ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetApprovedInvoiceByUser(userId) as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices.Count, response.value.Count);

        }

        [Fact]
        public async Task GetUnapprovedInvoiceByUser_Successful_ReturnsOkResult()
        {
            int userId = 1;
            var expectedInvoices = new List<GetInvoice>
            {
                new GetInvoice
                {
                    InvoiceId = 3,
                    UserId = userId,
                    UserName = "John Doe",
                    BusinessName = "ACME Corporation",
                    Rnc = "123456789",
                    Nfc = "NFC789",
                    AmountWithoutItbis = 200.00m,
                    Itbis = 36.00m,
                    ServicePercentage = 20.00m,
                    TotalAmount = 256.00m,
                    ImageUrl = "https://example.com/image3.jpg",
                    StateId = 3,
                    StateName = "Not Approved"
                }

            };

            _invoiceServiceMock.Setup(x => x.GetUnapprovedInvoiceByUser(userId))
                .ReturnsAsync(expectedInvoices);

            var result = await _invoiceController.GetUnapprovedInvoiceByUser(userId) as OkObjectResult;
            var response = result.Value as Response<List<GetInvoice>>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.Equal(expectedInvoices.Count, response.value.Count);

        }

        [Fact]
        public async Task UpdateInvoice_Successful_ReturnsOkResult()
        {
            var updateInvoiceRequest = new UpdateInvoice
            {
                InvoiceId = 1,
                BusinessName = "Updated Business Name",
                Rnc = "Updated RNC",
                Nfc = "Updated NFC",
                AmountWithoutItbis = 1000.00m,
                Itbis = 180.00m,
                ServicePercentage = 18.00m,
                TotalAmount = 1180.00m,
                ImageUrl = "https://updated-image-url.com"
            };

            _invoiceServiceMock.Setup(x => x.UpdateAsync(updateInvoiceRequest))
                .ReturnsAsync(true);

            var result = await _invoiceController.UpdateInvoice(updateInvoiceRequest) as OkObjectResult;
            var response = result.Value as Response<bool>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.True(response.value);

        }

        [Fact]
        public async Task UpdateState_Successful_ReturnsOkResult()
        {
            var updateStateRequest = new UpdateState
            {
                InvoiceId = 1,
                StateId = 2
            };

            _invoiceServiceMock.Setup(x => x.UpdateStateAsync(updateStateRequest))
                .ReturnsAsync(true);

            var result = await _invoiceController.UpdateState(updateStateRequest) as OkObjectResult;
            var response = result.Value as Response<bool>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.True(response.value);

        }

        [Fact]
        public async Task DeleteInvoice_Successful_ReturnsOkResult()
        {
            int invoiceIdToDelete = 1;

            _invoiceServiceMock.Setup(x => x.DeleteAsync(invoiceIdToDelete))
                .ReturnsAsync(true);

            var result = await _invoiceController.DeleteInvoice(invoiceIdToDelete) as OkObjectResult;
            var response = result.Value as Response<bool>;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(response);
            Assert.True(response.status);
            Assert.True(response.value);

        }

    }

}
