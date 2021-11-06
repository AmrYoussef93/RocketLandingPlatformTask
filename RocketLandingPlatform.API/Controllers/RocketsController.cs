using Microsoft.AspNetCore.Mvc;
using RocketLandingPlatform.API.DTO;
using RocketLandingPlatform.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace RocketLandingPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RocketsController : ControllerBase
    {
        private readonly IRocketService _rocketService;
        public RocketsController(IRocketService rocketService)
        {
            _rocketService = rocketService;
        }

        [HttpPost("landing")]
        public async Task<IActionResult> RocketsLandingAsync(RocketLandingDTO landingDTO)
        {
            // there are different schools to catch exception in api layer or in service layer .
            // i could handle it in service layer also
            try
            {
                return Ok(await _rocketService.ValidateRocketLandingAsync(landingDTO.X, landingDTO.Y));
            }
            catch (Exception exp)
            {
                // log exp using logging 3rd party like serilog
                return StatusCode(500, exp.Message);
            }

        }
    }
}
