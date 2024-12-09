using System.Net.Http.Headers;
using Service.DWD.Model;

namespace Service.DWD.Client;

internal class InternalClient
{
    private readonly HttpClient _httpClient;
    private readonly TimeSpan _timeout = TimeSpan.FromSeconds(100);

    public InternalClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.brightsky.dev");
    }

    public async Task<GenericResponse> PostContent(string path, Util.Multimap<string, string> queries,
        string? responseContentType = default) => await CallApi(HttpMethod.Post, path, queries, responseContentType);

    public async Task<GenericResponse> GetContent(string path, Util.Multimap<string, string> queries,
        string? responseContentType = default) => await CallApi(HttpMethod.Get, path, queries, responseContentType);


    
    internal async Task<GenericResponse> CallApi(HttpMethod httpMethod, string url,
        Util.Multimap<string, string> queries, string responseContentType = "application/json")
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentNullException(nameof(url));
        }

        if (queries is null)
        {
            throw new ArgumentNullException(nameof(queries));
        }

        try
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(responseContentType));

            var queryUri = new UriBuilder(url);
            queryUri.Query = string.Join("&",
                queries.Select(q => $"{Uri.EscapeDataString(q.Key)}={Uri.EscapeDataString(q.Value.ToString())}"));

            var request = new HttpRequestMessage(httpMethod, queryUri.Uri);

            var response = await _httpClient.SendAsync(request);
            string rawContent = await response.Content.ReadAsStringAsync();

            return new GenericResponse()
            {
                StatusCode = response.StatusCode,
                Content = rawContent
            };
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
}