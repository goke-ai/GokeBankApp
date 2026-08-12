namespace Goke.Bank.App.Services;

public static class ServiceHelper
{
    public static T GetService<T>() =>
        IPlatformApplication.Current.Services.GetService<T>();
}
