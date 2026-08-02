using CommunityToolkit.Mvvm.Input;
using Goke.Bank.App.Models;

namespace Goke.Bank.App.PageModels;

public interface IProjectTaskPageModel
{
	IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
	bool IsBusy { get; }
}