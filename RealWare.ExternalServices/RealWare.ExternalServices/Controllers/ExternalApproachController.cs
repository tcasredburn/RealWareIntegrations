using Microsoft.AspNetCore.Mvc;
using RealWare.Core.ExternalApproach.Models;
using RealWare.Core.ExternalApproach.Models.Result;
using RealWare.Core.ExternalApproach.Models.Request;

namespace RealWare.ExternalServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalApproachController : ControllerBase
    {
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
                        ImpAbstractValue = 88888
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
                        ImpAbstractValue = 99999
                    }
                }
            };
            return Ok(result);
        }
    }
}
