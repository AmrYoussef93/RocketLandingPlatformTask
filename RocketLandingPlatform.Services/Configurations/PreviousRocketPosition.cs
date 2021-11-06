namespace RocketLandingPlatform.Services.Configurations
{
    /// <summary>
    /// i created it as singlton class to be one instance through application
    /// </summary>
    public class PreviousRocketPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsPositionUsed { get; set; }

        private static PreviousRocketPosition previousRocketPositionInstance;

        private PreviousRocketPosition()
        {

        }
        public static PreviousRocketPosition GetPreviousRocketPositionInstance()
        {
            if (previousRocketPositionInstance == null)
            {
                previousRocketPositionInstance = new PreviousRocketPosition();
                return previousRocketPositionInstance;
            }
            return previousRocketPositionInstance;
        }
    }
}
