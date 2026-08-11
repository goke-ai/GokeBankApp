using Goke.Bank.App.Controls;
using Goke.Core.Authorization;

namespace Goke.Bank.App.Pages.Admin;

[Authorize(Roles = "Administrators")]
public partial class AdminPage : AuthorizePage
{
	public AdminPage()
	{
		InitializeComponent();
	}
}