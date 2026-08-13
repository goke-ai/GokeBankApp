using Goke.Bank.App.Controls;
using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages;

public partial class CounterPage : AuthorizePage
{
	public CounterPage(CounterPageModel vModel)
	{
		InitializeComponent();
		BindingContext = vModel;
	}
}