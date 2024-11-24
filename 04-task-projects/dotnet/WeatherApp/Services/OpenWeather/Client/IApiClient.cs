using Weather.NET.Models.WeatherModel;
using WeatherApp.Model.OpenWeather;

namespace WeatherApp.Services.OpenWeather.Client;

public interface IApiClient
{
    /// <summary>
    /// Gets the weather information for a specific city.
    /// </summary>
    /// <param name="city">The name of the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the weather information for the city.</returns>
    Task<WeatherModel?> GetWeatherByCity(string city);

    /// <summary>
    /// Gets the forecast weather information for a specific location.
    /// </summary>
    /// <param name="lat">The latitude of the location.</param>
    /// <param name="lon">The longitude of the location.</param>
    /// <param name="maxDays">The maximum number of forecast days to retrieve (default is 1).</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the forecast weather information for the location.</returns>
    Task<ForeCastWeather?> GetForecastWeather(double lat, double lon, int maxDays = 1);

    /// <summary>
    /// Gets the latitude and longitude data for a specific city.
    /// </summary>
    /// <param name="city">The name of the city.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the latitude and longitude data for the city.</returns>
    Task<List<GeoLocation>?> GetLatAndLonDataByCity(string city);
}