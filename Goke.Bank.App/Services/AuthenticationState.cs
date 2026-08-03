using System.Security.Claims;

namespace Goke.Bank.App.Services
{
    public class AuthenticationState
    {
        private ClaimsPrincipal defaultUser;

        public AuthenticationState(ClaimsPrincipal defaultUser)
        {
            this.defaultUser = defaultUser;
        }
    }
}