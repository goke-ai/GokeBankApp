using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Goke.Bank.App.Services;
using Goke.Core.Interfaces;

namespace Goke.Bank.App.PageModels;

public partial class LogoutPageModel : BasePageModel
{
    private readonly IAuthenticationService authService;
    private readonly ModalErrorHandler errorHandler;

    public LogoutPageModel(IAuthenticationService authService, ModalErrorHandler errorHandler) : base(errorHandler)
    {
        this.authService = authService;
        this.errorHandler = errorHandler;
    }

    protected override async Task OnInitDataAsync()
    {
        await base.OnInitDataAsync();
        await LogoutAsync();
    }

    private async Task LogoutAsync()
    {
        try
        {
            authService.Logout();

            if (Shell.Current is AppShell shell)
            {
                await shell.RefreshMenuAsync();
            }

            await Shell.Current.GoToAsync("//MainPage", true);
        }
        catch (Exception e)
        {
            errorHandler.HandleError(e);
        }
    }
}
