using Goke.Core.Models;

namespace Goke.Bank.WebServer.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetAllWeatherForecasts();
    }
}