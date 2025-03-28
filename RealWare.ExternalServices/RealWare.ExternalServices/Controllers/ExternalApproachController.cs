using Microsoft.AspNetCore.Mvc;
using RealWare.Core.ExternalApproach.Models;
using RealWare.Core.ExternalApproach.Models.Result;
using RealWare.Core.ExternalApproach.Models.Request;
using System.Text;
using Newtonsoft.Json;

namespace RealWare.ExternalServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalApproachController : ControllerBase
    {
        const int EXAMPLE_COST_VALUE = 99999;

        private readonly ILogger<ExternalApproachController> _logger;

        public ExternalApproachController(ILogger<ExternalApproachController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[action]")]
        public IActionResult TestExternalIncomeValue([FromBody] ExternalApproachProperty data)
        {
            var request = HttpContext.Request;

            var result = new IncomeExternalApproachResult
            {
                ImprovementOccupancyValues = new List<RWImprovementOccupancyValue>()
                {
                    new RWImprovementOccupancyValue
                    {
                        AccountNo = data.AccountNo,
                        ImpNo = (int)data.ImpNo,
                        DetailID = data.Occupancies[0].DetailId,
                        OccCode = data.Occupancies[0].OccCode,

                        //TODO: Update this to your custom logic to handle the value
                        ImpAbstractValue = EXAMPLE_COST_VALUE
                    }
                }
            };
            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult TestExternalMarketValue([FromBody] ExternalApproachProperty data)
        {
            var request = HttpContext.Request;

            var result = new MarketExternalApproachResult
            {
                ImprovementOccupancyValues = new List<RWImprovementOccupancyValue>()
                {
                    new RWImprovementOccupancyValue
                    {
                        AccountNo = data.AccountNo,
                        ImpNo = (int)data.ImpNo,
                        DetailID = data.Occupancies[0].DetailId,
                        OccCode = data.Occupancies[0].OccCode,

                        //TODO: Update this to your custom logic to handle the value
                        ImpAbstractValue = EXAMPLE_COST_VALUE
                    }
                }
            };
            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult TestExternalCostValue([FromBody] ExternalApproachProperty data)
        {
            var request = HttpContext.Request;

            var result = new CostExternalApproachResult
            {
                AccountNo = data.AccountNo,
                ImpNo = (int)data.ImpNo,
                TotalExternalCostValue = EXAMPLE_COST_VALUE,
                BuiltAs = new List<RWCostBuiltAsValue>()
            };

            // TODO: Update this to your custom logic to handle the value
            foreach (var builtAs in data.BuiltAs)
            {
                result.BuiltAs.Add(new RWCostBuiltAsValue
                {
                    ImpNo = data.ImpNo,
                    BuiltAsId = builtAs.DetailId,
                    ExternalCostValue = EXAMPLE_COST_VALUE
                });
            }

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DebugExternalValue()
        {
            HttpContext.Request.EnableBuffering();
            using var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, leaveOpen: true);
            var bodyContent = await reader.ReadToEndAsync();
            HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);

            var resultDataAsText = bodyContent;
            var resultDataAsJson = JsonConvert.DeserializeObject(bodyContent);

            return BadRequest("This is just meant to help debug values being sent from RealWare. This will just error in RealWare.");
        }
    }
}
