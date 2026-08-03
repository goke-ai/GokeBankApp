using Goke.Bank.App.Services;
using Goke.Core.Models;

namespace Goke.Bank.App.Pages.Account;

public partial class LoginPage : ContentPage
{
    private MauiAuthenticationStateProvider _stateProvider;
    private bool loginFailureHidden = true;

    public LoginPage(MauiAuthenticationStateProvider stateProvider)
	{
        		_stateProvider = stateProvider;
		InitializeComponent();
	}

    private void OnRegisterClicked  (object sender, EventArgs e)
    {

    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var LoginModel = new LoginRequest
        {
            Email = EmailEntry.Text?.Trim() ?? string.Empty,
            Password = PasswordEntry.Text ?? string.Empty,
            RememberMe = false //RememberMeCheckBox.IsChecked
        };

        var result = await _stateProvider.AuthenticateAsync(LoginModel);

        if (!result.Succeeded)
        {
            loginFailureHidden = false;
            return;
        }

        // Navigate to the main page or dashboard after successful login
        await Shell.Current.GoToAsync("//MainPage");
    }
}