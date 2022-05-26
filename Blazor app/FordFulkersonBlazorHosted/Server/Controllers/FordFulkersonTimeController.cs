using FordFulkersonBlazor.Shared;
using FordFulkersonBlazorHosted.Server;
using Microsoft.AspNetCore.Mvc;

namespace FordFulkersonBlazor.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FordFulkersonTimeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            Console.Write("read");
            int[,] matrix = ReadMatrixService.readMatrix();
            return Ok(FordFulkersonTimeFlowService.getTimeFlow(matrix));
        }
    }
}
