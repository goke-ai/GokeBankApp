using Goke.Core.Interfaces;

namespace Goke.Bank.App.Pages;

[Authorize]
public partial class WeatherPage : AuthorizePage
{
	public WeatherPage()
	{
		InitializeComponent();
	}
}