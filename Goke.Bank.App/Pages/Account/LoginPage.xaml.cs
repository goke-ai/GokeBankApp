using Goke.Bank.App.Controls;
using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages.Account;

public partial class LoginPage : ScrollViewPage
{

    public LoginPage(LoginPageModel model)
	{
		InitializeComponent();
        BindingContext = model;

    }


}