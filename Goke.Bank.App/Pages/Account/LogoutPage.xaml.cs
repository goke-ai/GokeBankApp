using Goke.Bank.App.Controls;
using Goke.Bank.App.PageModels;
using Goke.Core.Authorization;

namespace Goke.Bank.App.Pages.Account;

[Authorize]
public partial class LogoutPage : AuthorizePage
{

    public LogoutPage(LogoutPageModel model)
	{
		InitializeComponent();
        BindingContext = model;

    }


}