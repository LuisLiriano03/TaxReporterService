using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Invoice;
using TaxReporter.Exceptions.Invoice;
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
                response.message = "Registration successful";
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
                response.message = "Successful Invoices";
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
                response.message = "Successful pending invoices";
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
                response.message = "Successful approved invoices";
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
                response.message = "successful unapproved invoices";
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
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetPendingInvoiceByUser(userId);
                response.message = "Successful pending invoices";
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
        [Route("GetApprovedInvoicesFromUser/{userId}")]
        public async Task<IActionResult> GetApprovedInvoiceByUser(int userId)
        {
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetApprovedInvoiceByUser(userId);
                response.message = "Successful approved invoices";
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
        [Route("GetUnapprovedInvoicesFromUser/{userId}")]
        public async Task<IActionResult> GetUnapprovedInvoiceByUser(int userId)
        {
            var response = new Response<List<GetInvoice>>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.GetUnapprovedInvoiceByUser(userId);
                response.message = "successful unapproved invoices";
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
        [Route("Update")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoice invoice)
        {
            var response = new Response<bool>();

            try
            {
                response.status = true;
                response.value = await _invoiceService.UpdateAsync(invoice);
                response.message = "Invoice information updated successfully";
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
                response.message = "Invoice state information updated successfully";
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
                response.message = "Invoice information successfully deleted";
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
