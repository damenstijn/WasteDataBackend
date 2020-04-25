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

namespace WasteData.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadTestController : ControllerBase
    {

        private readonly ILogger<DownloadTestController> _logger;
        private readonly IMediator _mediator;

        public DownloadTestController(ILogger<DownloadTestController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<DownloadTestDto>> Get()
        {
            try
            {
                return await _mediator.Send(new GetTop10DownloadTestsQuery());
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error GetTop10DownloadTestsQuery");
            }

            return new List<DownloadTestDto>();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddDownloadTest(
            [FromBody]AddDownloadTestDto request)
        {
            await _mediator.Send(new AddDownloadTestCommand { DownloadTest = request});

            return Created(string.Empty, null);
        }
    }
}
