using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Invoice;
using TaxReporter.DTOs.User;
using TaxReporter.Exceptions.Auth;
using TaxReporter.Exceptions.Invoice;
using TaxReporter.Exceptions.User;
using TaxReporter.Services;
using TaxReporter.Utility;

namespace TaxReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        public readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [Authorize]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody] CreateInvoice invoice)
        {
            var response = new Response<GetInvoice>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.Register(invoice);
                throw new SuccessfulRegistrationInvoiceException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpGet]
        [Route("GetAllInvoice")]
        public async Task<IActionResult> GetAllInvoice()
        {
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetAsync();
                throw new GetInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpGet]
        [Route("GetPendingInvoices")]
        public async Task<IActionResult> GetPendingInvoices()
        {
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetPendingInvoicesAsync();
                throw new GetPendingInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpGet]
        [Route("GetApprovedInvoices")]
        public async Task<IActionResult> GetApprovedInvoices()
        {
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetApprovedInvoicesAsync();
                throw new GetApprovedInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpGet]
        [Route("GetUnapprovedInvoices")]
        public async Task<IActionResult> GetUnapprovedInvoices()
        {
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetUnapprovedInvoicesAsync();
                throw new GetUnapprovedInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpGet]
        [Route("GetPendingInvoicesFromUser/{userId}")]
        public async Task<IActionResult> GetPendingInvoiceByUser(int userId)
        {
            var respuesta = new Response<List<GetInvoice>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _invoiceService.GetPendingInvoiceByUser(userId);
                throw new GetPendingInvoiceSuccessfulException();

            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.message = ex.Message;
            }

            return Ok(respuesta);
        }

        [Authorize]
        [HttpGet]
        [Route("GetApprovedInvoicesFromUser/{userId}")]
        public async Task<IActionResult> GetApprovedInvoiceByUser(int userId)
        {
            var respuesta = new Response<List<GetInvoice>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _invoiceService.GetApprovedInvoiceByUser(userId);
                throw new GetApprovedInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.message = ex.Message;
            }

            return Ok(respuesta);
        }

        [Authorize]
        [HttpGet]
        [Route("GetUnapprovedInvoicesFromUser/{userId}")]
        public async Task<IActionResult> GetUnapprovedInvoiceByUser(int userId)
        {
            var respuesta = new Response<List<GetInvoice>>();

            try
            {
                respuesta.status = true;
                respuesta.value = await _invoiceService.GetUnapprovedInvoiceByUser(userId);
                throw new GetUnapprovedInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                respuesta.status = false;
                respuesta.message = ex.Message;
            }

            return Ok(respuesta);
        }

        [Authorize]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoice invoice)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.UpdateAsync(invoice);
                throw new UpdateInvoiceSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpPut]
        [Route("UpdateState")]
        public async Task<IActionResult> UpdateState([FromBody] UpdateState invoice)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.UpdateStateAsync(invoice);
                throw new UpdateInvoiceStateSuccessfulException();
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return Ok(response);

        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteInvoice/{invoiceId:int}")]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.DeleteAsync(invoiceId);
                throw new DeleteInvoiceSuccessfulException();
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
