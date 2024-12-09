
using System.Net;
using System.Text.Json;
using Service.DWD.Model;
using Service.DWD.Util;

namespace Service.DWD.Client;
public class ApiClient : IApiClient
{
    private readonly InternalClient _client;

    public ApiClient(IHttpClientFactory httpClientFactory)
    {
        if(httpClientFactory is null){
         throw new ArgumentNullException(nameof(httpClientFactory));
        }

        _client = new InternalClient(httpClientFactory.CreateClient());
    }

    public async Task<GenericResult> GetAlerts(decimal? lat = null, decimal? lon = null, int? warnCellId = null, string? tz = null)
    {
        Util.Multimap<string, string> queries = new Util.Multimap<string, string>();
        RequestOptions localVarRequestOptions = new RequestOptions();

        if (lat != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lat", lat));
        }
        if (lon != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lon", lon));
        }
        if (warnCellId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "warn_cell_id", warnCellId));
        }
        if (tz != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "tz", tz));
        }

        // make the HTTP request
        var response = await _client.GetContent("/alerts", queries);
        CheckContent(response);
        return ProcessResponse<GetAlerts200Response, GetAlerts400Response>(response);

    }

    public async Task<GenericResult> GetCurrentWeather(decimal? lat = null, decimal? lon = null, List<string> dwdStationId = null, List<string> wmoStationId = null, List<int> sourceId = null, int? maxDist = null, string tz = null, string units = null)
    {
        Util.Multimap<string, string> queries = new Util.Multimap<string, string>();
        RequestOptions localVarRequestOptions = new RequestOptions();

        if (lat != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lat", lat));
        }
        if (lon != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lon", lon));
        }

        if (dwdStationId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("csv", "dwd_station_id", dwdStationId));
        }
        if (wmoStationId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("csv", "wmo_station_id", wmoStationId));
        }
        if (sourceId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("csv", "source_id", sourceId));
        }
        if (maxDist != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "max_dist", maxDist));
        }
        if (tz != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "tz", tz));
        }
        if (units != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "units", units));
        }

        var response = await _client.GetContent("/current_weather", queries);
        CheckContent(response);
        return ProcessResponse<GetCurrentWeather200Response, GetCurrentWeather400Response, GetCurrentWeather404Response>(response);
    }

    public async Task<GenericResult> GetRadar(DateTime? date = null, DateTime? lastDate = null, List<int> bbox = null, decimal? lat = null, decimal? lon = null, int? distance = null, string tz = null, string format = null)
    {

        Util.Multimap<string, string> queries = new Util.Multimap<string, string>();

        if (date != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "date", date));
        }
        if (lastDate != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "last_date", lastDate));
        }
        if (bbox != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("multi", "bbox", bbox));
        }
        if (lat != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lat", lat));
        }
        if (lon != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lon", lon));
        }
        if (distance != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "distance", distance));
        }
        if (tz != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "tz", tz));
        }
        if (format != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "format", format));
        }

        // localVarRequestOptions.Operation = "DefaultApi.GetRadar";
        // localVarRequestOptions.OperationIndex = operationIndex;


        var response = await _client.GetContent("/radar", queries);
        CheckContent(response);
        return ProcessResponse<GetRadar200Response, GetRadar400Response, GetRadar404Response>(response);
    }

    public async Task<GenericResult> GetWeather(DateTime date, DateTime? lastDate = null, decimal? lat = null, decimal? lon = null, List<string> dwdStationId = null, List<string> wmoStationId = null, List<int> sourceId = null, int? maxDist = null, string tz = null, string units = null)
    {

        Util.Multimap<string, string> queries = new Util.Multimap<string, string>();

        queries.Add(ClientUtils.ParameterToMultiMap("", "date", date));
        if (lastDate != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "last_date", lastDate));
        }
        if (lat != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lat", lat));
        }
        if (lon != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "lon", lon));
        }
        if (dwdStationId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("csv", "dwd_station_id", dwdStationId));
        }
        if (wmoStationId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("csv", "wmo_station_id", wmoStationId));
        }
        if (sourceId != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("csv", "source_id", sourceId));
        }
        if (maxDist != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "max_dist", maxDist));
        }
        if (tz != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "tz", tz));
        }
        if (units != null)
        {
            queries.Add(ClientUtils.ParameterToMultiMap("", "units", units));
        }

        // localVarRequestOptions.Operation = "DefaultApi.GetWeather";
        // localVarRequestOptions.OperationIndex = operationIndex;


        // make the HTTP request
        // var localVarResponse = await AsynchronousClient.GetAsync<GetWeather200Response>("/weather", localVarRequestOptions, Configuration, cancellationToken).ConfigureAwait(false);
        var response = await _client.GetContent("/weather", queries);
        CheckContent(response);
        return ProcessResponse<GetWeather200Response>(response);
    }

    private void CheckContent(GenericResponse content)
    {
        if (content is null)
        {
            throw new ArgumentNullException(nameof(content));
        }
    }

    private GenericResult ProcessResponse<TOut>(GenericResponse genericResponse)
    {
        var defaultCheck = ProcessDefaultHttpStatusCode<TOut>(genericResponse);

        if (defaultCheck is null)
        {
            return CreateResponse("No Content", genericResponse.StatusCode);
        }

        return defaultCheck;
    }

    private GenericResult ProcessResponse<TOut, TBad>(GenericResponse genericResponse)
    {
        var defaultCheck = ProcessDefaultHttpStatusCode<TOut, TBad>(genericResponse);

        if (defaultCheck is null)
        {
            return CreateResponse("No Content", genericResponse.StatusCode);
        }

        return defaultCheck;
    }

    private GenericResult ProcessResponse<TOut, TBad, TNotFound>(GenericResponse genericResponse)
    {
        if (genericResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return CreateResponse<TNotFound>(genericResponse.Content, genericResponse.StatusCode);
        }

        var defaultCheck = ProcessDefaultHttpStatusCode<TOut, TBad>(genericResponse);

        if (defaultCheck is null)
        {
            return CreateResponse("No Content", genericResponse.StatusCode);
        }

        return defaultCheck;
    }

    private GenericResult? ProcessDefaultHttpStatusCode<TOut, TBad>(GenericResponse genericResponse)
    {
        var firstCheck = ProcessDefaultHttpStatusCode<TOut>(genericResponse);

        if (firstCheck is not null)
        {
            return firstCheck;
        }

        if (genericResponse.StatusCode == HttpStatusCode.BadRequest)
        {
            return CreateResponse<TBad>(genericResponse.Content, genericResponse.StatusCode);
        }

        return default;
    }

    private GenericResult? ProcessDefaultHttpStatusCode<TOut>(GenericResponse genericResponse)
    {
        if (genericResponse.StatusCode == HttpStatusCode.OK)
        {
            return CreateResponse<TOut>(genericResponse.Content, genericResponse.StatusCode);
        }

        if (genericResponse.StatusCode == HttpStatusCode.Unauthorized)
        {
            return CreateResponse("Not authorized", genericResponse.StatusCode);
        }

        return default;
    }

    private TOut? ConvertContent<TOut>(string content)
    {

        if (string.IsNullOrEmpty(content))
        {
            return default;
        }

        try
        {
            return JsonSerializer.Deserialize<TOut>(content);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    private GenericResult CreateResponse<TOut>(string content, HttpStatusCode statusCode)
    {
        return new GenericResult()
        {
            Content = ConvertContent<TOut>(content),
            StatusCode = statusCode
        };
    }

    private GenericResult CreateResponse(string content, HttpStatusCode statusCode)
    {
        return new GenericResult()
        {
            Content = content,
            StatusCode = statusCode
        };
    }
}
