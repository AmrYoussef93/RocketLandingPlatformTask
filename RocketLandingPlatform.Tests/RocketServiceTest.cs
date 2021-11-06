using Microsoft.Extensions.Options;
using RocketLandingPlatform.Services.Configurations;
using RocketLandingPlatform.Services.Implementations;
using RocketLandingPlatform.Services.Utilities;
using System.Threading.Tasks;
using Xunit;

namespace RocketLandingPlatform.Tests
{
    public class RocketServiceTest
    {
        IOptions<LandingAreaConfiguration> _landingAreaConfigurationOptions;
        public RocketServiceTest()
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
        [InlineData(12, 7)]
        public async Task ValidateRocketLanding_PositionInsideRange_ReturnsLanding(int x, int y)
        {
            // Arrange
            RocketService rocketService = new RocketService(_landingAreaConfigurationOptions);

            // Act 
            string landingResult = await rocketService.ValidateRocketLandingAsync(x, y);

            // Assert
            Assert.Equal(ResponseMessages.Landing, landingResult);
        }

        [Theory]
        [InlineData(15, 16)]
        public async Task ValidateRocketLanding_PositionOutsideRange_ReturnsOutOfPlatform(int x, int y)
        {
            // Arrange
            RocketService rocketService = new RocketService(_landingAreaConfigurationOptions);

            // Act 
            string landingResult = await rocketService.ValidateRocketLandingAsync(x, y);

            // Assert
            Assert.Equal(ResponseMessages.OutOfPlatform, landingResult);
        }

        [Fact]
        public async Task ValidateRocketLanding_PreviousRocketPosition_ReturnsClash()
        {
            // Arrange
            RocketService rocketService = new RocketService(_landingAreaConfigurationOptions);

            // Act 
            // to simulate that we sent two requests to test clashes scenario 
            // there is  another solution  is to create custom attribute  for x unit test  to set order for tests to  simulate sequence requests
            string landingResult = string.Empty;
            int x = 7; int y = 12;

            for (int i = 0; i < 2; i++)
            {
                landingResult = await rocketService.ValidateRocketLandingAsync(x,y);
                x = 7;
                y = 12;
            }

            // Assert
            Assert.Equal(ResponseMessages.Clash, landingResult);
        }

        [Fact]
        public async Task ValidateRocketLanding_InsidePreviousRocketPositionRange_ReturnsClash()
        {
            // Arrange
            RocketService rocketService = new RocketService(_landingAreaConfigurationOptions);

            // Act 
            // to simulate that we sent two requests to test clashes scenario 
            // there is  another solution  is to create custom attribute  for x unit test  to set order for tests to  simulate sequence requests
            string landingResult = string.Empty;
            int x = 7; int y = 12;

            for (int i = 0; i < 2; i++)
            {
                landingResult = await rocketService.ValidateRocketLandingAsync(x, y);
                x = 6;
                y = 11;
            }

            // Assert
            Assert.Equal(ResponseMessages.Clash, landingResult);
        }
    }
}
