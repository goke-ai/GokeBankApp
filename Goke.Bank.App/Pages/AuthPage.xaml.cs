using Goke.Bank.App.Controls;
using Goke.Core.Authorization;

namespace Goke.Bank.App.Pages;

[Authorize]
public partial class AuthPage : ScrollViewPage
{
	public AuthPage()
	{
		InitializeComponent();
	}
}