using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WeatherApp.Services.OpenWeather.Client;
public class InternalClient
{
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(100);
    private readonly HttpClient _httpClient;
    private readonly string _responseContentType = "application/json";

    public InternalClient(IHttpClientFactory clientFactory, string baseUrl)
    {
        _httpClient = clientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<TOut> GetContent<TOut>(string path, Dictionary<string, string> queries) => await CallApi<TOut>(HttpMethod.Get, path, queries);
    
    // TODO 🥉: Generate method documentation that describes the purpose of this method and potential pitfalls
    internal async Task<TOut> CallApi<TOut>(HttpMethod httpMethod, string pathUrl, Dictionary<string, string> queries)
    {
        if (string.IsNullOrEmpty(pathUrl))
        {
            throw new ArgumentNullException(nameof(pathUrl));
        }

        if (queries is null)
        {
            throw new ArgumentNullException(nameof(queries));
        }

        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_responseContentType));

            var queryUri = new UriBuilder(pathUrl);
            queryUri.Query = string.Join("&",   queries.Select(q => $"{Uri.EscapeDataString(q.Key)}={Uri.EscapeDataString(q.Value.ToString())}"));

            var request = new HttpRequestMessage(httpMethod, queryUri.Uri);

            var cts = new CancellationTokenSource();
            cts.CancelAfter(_timeout);
            var response = await _httpClient.SendAsync(request, cts.Token);
            string rawContent = await response.Content.ReadAsStringAsync();
            
           return ParseContent<TOut>(rawContent); 
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    private TOut? ParseContent<TOut>(string content)
    {
        if (string.IsNullOrEmpty(content)) return default;
        
        try
        {
            return JsonConvert.DeserializeObject<TOut>(content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }
}