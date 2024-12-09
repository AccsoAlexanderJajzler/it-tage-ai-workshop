# Org.OpenAPITools.Api.InternalsApi

All URIs are relative to *https://api.brightsky.dev*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetSources**](InternalsApi.md#getsources) | **GET** /sources | Weather sources (stations) |
| [**GetSynop**](InternalsApi.md#getsynop) | **GET** /synop | Raw SYNOP observations |

<a name="getsources"></a>
# **GetSources**
> GetSources200Response GetSources (decimal? lat = null, decimal? lon = null, List<string> dwdStationId = null, List<string> wmoStationId = null, List<int> sourceId = null, int? maxDist = null)

Weather sources (stations)

Returns a list of all Bright Sky sources matching the given location criteria, ordered by distance.  You must supply both `lat` and `lon` _or_ one of `dwd_station_id`, `wmo_station_id`, or `source_id`. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetSourcesExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.brightsky.dev";
            var apiInstance = new InternalsApi(config);
            var lat = 52.52;  // decimal? | Latitude in decimal degrees. (optional) 
            var lon = 13.4;  // decimal? | Longitude in decimal degrees. (optional) 
            var dwdStationId = new List<string>(); // List<string> | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var wmoStationId = new List<string>(); // List<string> | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var sourceId = new List<int>(); // List<int> | Bright Sky source ID, as retrieved from the [`/sources` endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var maxDist = 10000;  // int? | Maximum distance of record location from the location given by `lat` and `lon`, in meters. Only has an effect when using `lat` and `lon`. (optional)  (default to 50000)

            try
            {
                // Weather sources (stations)
                GetSources200Response result = apiInstance.GetSources(lat, lon, dwdStationId, wmoStationId, sourceId, maxDist);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InternalsApi.GetSources: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSourcesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Weather sources (stations)
    ApiResponse<GetSources200Response> response = apiInstance.GetSourcesWithHttpInfo(lat, lon, dwdStationId, wmoStationId, sourceId, maxDist);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InternalsApi.GetSourcesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lat** | **decimal?** | Latitude in decimal degrees. | [optional]  |
| **lon** | **decimal?** | Longitude in decimal degrees. | [optional]  |
| **dwdStationId** | [**List&lt;string&gt;**](string.md) | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **wmoStationId** | [**List&lt;string&gt;**](string.md) | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **sourceId** | [**List&lt;int&gt;**](int.md) | Bright Sky source ID, as retrieved from the [&#x60;/sources&#x60; endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **maxDist** | **int?** | Maximum distance of record location from the location given by &#x60;lat&#x60; and &#x60;lon&#x60;, in meters. Only has an effect when using &#x60;lat&#x60; and &#x60;lon&#x60;. | [optional] [default to 50000] |

### Return type

[**GetSources200Response**](GetSources200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Hourly weather records/forecasts and meta information on their sources. |  -  |
| **400** | Request has missing or invalid parameters. |  -  |
| **404** | No weather sources match the given location criteria. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getsynop"></a>
# **GetSynop**
> GetSynop200Response GetSynop (DateTime date, DateTime? lastDate = null, List<string> dwdStationId = null, List<string> wmoStationId = null, List<int> sourceId = null, string tz = null, string units = null)

Raw SYNOP observations

Returns a list of ten-minutely SYNOP observations for the time range given by `date` and `last_date`. Note that Bright Sky only stores SYNOP observations from the past 30 hours.  To set the weather station for which to retrieve records, you must supply one of `dwd_station_id`, `wmo_station_id`, or `source_id`. The `/synop` endpoint does not support `lat` and `lon`; use the [`/sources` endpoint](/operations/getSources) if you need to retrieve a SYNOP station ID close to a given location.  SYNOP observations are stored as they were reported, which in particular implies that many parameters are only available at certain timestamps. For example, most stations report `sunshine_60` only on the full hour, and `sunshine_30` only at 30 minutes past the full hour (i.e. also not on the full hour). Check out the [`/current_weather` endpoint](/operations/getCurrentWeather) for an opinionated compilation of recent SYNOP records into a single \"current weather\" record. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetSynopExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.brightsky.dev";
            var apiInstance = new InternalsApi(config);
            var date = 2023-08-07;  // DateTime | Timestamp of first weather record (or forecast) to retrieve, in ISO 8601 format. May contain time and/or UTC offset.
            var lastDate = 2023-08-08;  // DateTime? | Timestamp of last weather record (or forecast) to retrieve, in ISO 8601 format. Will default to `date + 1 day`. (optional) 
            var dwdStationId = new List<string>(); // List<string> | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var wmoStationId = new List<string>(); // List<string> | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var sourceId = new List<int>(); // List<int> | Bright Sky source ID, as retrieved from the [`/sources` endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var tz = Europe/Berlin;  // string | Timezone in which record timestamps will be presented, as <a href=\"https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\">tz database name</a>. Will also be used as timezone when parsing `date` and `last_date`, unless these have explicit UTC offsets. If omitted but `date` has an explicit UTC offset, that offset will be used as timezone. Otherwise will default to UTC. (optional) 
            var units = "dwd";  // string | Physical units in which meteorological parameters will be returned. Set to `si` to use <a href=\"https://en.wikipedia.org/wiki/International_System_of_Units\">SI units</a> (except for precipitation, which is always measured in millimeters). The default `dwd` option uses a set of units that is more common in meteorological applications and civil use: <table>   <tr><td></td><td>DWD</td><td>SI</td></tr>   <tr><td>Cloud cover</td><td>%</td><td>%</td></tr>   <tr><td>Dew point</td><td>°C</td><td>K</td></tr>   <tr><td>Precipitation</td><td>mm</td><td><s>kg / m²</s> <strong>mm</strong></td></tr>   <tr><td>Precipitation probability</td><td>%</td><td>%</td></tr>   <tr><td>Pressure</td><td>hPa</td><td>Pa</td></tr>   <tr><td>Relative humidity</td><td>%</td><td>%</td></tr>   <tr><td>Solar irradiation</td><td>kWh / m²</td><td>J / m²</td></tr>   <tr><td>Sunshine</td><td>min</td><td>s</td></tr>   <tr><td>Temperature</td><td>°C</td><td>K</td></tr>   <tr><td>Visibility</td><td>m</td><td>m</td></tr>   <tr><td>Wind (gust) direction</td><td>°</td><td>°</td></tr>   <tr><td>Wind (gust) speed</td><td>km / h</td><td>m / s</td></tr> </table>  (optional)  (default to dwd)

            try
            {
                // Raw SYNOP observations
                GetSynop200Response result = apiInstance.GetSynop(date, lastDate, dwdStationId, wmoStationId, sourceId, tz, units);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling InternalsApi.GetSynop: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSynopWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Raw SYNOP observations
    ApiResponse<GetSynop200Response> response = apiInstance.GetSynopWithHttpInfo(date, lastDate, dwdStationId, wmoStationId, sourceId, tz, units);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling InternalsApi.GetSynopWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **DateTime** | Timestamp of first weather record (or forecast) to retrieve, in ISO 8601 format. May contain time and/or UTC offset. |  |
| **lastDate** | **DateTime?** | Timestamp of last weather record (or forecast) to retrieve, in ISO 8601 format. Will default to &#x60;date + 1 day&#x60;. | [optional]  |
| **dwdStationId** | [**List&lt;string&gt;**](string.md) | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **wmoStationId** | [**List&lt;string&gt;**](string.md) | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **sourceId** | [**List&lt;int&gt;**](int.md) | Bright Sky source ID, as retrieved from the [&#x60;/sources&#x60; endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **tz** | **string** | Timezone in which record timestamps will be presented, as &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\&quot;&gt;tz database name&lt;/a&gt;. Will also be used as timezone when parsing &#x60;date&#x60; and &#x60;last_date&#x60;, unless these have explicit UTC offsets. If omitted but &#x60;date&#x60; has an explicit UTC offset, that offset will be used as timezone. Otherwise will default to UTC. | [optional]  |
| **units** | **string** | Physical units in which meteorological parameters will be returned. Set to &#x60;si&#x60; to use &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/International_System_of_Units\&quot;&gt;SI units&lt;/a&gt; (except for precipitation, which is always measured in millimeters). The default &#x60;dwd&#x60; option uses a set of units that is more common in meteorological applications and civil use: &lt;table&gt;   &lt;tr&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;DWD&lt;/td&gt;&lt;td&gt;SI&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Cloud cover&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Dew point&lt;/td&gt;&lt;td&gt;°C&lt;/td&gt;&lt;td&gt;K&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Precipitation&lt;/td&gt;&lt;td&gt;mm&lt;/td&gt;&lt;td&gt;&lt;s&gt;kg / m²&lt;/s&gt; &lt;strong&gt;mm&lt;/strong&gt;&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Precipitation probability&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Pressure&lt;/td&gt;&lt;td&gt;hPa&lt;/td&gt;&lt;td&gt;Pa&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Relative humidity&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Solar irradiation&lt;/td&gt;&lt;td&gt;kWh / m²&lt;/td&gt;&lt;td&gt;J / m²&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Sunshine&lt;/td&gt;&lt;td&gt;min&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Temperature&lt;/td&gt;&lt;td&gt;°C&lt;/td&gt;&lt;td&gt;K&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Visibility&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Wind (gust) direction&lt;/td&gt;&lt;td&gt;°&lt;/td&gt;&lt;td&gt;°&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Wind (gust) speed&lt;/td&gt;&lt;td&gt;km / h&lt;/td&gt;&lt;td&gt;m / s&lt;/td&gt;&lt;/tr&gt; &lt;/table&gt;  | [optional] [default to dwd] |

### Return type

[**GetSynop200Response**](GetSynop200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ten-minutely SYNOP records and meta information on the source. |  -  |
| **400** | Request has missing or invalid parameters. |  -  |
| **404** | No weather sources match the given location criteria. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

