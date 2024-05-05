using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.InvoiceState;
using TaxReporter.Exceptions.InvoiceState;
using TaxReporter.Utility;

namespace TaxReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceStateController : ControllerBase
    {
        private readonly IInvoiceStateService _invoiceStateService;

        public InvoiceStateController(IInvoiceStateService invoiceStateService)
        {
            _invoiceStateService = invoiceStateService;
        }

        [Authorize]
        [HttpGet]
        [Route("GetInvoiceState")]
        public async Task<IActionResult> GetInvoiveState()
        {
            var response = new Response<List<GetState>>();

            try
            {
                response.status = true;
                response.value = await _invoiceStateService.GetListAsycn();
                throw new GetInvoiceStateSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }
    }
}
