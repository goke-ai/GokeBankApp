using Goke.Bank.App.Services;
using Goke.Core.Interfaces;

namespace Goke.Bank.App.Controls;

public partial class FormFactorView : ContentView
{
	public FormFactorView()
	{
		InitializeComponent();

        var viewModel = new FormFactorViewModel(ServiceHelper.GetService<IFormFactor>());
        BindingContext = viewModel;
	}
}