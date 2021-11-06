using Microsoft.Extensions.Options;
using RocketLandingPlatform.Services.Configurations;
using RocketLandingPlatform.Services.Implementations;
using RocketLandingPlatform.Services.Utilities;
using System.Threading.Tasks;
using Xunit;

namespace RocketLandingPlatform.Tests
{
    public class PlatformServiceTest
    {
        IOptions<LandingAreaConfiguration> _landingAreaConfigurationOptions;
        public PlatformServiceTest()
        {
            _landingAreaConfigurationOptions = Options.Create(new LandingAreaConfiguration()
            {
                Size = 100,
                Platform = new PlatformConfigurationDTO()
                {
                    Size = 10,
                    StartingPosition = new Position()
                    {
                        X = 5,
                        Y = 5
                    }
                }
            });
        }

        [Theory]
        [InlineData(10, 50, 55)]
        public async Task UpdatePlatformConfigurations_PlatformInsideLandingArea_ReturnsUpdatedSuccessfully(int size, int x, int y)
        {
            // Arrange
            PlatformService platformService = new PlatformService(_landingAreaConfigurationOptions);

            // Act 
            string result = await platformService.UpdatePlatformConfigurationsAsync(size, x, y);

            // Assert
            Assert.Equal(ResponseMessages.PlatformConfigurationUpdated, result);
        }

        [Theory]
        [InlineData(10, 95, 95)]
        public async Task UpdatePlatformConfigurations_PlatformOutsideLandingArea_ReturnsOutOfLandingArea(int size, int x, int y)
        {
            // Arrange
            PlatformService platformService = new PlatformService(_landingAreaConfigurationOptions);

            // Act 
            string result = await platformService.UpdatePlatformConfigurationsAsync(size, x, y);

            // Assert
            Assert.Equal(ResponseMessages.PlatformOutOfLandingArea, result);
        }
    }
}
