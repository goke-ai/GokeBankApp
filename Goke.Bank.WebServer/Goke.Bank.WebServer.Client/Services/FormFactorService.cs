using Goke.Core.Interfaces;

namespace Goke.Bank.WebServer.Client.Services
{
    public class FormFactorService : IFormFactor
    {
        public string GetFormFactor()
        {
            return "WebAssembly";
        }

        public string GetPlatform()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
