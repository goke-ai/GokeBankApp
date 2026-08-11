using Goke.Bank.App.Controls;
using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages;

public partial class WeatherPage2 : AuthorizePage
{
	public WeatherPage2(WeatherPageModel vModel)
	{
		InitializeComponent();
		BindingContext = vModel;
	}
}