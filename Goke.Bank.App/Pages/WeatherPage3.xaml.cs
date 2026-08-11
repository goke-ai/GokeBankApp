using Goke.Bank.App.Controls;
using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages;

//[Authorize]
public partial class WeatherPage3 : ScrollViewContentPage
{
	public WeatherPage3(WeatherPageModel vModel)
	{
		InitializeComponent();
		BindingContext = vModel;
	}
}