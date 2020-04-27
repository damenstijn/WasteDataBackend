using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediatR;
using WasteData.App.Queries.GetTop10DownloadTests;
using System.Net;
using WasteData.App.Commands;
using WasteData.App.Queries.GetRankingPositionByDeviceId;

namespace WasteData.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class DownloadTestController : ControllerBase
    {

        private readonly ILogger<DownloadTestController> _logger;
        private readonly IMediator _mediator;

        public DownloadTestController(ILogger<DownloadTestController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        
        /// <summary>
        /// Get Top 10 download tests
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GetTop10DownloadTestsDto>> Get()
        {
            //try
            //{
                return await _mediator.Send(new GetTop10DownloadTestsQuery());
            //}
            //catch (Exception ex) 
            //{
            //    _logger.LogError(ex, "Error GetTop10DownloadTestsQuery");
            //}

            //return new List<GetTop10DownloadTestsDto>();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddDownloadTest([FromBody]AddDownloadTestDto request)
        {
            try
            {
                await _mediator.Send(new AddDownloadTestCommand { DownloadTest = request });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error AddDownloadTestCommand");
                return BadRequest("Error AddDownloadTestCommand");
            }

            return Created(string.Empty, null);
        }

        [HttpGet]
        [Route("ranking/{deviceGuid}")]
        public async Task<GetRankingPositionByDeviceIdDto> GetRankingPosition([FromRoute]Guid deviceGuid)
        {
            try
            {
                return await _mediator.Send(new GetRankingPositionByDeviceIdQuery { DeviceGuid = deviceGuid });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error GetRankingPositionByDeviceIdQuery");
            }

            return new GetRankingPositionByDeviceIdDto { Position = -1 };
        }
    }
}
