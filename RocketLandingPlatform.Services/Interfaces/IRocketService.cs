using System.Threading.Tasks;

namespace RocketLandingPlatform.Services.Interfaces
{
    public interface IRocketService
    {
        Task<string> ValidateRocketLandingAsync(int x, int y);
    }
}
