using Microsoft.Extensions.Options;
using RocketLandingPlatform.Services.Configurations;
using RocketLandingPlatform.Services.Interfaces;
using RocketLandingPlatform.Services.Utilities;
using System.Threading.Tasks;

namespace RocketLandingPlatform.Services.Implementations
{
    public class PlatformService : IPlatformService
    {
        private readonly LandingAreaConfiguration _landingAreaConfiguration;
        public PlatformService(IOptions<LandingAreaConfiguration> landingAreaConfigurationOptions)
        {
            _landingAreaConfiguration = landingAreaConfigurationOptions.Value;
        }

        public async Task<string> UpdatePlatformConfigurationsAsync(int size, int x, int y)
        {
            if (!IsPlatformInsideLandingArea(size, x, y))
                return ResponseMessages.PlatformOutOfLandingArea;

            _landingAreaConfiguration.Platform.Size = size;
            _landingAreaConfiguration.Platform.StartingPosition.X = x;
            _landingAreaConfiguration.Platform.StartingPosition.Y = y;
            return ResponseMessages.PlatformConfigurationUpdated;
        }
        private bool IsPlatformInsideLandingArea(int size, int x, int y)
        {
            int x_range = (x + size) - 1;
            int y_range = (y + size) - 1;
            return (x_range < _landingAreaConfiguration.Size && y_range < _landingAreaConfiguration.Size) ? true : false;
        }
    }
}
