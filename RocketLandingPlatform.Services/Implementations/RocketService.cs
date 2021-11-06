using Microsoft.Extensions.Options;
using RocketLandingPlatform.Services.Configurations;
using RocketLandingPlatform.Services.Interfaces;
using RocketLandingPlatform.Services.Utilities;
using System.Threading.Tasks;

namespace RocketLandingPlatform.Services.Implementations
{
    public class RocketService : IRocketService
    {
        private readonly LandingAreaConfiguration _landingAreaConfiguration;
        public RocketService(IOptions<LandingAreaConfiguration> landingAreaConfigurationOptions)
        {
            _landingAreaConfiguration = landingAreaConfigurationOptions.Value;
        }

        public async Task<string> ValidateRocketLandingAsync(int x, int y)
        {
            //1- check if position inside platform
            if (!IsRocketPositionInsidePlatformRange(x, y))
                return ResponseMessages.OutOfPlatform;

            //2- if previous position is empty so set it by new position
            PreviousRocketPosition previousRocketPosition = PreviousRocketPosition.GetPreviousRocketPositionInstance();

            if (!previousRocketPosition.IsPositionUsed)
            {
                UpdatePreviousRocketPosition(previousRocketPosition, x, y);
                return ResponseMessages.Landing;
            }
            else
            {
                // 3- check that new position not in surrounding positions
                if (!IsRocketPositionInsideClashesArea(x, y, previousRocketPosition))
                {
                    UpdatePreviousRocketPosition(previousRocketPosition, x, y);
                    return ResponseMessages.Landing;
                }
                else
                {
                    return ResponseMessages.Clash;
                }
            }
        }

        #region Private Methods
        /// <summary>
        /// check is rocket position inside platform area
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
        private bool IsRocketPositionInsidePlatformRange(int x, int y)
        {
            int x_range = (_landingAreaConfiguration.Platform.StartingPosition.X + _landingAreaConfiguration.Platform.Size) - 1;
            int y_range = (_landingAreaConfiguration.Platform.StartingPosition.Y + _landingAreaConfiguration.Platform.Size) - 1;

            return ((x >= _landingAreaConfiguration.Platform.StartingPosition.X && x <= x_range) && (y >= _landingAreaConfiguration.Platform.StartingPosition.Y && y <= y_range)) ? true : false;
        }

        private bool IsRocketPositionInsideClashesArea(int x, int y, PreviousRocketPosition previousRocketPosition)
        {

            return ((x >= (previousRocketPosition.X - 1) && x <= (previousRocketPosition.X + 1)) && (y >= (previousRocketPosition.Y - 1) && y <= (previousRocketPosition.Y + 1))) ? true : false;
        }

        /// <summary>
        /// update previous rocket position
        /// </summary>
        /// <param name="previousRocketPosition"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void UpdatePreviousRocketPosition(PreviousRocketPosition previousRocketPosition, int x, int y)
        {
            previousRocketPosition.X = x;
            previousRocketPosition.Y = y;
            previousRocketPosition.IsPositionUsed = true;
        }
        #endregion
    }
}
