using RocketLandingPlatform.Services.Utilities;

namespace RocketLandingPlatform.Services.Configurations
{
    public class LandingAreaConfiguration
    {
        public int Size { get; set; }
        public PlatformConfigurationDTO Platform { get; set; }
    }
    public class PlatformConfigurationDTO
    {
        public int Size { get; set; }
        public Position StartingPosition { get; set; }
    }
}
