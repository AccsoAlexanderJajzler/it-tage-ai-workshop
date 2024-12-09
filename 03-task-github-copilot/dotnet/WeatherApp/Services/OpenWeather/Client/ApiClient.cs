using Newtonsoft.Json;
using Weather.NET.Models.WeatherModel;
using WeatherApp.Config;
using WeatherApp.Model.OpenWeather;

namespace WeatherApp.Services.OpenWeather.Client;
public class ApiClient: IApiClient
{
    private InternalClient _client;
    private OpenWeatherSettings _openApiWeatherSettings;

    public ApiClient(IHttpClientFactory clientFactory, IConfiguration config)
    {
        if (clientFactory is null)
        {
            throw new NullReferenceException(nameof(clientFactory));
        }

        if (config is null)
        {
            throw new NullReferenceException(nameof(config));
        }
       
        LoadApiKey(config);
        _openApiWeatherSettings = config.GetSection("OpenWeatherSettings").Get<OpenWeatherSettings>();
        if (_openApiWeatherSettings is null)
        {
            throw new NullReferenceException(nameof(_openApiWeatherSettings));
        }
        
        _client = new InternalClient(clientFactory, _openApiWeatherSettings.BaseUrl); 
        
       _client = new InternalClient(clientFactory, _openApiWeatherSettings.BaseUrl); 
    }

    private void LoadApiKey(IConfiguration config)
    {
        try
        {
            _openApiWeatherSettings = config.GetSection("OpenWeatherSettings").Get<OpenWeatherSettings>();

            if (_openApiWeatherSettings is null)
            {
                throw new NullReferenceException(nameof(_openApiWeatherSettings));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<WeatherModel?> GetWeatherByCity(string city)
    {
        if(string.IsNullOrEmpty(city))
        {
            return default;
        }
        
        var urlPath = $"/data/{_openApiWeatherSettings.Version}/weather";
        var query = new Dictionary<string, string>
        {
            { "q", city },
            { "appid", _openApiWeatherSettings.ApiKey }
        };
        try
        {
            return await _client.GetContent<Weather.NET.Models.WeatherModel.WeatherModel>(urlPath, query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
    
    public async Task<ForeCastWeather?> GetForecastWeather(double lat, double lon, int maxDays = 1)
    {
        var urlPath = $"/data/{_openApiWeatherSettings.Version}/forecast/daily";
        var query = new Dictionary<string, string>
        {
            { "lat", lat.ToString() },
            { "lon", lon.ToString() },
            { "cnt", maxDays.ToString() },
            { "units", Weather.NET.Enums.Measurement.Metric.ToString() },
            { "appid", _openApiWeatherSettings.ApiKey }
        };
        
        try
        {
            return await _client.GetContent<ForeCastWeather>(urlPath, query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
   
    public async Task<List<GeoLocation>?> GetLatAndLonDataByCity(string city)
    {
        if(string.IsNullOrEmpty(city))
        {
            return default;
        }
        
        var urlPath = $"/geo/{_openApiWeatherSettings.GeoVersion}/direct";
        var query = new Dictionary<string, string>
        {
            { "q", city },
            { "appid", _openApiWeatherSettings.ApiKey }
        };

        try
        {
            return await _client.GetContent<List<GeoLocation>>(urlPath, query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
}