using Microsoft.AspNetCore.Mvc;
using RocketLandingPlatform.API.DTO;
using RocketLandingPlatform.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace RocketLandingPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlatformAsync(PlatformConfigurationDTO platform)
        {
            // there are different schools to catch exception in api layer or in service layer .
            // i could handle it in service layer also
            try
            {
                string result = await _platformService.UpdatePlatformConfigurationsAsync(platform.Size, platform.StartingPosition.X, platform.StartingPosition.Y);
                return Ok(result);
            }
            catch (Exception exp)
            {
                // log exp using logging 3rd party like serilog
                return StatusCode(500, exp.Message);
            }
        }
    }
}
