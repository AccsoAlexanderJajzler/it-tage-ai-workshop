# Org.OpenAPITools.Api.DefaultApi

All URIs are relative to *https://api.brightsky.dev*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAlerts**](DefaultApi.md#getalerts) | **GET** /alerts | Alerts |
| [**GetCurrentWeather**](DefaultApi.md#getcurrentweather) | **GET** /current_weather | Current weather |
| [**GetRadar**](DefaultApi.md#getradar) | **GET** /radar | Radar |
| [**GetWeather**](DefaultApi.md#getweather) | **GET** /weather | Hourly weather (including forecasts) |

<a name="getalerts"></a>
# **GetAlerts**
> GetAlerts200Response GetAlerts (decimal? lat = null, decimal? lon = null, int? warnCellId = null, string tz = null)

Alerts

Returns a list of weather alerts for the given location, or all weather alerts if no location given.  If you supply either `warn_cell_id` or both `lat` and `lon`, Bright Sky will return additional information on that cell in the `location` field. Warn cell IDs are municipality (_Gemeinde_) cell IDs.  ### Notes  * The DWD divides Germany's area into roughly 11,000 \"cells\" based on municipalities (_Gemeinden_), and issues warnings for each of these cells. Most warnings apply to many cells. * Bright Sky will supply information on the cell that a given lat/lon belongs to in the `location` field. * There is also a set of roughly 400 cells based on districts (_Landkreise_) that is not supported by Bright Sky. * The complete list of cells can be found on the DWD GeoServer (see below).  ### Additional resources  * [Live demo of a simple interactive alerts map](https://brightsky.dev/demo/alerts/) * [Source for alerts map demo](https://github.com/jdemaeyer/brightsky/blob/master/docs/demo/alerts/index.html) * [Map view of all current alerts by the DWD](https://www.dwd.de/DE/wetter/warnungen_gemeinden/warnWetter_node.html) * [List of municipality cells](https://maps.dwd.de/geoserver/wfs?SERVICE=WFS&VERSION=2.0.0&REQUEST=GetFeature&TYPENAMES=Warngebiete_Gemeinden&OUTPUTFORMAT=json) * [List of district cells (*not used by Bright Sky!*)](https://maps.dwd.de/geoserver/wfs?SERVICE=WFS&VERSION=2.0.0&REQUEST=GetFeature&TYPENAMES=Warngebiete_Kreise&OUTPUTFORMAT=json) * [Raw data on the Open Data Server](https://opendata.dwd.de/weather/alerts/cap/COMMUNEUNION_DWD_STAT/) * [DWD Documentation on alert fields and their allowed contents (English)](https://www.dwd.de/DE/leistungen/opendata/help/warnungen/cap_dwd_profile_en_pdf_2_1_13.pdf?__blob=publicationFile&v=3) * [DWD Documentation on alert fields and their allowed contents (German)](https://www.dwd.de/DE/leistungen/opendata/help/warnungen/cap_dwd_profile_de_pdf_2_1_13.pdf?__blob=publicationFile&v=3) 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetAlertsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.brightsky.dev";
            var apiInstance = new DefaultApi(config);
            var lat = 52.52;  // decimal? | Latitude in decimal degrees. (optional) 
            var lon = 13.4;  // decimal? | Longitude in decimal degrees. (optional) 
            var warnCellId = 803159016;  // int? | Municipality warn cell ID. (optional) 
            var tz = Europe/Berlin;  // string | Timezone in which timestamps will be presented, as <a href=\"https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\">tz database name</a>. (optional)  (default to "Etc/UTC")

            try
            {
                // Alerts
                GetAlerts200Response result = apiInstance.GetAlerts(lat, lon, warnCellId, tz);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.GetAlerts: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAlertsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Alerts
    ApiResponse<GetAlerts200Response> response = apiInstance.GetAlertsWithHttpInfo(lat, lon, warnCellId, tz);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.GetAlertsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lat** | **decimal?** | Latitude in decimal degrees. | [optional]  |
| **lon** | **decimal?** | Longitude in decimal degrees. | [optional]  |
| **warnCellId** | **int?** | Municipality warn cell ID. | [optional]  |
| **tz** | **string** | Timezone in which timestamps will be presented, as &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\&quot;&gt;tz database name&lt;/a&gt;. | [optional] [default to &quot;Etc/UTC&quot;] |

### Return type

[**GetAlerts200Response**](GetAlerts200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List of weather alerts for the given location. |  -  |
| **400** | Request has missing or invalid parameters. |  -  |
| **404** | Given location is not covered by the DWD. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getcurrentweather"></a>
# **GetCurrentWeather**
> GetCurrentWeather200Response GetCurrentWeather (decimal? lat = null, decimal? lon = null, List<string> dwdStationId = null, List<string> wmoStationId = null, List<int> sourceId = null, int? maxDist = null, string tz = null, string units = null)

Current weather

Returns current weather for a given location.  To set the location for which to retrieve weather, you must supply both `lat` and `lon` _or_ one of `dwd_station_id`, `wmo_station_id`, or `source_id`.  This endpoint is different from the other weather endpoints in that it does not directly correspond to any of the data available from the DWD Open Data server. Instead, it is a best-effort solution to reflect current weather conditions by compiling [SYNOP observations](/operations/getSynop) from the past one and a half hours. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetCurrentWeatherExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.brightsky.dev";
            var apiInstance = new DefaultApi(config);
            var lat = 52.52;  // decimal? | Latitude in decimal degrees. (optional) 
            var lon = 13.4;  // decimal? | Longitude in decimal degrees. (optional) 
            var dwdStationId = new List<string>(); // List<string> | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var wmoStationId = new List<string>(); // List<string> | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var sourceId = new List<int>(); // List<int> | Bright Sky source ID, as retrieved from the [`/sources` endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var maxDist = 10000;  // int? | Maximum distance of record location from the location given by `lat` and `lon`, in meters. Only has an effect when using `lat` and `lon`. (optional)  (default to 50000)
            var tz = Europe/Berlin;  // string | Timezone in which record timestamps will be presented, as <a href=\"https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\">tz database name</a>. Will also be used as timezone when parsing `date` and `last_date`, unless these have explicit UTC offsets. If omitted but `date` has an explicit UTC offset, that offset will be used as timezone. Otherwise will default to UTC. (optional) 
            var units = "dwd";  // string | Physical units in which meteorological parameters will be returned. Set to `si` to use <a href=\"https://en.wikipedia.org/wiki/International_System_of_Units\">SI units</a> (except for precipitation, which is always measured in millimeters). The default `dwd` option uses a set of units that is more common in meteorological applications and civil use: <table>   <tr><td></td><td>DWD</td><td>SI</td></tr>   <tr><td>Cloud cover</td><td>%</td><td>%</td></tr>   <tr><td>Dew point</td><td>°C</td><td>K</td></tr>   <tr><td>Precipitation</td><td>mm</td><td><s>kg / m²</s> <strong>mm</strong></td></tr>   <tr><td>Precipitation probability</td><td>%</td><td>%</td></tr>   <tr><td>Pressure</td><td>hPa</td><td>Pa</td></tr>   <tr><td>Relative humidity</td><td>%</td><td>%</td></tr>   <tr><td>Solar irradiation</td><td>kWh / m²</td><td>J / m²</td></tr>   <tr><td>Sunshine</td><td>min</td><td>s</td></tr>   <tr><td>Temperature</td><td>°C</td><td>K</td></tr>   <tr><td>Visibility</td><td>m</td><td>m</td></tr>   <tr><td>Wind (gust) direction</td><td>°</td><td>°</td></tr>   <tr><td>Wind (gust) speed</td><td>km / h</td><td>m / s</td></tr> </table>  (optional)  (default to dwd)

            try
            {
                // Current weather
                GetCurrentWeather200Response result = apiInstance.GetCurrentWeather(lat, lon, dwdStationId, wmoStationId, sourceId, maxDist, tz, units);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.GetCurrentWeather: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCurrentWeatherWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Current weather
    ApiResponse<GetCurrentWeather200Response> response = apiInstance.GetCurrentWeatherWithHttpInfo(lat, lon, dwdStationId, wmoStationId, sourceId, maxDist, tz, units);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.GetCurrentWeatherWithHttpInfo: " + e.Message);
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
| **tz** | **string** | Timezone in which record timestamps will be presented, as &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\&quot;&gt;tz database name&lt;/a&gt;. Will also be used as timezone when parsing &#x60;date&#x60; and &#x60;last_date&#x60;, unless these have explicit UTC offsets. If omitted but &#x60;date&#x60; has an explicit UTC offset, that offset will be used as timezone. Otherwise will default to UTC. | [optional]  |
| **units** | **string** | Physical units in which meteorological parameters will be returned. Set to &#x60;si&#x60; to use &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/International_System_of_Units\&quot;&gt;SI units&lt;/a&gt; (except for precipitation, which is always measured in millimeters). The default &#x60;dwd&#x60; option uses a set of units that is more common in meteorological applications and civil use: &lt;table&gt;   &lt;tr&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;DWD&lt;/td&gt;&lt;td&gt;SI&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Cloud cover&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Dew point&lt;/td&gt;&lt;td&gt;°C&lt;/td&gt;&lt;td&gt;K&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Precipitation&lt;/td&gt;&lt;td&gt;mm&lt;/td&gt;&lt;td&gt;&lt;s&gt;kg / m²&lt;/s&gt; &lt;strong&gt;mm&lt;/strong&gt;&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Precipitation probability&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Pressure&lt;/td&gt;&lt;td&gt;hPa&lt;/td&gt;&lt;td&gt;Pa&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Relative humidity&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Solar irradiation&lt;/td&gt;&lt;td&gt;kWh / m²&lt;/td&gt;&lt;td&gt;J / m²&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Sunshine&lt;/td&gt;&lt;td&gt;min&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Temperature&lt;/td&gt;&lt;td&gt;°C&lt;/td&gt;&lt;td&gt;K&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Visibility&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Wind (gust) direction&lt;/td&gt;&lt;td&gt;°&lt;/td&gt;&lt;td&gt;°&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Wind (gust) speed&lt;/td&gt;&lt;td&gt;km / h&lt;/td&gt;&lt;td&gt;m / s&lt;/td&gt;&lt;/tr&gt; &lt;/table&gt;  | [optional] [default to dwd] |

### Return type

[**GetCurrentWeather200Response**](GetCurrentWeather200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Current weather and meta information on its sources. |  -  |
| **400** | Request has missing or invalid parameters. |  -  |
| **404** | No weather sources match the given location criteria. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getradar"></a>
# **GetRadar**
> GetRadar200Response GetRadar (DateTime? date = null, DateTime? lastDate = null, List<int> bbox = null, decimal? lat = null, decimal? lon = null, int? distance = null, string tz = null, string format = null)

Radar

Returns radar rainfall data with 1 km spatial and 5 minute temporal resolution, including a forecast for the next two hours.  Radar data is recorded on a 1200 km (North-South) x 1100 km (East-West) grid, with each pixel representing 1 km². **That's quite a lot of data, so use `lat`/`lon` or `bbox` whenever you can (see below).** Past radar records are kept for six hours.  Bright Sky can return the data in a few formats. Use the default `compressed` format if possible – this'll get you the fastest response times by far and reduce load on the server. If you have a small-ish bounding box (e.g. 250 x 250 pixels), using the `plain` format should be fine.  ### Quickstart  This request will get you radar data near Münster, reaching 200 km to the East/West/North/South, as a two-dimensional grid of integers:  [`https://api.brightsky.dev/radar?lat=52&lon=7.6&format=plain`](https://api.brightsky.dev/radar?lat=52&lon=7.6&format=plain)  ### Content  * The grid is a polar stereographic projection of Germany and the regions bordering it. This is different from the mercator projection used for most consumer-facing maps like OpenStreetMap or Google Maps, and overlaying the radar data onto such a map without conversion (reprojection) will be inaccurate! Check out our [radar demo](https://brightsky.dev/demo/radar/) for an example of correctly reprojecting the radar data using OpenLayers. Alternatively, take a look at the `dwd:RV-Produkt` layer on the [DWD's open GeoServer](https://maps.dwd.de/geoserver/web/wicket/bookmarkable/org.geoserver.web.demo.MapPreviewPage) for ready-made tiles you can overlay onto a map. * The [proj-string](https://proj.org/en/9.2/usage/quickstart.html) for the grid projection is `+proj=stere +lat_0=90 +lat_ts=60 +lon_0=10 +a=6378137 +b=6356752.3142451802 +no_defs +x_0=543196.83521776402 +y_0=3622588.8619310018`. The radar pixels range from `-500` (left) to `1099500` (right) on the x-axis, and from `500` (top) to `-1199500` (bottom) on the y-axis, each radar pixel a size of `1000x1000` (1 km²). * The DWD data does not cover the whole grid! Many areas near the edges will always be `0`. * Values represent 0.01 mm / 5 min. I.e., if a pixel has a value of `45`, then 0.45 mm of precipitation fell in the corresponding square kilometer in the past five minutes. * The four corners of the grid are as follows:   * Northwest: Latitude `55.86208711`, Longitude `1.463301510`   * Northeast: Latitude `55.84543856`, Longitude `18.73161645`   * Southeast: Latitude `45.68460578`, Longitude `16.58086935`   * Southwest: Latitude `45.69642538`, Longitude `3.566994635`  You can find details and more information in the [DWD's `RV product info` (German only)](https://www.dwd.de/DE/leistungen/radarprodukte/formatbeschreibung_rv.pdf?__blob=publicationFile&v=3). Below is an example visualization of the rainfall radar data taken from this document, using the correct projection and showing the radar coverage:  ![image](https://github.com/jdemaeyer/brightsky/assets/10531844/09f9bb5f-088a-417e-8a0c-ea5a20fe0969)  ### Code examples  > The radar data is quite big (naively unpacking the default 25-frames response into Python integer arrays will eat roughly 125 MB of memory), so use `bbox` whenever you can.  #### `compressed` format  With Javascript using [`pako`](https://github.com/nodeca/pako):  ```js fetch(   'https://api.brightsky.dev/radar' ).then((resp) => resp.json() ).then((respData) => {   const raw = respData.radar[0].precipitation_5;   const compressed = Uint8Array.from(atob(raw), c => c.charCodeAt(0));   const rawBytes = pako.inflate(compressed).buffer;   const precipitation = new Uint16Array(rawBytes); }); ```  With Python using `numpy`:  ```python import base64 import zlib  import numpy as np import requests  resp = requests.get('https://api.brightsky.dev/radar') raw = resp.json()['radar'][0]['precipitation_5'] raw_bytes = zlib.decompress(base64.b64decode(raw))  data = np.frombuffer(     raw_bytes,     dtype='i2', ).reshape(     # Adjust `1200` and `1100` to the height/width of your bbox     (1200, 1100), ) ```  With Python using the standard library's `array`: ```python import array  # [... load raw_bytes as above ...]  data = array.array('H') data.frombytes(raw_bytes) data = [     # Adjust `1200` and `1100` to the height/width of your bbox     data[row*1100:(row+1)*1100]     for row in range(1200) ] ```  Simple plot using `matplotlib`: ```python import matplotlib.pyplot as plt  # [... load data as above ...]  plt.imshow(data, vmax=50) plt.show() ```  #### `bytes` format  Same as for `compressed`, but add `?format=bytes` to the URL and remove the call to `zlib.decompress`, using just `raw_bytes = base64.b64decode(raw)` instead.  #### `plain` format  This is obviously a lot simpler than the `compressed` format. It is, however, also a lot slower. Nonetheless, if you have a small-ish `bbox` the performance difference becomes manageable, so just using the `plain` format and not having to deal with unpacking logic can be a good option in this case.  With Python: ```python import requests  resp = requests.get('https://api.brightsky.dev/radar?format=plain') data = resp.json()['radar'][0]['precipitation_5'] ```  ### Additional resources  * [Source for our radar demo, including reprojecton via OpenLayers](https://github.com/jdemaeyer/brightsky/blob/master/docs/demo/radar/index.html) * [Raw data on the Open Data Server](https://opendata.dwd.de/weather/radar/composite/rv/) * [Details on the `RV` product (German)](https://www.dwd.de/DE/leistungen/radarprodukte/formatbeschreibung_rv.pdf?__blob=publicationFile&v=3) * [Visualization of current rainfall radar](https://www.dwd.de/DE/leistungen/radarbild_film/radarbild_film.html) * [General info on DWD radar products (German)](https://www.dwd.de/DE/leistungen/radarprodukte/radarprodukte.html) * [Radar status (German)](https://www.dwd.de/DE/leistungen/radarniederschlag/rn_info/home_freie_radarstatus_kartendaten.html?nn=16102) * [DWD notifications for radar products (German)](https://www.dwd.de/DE/leistungen/radolan/radolan_info/radolan_informationen.html?nn=16102) 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetRadarExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.brightsky.dev";
            var apiInstance = new DefaultApi(config);
            var date = 2023-08-07;  // DateTime? | Timestamp of first record to retrieve, in ISO 8601 format. May contain time and/or UTC offset. (_Defaults to 1 hour before latest measurement._) (optional) 
            var lastDate = 2023-08-08;  // DateTime? | Timestamp of last record to retrieve, in ISO 8601 format.  May contain time and/or UTC offset. (_Defaults to 2 hours after `date`._) (optional) 
            var bbox = new List<int>(); // List<int> | Bounding box (top, left, bottom, right) **in pixels**, edges are inclusive. (_Defaults to full 1200x1100 grid._) (optional) 
            var lat = 52.52;  // decimal? | Alternative way to set a bounding box, where `lat` / `lon` will lay inside (but not necessarily in the center of) the returned radar data. Data will reach `distance` meters to each side of this location, but is possibly cut off at the edges of the radar grid. (optional) 
            var lon = 13.4;  // decimal? | Alternative way to set a bounding box, must be used together with `lat` and `distance`, see description for `lat`. (optional) 
            var distance = 100000;  // int? | Alternative way to set a bounding box, must be used together with `lat` and `lon`, see description for `lat`. (optional) 
            var tz = Europe/Berlin;  // string | Timezone in which timestamps will be presented, as <a href=\"https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\">tz database name</a>. (optional)  (default to "Etc/UTC")
            var format = "compressed";  // string | Determines how the precipitation data is encoded into the `precipitation_5` field: * `compressed`: base64-encoded, zlib-compressed bytestring of 2-byte integers * `bytes`: base64-encoded bytestring of 2-byte integers * `plain`: Nested array of integers  (optional)  (default to compressed)

            try
            {
                // Radar
                GetRadar200Response result = apiInstance.GetRadar(date, lastDate, bbox, lat, lon, distance, tz, format);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.GetRadar: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRadarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Radar
    ApiResponse<GetRadar200Response> response = apiInstance.GetRadarWithHttpInfo(date, lastDate, bbox, lat, lon, distance, tz, format);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.GetRadarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **DateTime?** | Timestamp of first record to retrieve, in ISO 8601 format. May contain time and/or UTC offset. (_Defaults to 1 hour before latest measurement._) | [optional]  |
| **lastDate** | **DateTime?** | Timestamp of last record to retrieve, in ISO 8601 format.  May contain time and/or UTC offset. (_Defaults to 2 hours after &#x60;date&#x60;._) | [optional]  |
| **bbox** | [**List&lt;int&gt;**](int.md) | Bounding box (top, left, bottom, right) **in pixels**, edges are inclusive. (_Defaults to full 1200x1100 grid._) | [optional]  |
| **lat** | **decimal?** | Alternative way to set a bounding box, where &#x60;lat&#x60; / &#x60;lon&#x60; will lay inside (but not necessarily in the center of) the returned radar data. Data will reach &#x60;distance&#x60; meters to each side of this location, but is possibly cut off at the edges of the radar grid. | [optional]  |
| **lon** | **decimal?** | Alternative way to set a bounding box, must be used together with &#x60;lat&#x60; and &#x60;distance&#x60;, see description for &#x60;lat&#x60;. | [optional]  |
| **distance** | **int?** | Alternative way to set a bounding box, must be used together with &#x60;lat&#x60; and &#x60;lon&#x60;, see description for &#x60;lat&#x60;. | [optional]  |
| **tz** | **string** | Timezone in which timestamps will be presented, as &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\&quot;&gt;tz database name&lt;/a&gt;. | [optional] [default to &quot;Etc/UTC&quot;] |
| **format** | **string** | Determines how the precipitation data is encoded into the &#x60;precipitation_5&#x60; field: * &#x60;compressed&#x60;: base64-encoded, zlib-compressed bytestring of 2-byte integers * &#x60;bytes&#x60;: base64-encoded bytestring of 2-byte integers * &#x60;plain&#x60;: Nested array of integers  | [optional] [default to compressed] |

### Return type

[**GetRadar200Response**](GetRadar200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List of radar records for the given bounding box. |  -  |
| **400** | Request has missing or invalid parameters. |  -  |
| **404** | Given location is not covered by the DWD. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getweather"></a>
# **GetWeather**
> GetWeather200Response GetWeather (DateTime date, DateTime? lastDate = null, decimal? lat = null, decimal? lon = null, List<string> dwdStationId = null, List<string> wmoStationId = null, List<int> sourceId = null, int? maxDist = null, string tz = null, string units = null)

Hourly weather (including forecasts)

Returns a list of hourly weather records (and/or forecasts) for the time range given by `date` and `last_date`.  To set the location for which to retrieve records (and/or forecasts), you must supply both `lat` and `lon` _or_ one of `dwd_station_id`, `wmo_station_id`, or `source_id`. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetWeatherExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.brightsky.dev";
            var apiInstance = new DefaultApi(config);
            var date = 2023-08-07;  // DateTime | Timestamp of first weather record (or forecast) to retrieve, in ISO 8601 format. May contain time and/or UTC offset.
            var lastDate = 2023-08-08;  // DateTime? | Timestamp of last weather record (or forecast) to retrieve, in ISO 8601 format. Will default to `date + 1 day`. (optional) 
            var lat = 52.52;  // decimal? | Latitude in decimal degrees. (optional) 
            var lon = 13.4;  // decimal? | Longitude in decimal degrees. (optional) 
            var dwdStationId = new List<string>(); // List<string> | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var wmoStationId = new List<string>(); // List<string> | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var sourceId = new List<int>(); // List<int> | Bright Sky source ID, as retrieved from the [`/sources` endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. (optional) 
            var maxDist = 10000;  // int? | Maximum distance of record location from the location given by `lat` and `lon`, in meters. Only has an effect when using `lat` and `lon`. (optional)  (default to 50000)
            var tz = Europe/Berlin;  // string | Timezone in which record timestamps will be presented, as <a href=\"https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\">tz database name</a>. Will also be used as timezone when parsing `date` and `last_date`, unless these have explicit UTC offsets. If omitted but `date` has an explicit UTC offset, that offset will be used as timezone. Otherwise will default to UTC. (optional) 
            var units = "dwd";  // string | Physical units in which meteorological parameters will be returned. Set to `si` to use <a href=\"https://en.wikipedia.org/wiki/International_System_of_Units\">SI units</a> (except for precipitation, which is always measured in millimeters). The default `dwd` option uses a set of units that is more common in meteorological applications and civil use: <table>   <tr><td></td><td>DWD</td><td>SI</td></tr>   <tr><td>Cloud cover</td><td>%</td><td>%</td></tr>   <tr><td>Dew point</td><td>°C</td><td>K</td></tr>   <tr><td>Precipitation</td><td>mm</td><td><s>kg / m²</s> <strong>mm</strong></td></tr>   <tr><td>Precipitation probability</td><td>%</td><td>%</td></tr>   <tr><td>Pressure</td><td>hPa</td><td>Pa</td></tr>   <tr><td>Relative humidity</td><td>%</td><td>%</td></tr>   <tr><td>Solar irradiation</td><td>kWh / m²</td><td>J / m²</td></tr>   <tr><td>Sunshine</td><td>min</td><td>s</td></tr>   <tr><td>Temperature</td><td>°C</td><td>K</td></tr>   <tr><td>Visibility</td><td>m</td><td>m</td></tr>   <tr><td>Wind (gust) direction</td><td>°</td><td>°</td></tr>   <tr><td>Wind (gust) speed</td><td>km / h</td><td>m / s</td></tr> </table>  (optional)  (default to dwd)

            try
            {
                // Hourly weather (including forecasts)
                GetWeather200Response result = apiInstance.GetWeather(date, lastDate, lat, lon, dwdStationId, wmoStationId, sourceId, maxDist, tz, units);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DefaultApi.GetWeather: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetWeatherWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Hourly weather (including forecasts)
    ApiResponse<GetWeather200Response> response = apiInstance.GetWeatherWithHttpInfo(date, lastDate, lat, lon, dwdStationId, wmoStationId, sourceId, maxDist, tz, units);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DefaultApi.GetWeatherWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **date** | **DateTime** | Timestamp of first weather record (or forecast) to retrieve, in ISO 8601 format. May contain time and/or UTC offset. |  |
| **lastDate** | **DateTime?** | Timestamp of last weather record (or forecast) to retrieve, in ISO 8601 format. Will default to &#x60;date + 1 day&#x60;. | [optional]  |
| **lat** | **decimal?** | Latitude in decimal degrees. | [optional]  |
| **lon** | **decimal?** | Longitude in decimal degrees. | [optional]  |
| **dwdStationId** | [**List&lt;string&gt;**](string.md) | DWD station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **wmoStationId** | [**List&lt;string&gt;**](string.md) | WMO station ID, typically five alphanumeric characters. You can supply multiple station IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **sourceId** | [**List&lt;int&gt;**](int.md) | Bright Sky source ID, as retrieved from the [&#x60;/sources&#x60; endpoint](/operations/getSources). You can supply multiple source IDs separated by commas, ordered from highest to lowest priority. | [optional]  |
| **maxDist** | **int?** | Maximum distance of record location from the location given by &#x60;lat&#x60; and &#x60;lon&#x60;, in meters. Only has an effect when using &#x60;lat&#x60; and &#x60;lon&#x60;. | [optional] [default to 50000] |
| **tz** | **string** | Timezone in which record timestamps will be presented, as &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/List_of_tz_database_time_zones\&quot;&gt;tz database name&lt;/a&gt;. Will also be used as timezone when parsing &#x60;date&#x60; and &#x60;last_date&#x60;, unless these have explicit UTC offsets. If omitted but &#x60;date&#x60; has an explicit UTC offset, that offset will be used as timezone. Otherwise will default to UTC. | [optional]  |
| **units** | **string** | Physical units in which meteorological parameters will be returned. Set to &#x60;si&#x60; to use &lt;a href&#x3D;\&quot;https://en.wikipedia.org/wiki/International_System_of_Units\&quot;&gt;SI units&lt;/a&gt; (except for precipitation, which is always measured in millimeters). The default &#x60;dwd&#x60; option uses a set of units that is more common in meteorological applications and civil use: &lt;table&gt;   &lt;tr&gt;&lt;td&gt;&lt;/td&gt;&lt;td&gt;DWD&lt;/td&gt;&lt;td&gt;SI&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Cloud cover&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Dew point&lt;/td&gt;&lt;td&gt;°C&lt;/td&gt;&lt;td&gt;K&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Precipitation&lt;/td&gt;&lt;td&gt;mm&lt;/td&gt;&lt;td&gt;&lt;s&gt;kg / m²&lt;/s&gt; &lt;strong&gt;mm&lt;/strong&gt;&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Precipitation probability&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Pressure&lt;/td&gt;&lt;td&gt;hPa&lt;/td&gt;&lt;td&gt;Pa&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Relative humidity&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;td&gt;%&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Solar irradiation&lt;/td&gt;&lt;td&gt;kWh / m²&lt;/td&gt;&lt;td&gt;J / m²&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Sunshine&lt;/td&gt;&lt;td&gt;min&lt;/td&gt;&lt;td&gt;s&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Temperature&lt;/td&gt;&lt;td&gt;°C&lt;/td&gt;&lt;td&gt;K&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Visibility&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;td&gt;m&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Wind (gust) direction&lt;/td&gt;&lt;td&gt;°&lt;/td&gt;&lt;td&gt;°&lt;/td&gt;&lt;/tr&gt;   &lt;tr&gt;&lt;td&gt;Wind (gust) speed&lt;/td&gt;&lt;td&gt;km / h&lt;/td&gt;&lt;td&gt;m / s&lt;/td&gt;&lt;/tr&gt; &lt;/table&gt;  | [optional] [default to dwd] |

### Return type

[**GetWeather200Response**](GetWeather200Response.md)

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

