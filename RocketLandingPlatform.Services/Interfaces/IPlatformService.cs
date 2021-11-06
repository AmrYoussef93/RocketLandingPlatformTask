using System.Threading.Tasks;

namespace RocketLandingPlatform.Services.Interfaces
{
    public interface IPlatformService
    {
        Task<string> UpdatePlatformConfigurationsAsync(int size, int x, int y);
    }
}
