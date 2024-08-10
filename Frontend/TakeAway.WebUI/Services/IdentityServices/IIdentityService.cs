using TakeAway.WebUI.Dtos.IdentityDtos;

namespace TakeAway.WebUI.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
    }
}
