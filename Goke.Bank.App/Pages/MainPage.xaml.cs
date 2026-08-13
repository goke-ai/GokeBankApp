using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	
}
