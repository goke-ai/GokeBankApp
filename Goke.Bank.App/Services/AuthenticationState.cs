using System.Security.Claims;

namespace Goke.Bank.App.Services
{
    public class AuthenticationState(ClaimsPrincipal user)
    {
        private ClaimsPrincipal user = user;

        public ClaimsPrincipal User => user;
    }
}