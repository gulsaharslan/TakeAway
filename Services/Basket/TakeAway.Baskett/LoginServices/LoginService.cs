namespace TakeAway.Baskett.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId { get => _contextAccessor.HttpContext.User.FindFirst("sub").Value; }
    }
}
