using Goke.Bank.App.Controls;
using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages;

public partial class WeatherPage : ScrollViewPage
{
	public WeatherPage(WeatherPageModel vModel)
	{
		InitializeComponent();
		BindingContext = vModel;
	}
}