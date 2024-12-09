using Newtonsoft.Json;
using Weather.NET.Models.WeatherModel;
using WeatherApp.Config;
using WeatherApp.Model.OpenWeather;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherApp.Services;

// TODO 🥉: Generate class documentation
public class SimpleOpenWeatherApiService
{
    private HttpClient _client;
    private OpenWeatherSettings _openApiWeatherSettings;
    
    //Handle null exceptions
    public SimpleOpenWeatherApiService(IHttpClientFactory clientFactory, IConfiguration config)
    {
        if (clientFactory is null)
        {
            throw new NullReferenceException(nameof(clientFactory));
        }

        if (config is null)
        {
            throw new NullReferenceException(nameof(config));
        }
        
        _client = clientFactory.CreateClient();
        _openApiWeatherSettings = config.GetSection("OpenWeatherSettings").Get<OpenWeatherSettings>();
        
        if (_openApiWeatherSettings is null)
        {
            throw new NullReferenceException(nameof(_openApiWeatherSettings));
        }
        
        _client.BaseAddress = new Uri(_openApiWeatherSettings.BaseUrl);
    }
   
    public async Task<WeatherModel?> GetWeatherByCity(string city)
    {
        if(string.IsNullOrEmpty(city))
        {
            return default;
        }
        
        var result = await _client.GetAsync($"/data/{_openApiWeatherSettings.Version}/weather?q={city}&appid={_openApiWeatherSettings.ApiKey}");
        try
        {
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Weather.NET.Models.WeatherModel.WeatherModel>(content);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
    
    public async Task<ForeCastWeather?> GetForecastWeather(double lat, double lon, int maxDays = 1)
    {
        var result = await _client.GetAsync($"/data/{_openApiWeatherSettings.Version}/forecast/daily?lat={lat}&lon={lon}&cnt={maxDays}&units={Weather.NET.Enums.Measurement.Standard}&appid={_openApiWeatherSettings.ApiKey}");
        try
        {
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ForeCastWeather>(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
   
    public async Task<List<GeoLocation>?> GetGeoLocation(string city)
    {
        if(string.IsNullOrEmpty(city))
        {
            return default;
        }
        
        var result = await _client.GetAsync($"/geo/{_openApiWeatherSettings.GeoVersion}/direct?q={city}&appid={_openApiWeatherSettings.ApiKey}");
        try
        {
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<GeoLocation>>(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
}