namespace Goke.Bank.App;

public static class ServiceHelper
{
    public static T GetService<T>() =>
        IPlatformApplication.Current.Services.GetService<T>();
}
