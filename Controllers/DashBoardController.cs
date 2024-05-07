using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxReporter.Contracts;
using TaxReporter.DTOs.Dashboard;
using TaxReporter.Utility;

namespace TaxReporter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardInvoiceService _dashBoardInvoiceService;

        public DashBoardController(IDashBoardInvoiceService dashBoardInvoiceService)
        {
            _dashBoardInvoiceService = dashBoardInvoiceService;
        }

        [Authorize]
        [HttpGet]
        [Route("dashboard")]
        public async Task<IActionResult> GetDashboardInvoicesCount()
        {
            var response = new Response<GetDashBoardInvoice>();

            try
            {
                response.status = true;
                response.value = await _dashBoardInvoiceService.GetDashboardInvoicesCount();
                response.message = "Dashboard data retrieved successfully";
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
