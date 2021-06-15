using CheapAwesome.Application;
using CheapAwesome.Infrastructure.BargainCouplesClient;
using CheapAwesome.Infrastructure.BargainCouplesClient.Dtos;
using CheapAwesome.Utils.Refit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CheapAwesome.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvailabilityController : ControllerBase
    {
        private readonly string _code = "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==";

        private readonly ILogger<AvailabilityController> _logger;
        private readonly RefitClientFactory _refitClientFactory;

        public AvailabilityController(ILogger<AvailabilityController> logger,
            RefitClientFactory refitClientFactory)
        {
            _logger = logger;
            _refitClientFactory = refitClientFactory;
        }

        [HttpGet("GetListHotelWithOneFinalPricePerBoard/{destinationId}/{nights}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<BargainResponse>>> GetListHotelWithOneFinalPricePerBoard(int destinationId, int nights)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                var bargainClient = _refitClientFactory.GetService<IBargainCouplesClient>();

                var response = await bargainClient.FindBargain(destinationId, nights, _code);

                new Price().CalculateNightPrice(nights, response);

                sw.Stop();
                Console.WriteLine("Elapsed={0}" + System.Environment.NewLine, sw.Elapsed);

                return Ok(response);
            }
            catch(Exception ex)
            {
#if DEBUG
                return BadRequest(ex.Message);
#else
                _logger.LogDebug(ex.Message);
                return BadRequest("Service not available");
#endif
            }
        }
    }
}
