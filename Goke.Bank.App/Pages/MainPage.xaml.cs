using Goke.Bank.App.Models;
using Goke.Bank.App.PageModels;

namespace Goke.Bank.App.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}