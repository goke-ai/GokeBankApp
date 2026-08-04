using Goke.Bank.App.Pages.Account;
using Goke.Core.Interfaces;

namespace Goke.Bank.App;

public class AuthorizePage : ContentPage
{
    public AuthorizePage()
    {
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var authService = ServiceHelper.GetService<IAuthenticationService>();

        var attribute = GetType().GetCustomAttributes(typeof(AuthorizeAttribute), true)
                                 .FirstOrDefault() as AuthorizeAttribute;

        if (attribute != null)
        {
            if (!authService.IsAuthenticatedAsync().Result)
            {
                await Shell.Current.GoToAsync("//LoginPage");
                return;
            }

            if (!string.IsNullOrEmpty(attribute.Roles))
            {
                var requiredRoles = attribute.Roles.Split(',');

                bool hasRole = requiredRoles.Any(r => authService.IsInRoleAsync(r.Trim()).Result);

                if (!hasRole)
                {
                    await Shell.Current.DisplayAlertAsync("Access Denied", "You do not have permission.", "OK");
                    await Shell.Current.GoToAsync("//MainPage");
                }
            }
        }
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);

    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    

}
