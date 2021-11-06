namespace RocketLandingPlatform.API.DTO
{
    public class PlatformConfigurationDTO
    {
        public int Size { get; set; }
        public CoordinatesDTO StartingPosition { get; set; }
    }
    public class CoordinatesDTO
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
