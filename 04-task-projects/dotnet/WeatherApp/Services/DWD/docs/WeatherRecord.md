# Org.OpenAPITools.Model.WeatherRecord

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Timestamp** | **DateTime** | ISO 8601-formatted timestamp of this weather record | [optional] 
**SourceId** | **int** | Main Bright Sky source ID for this record | [optional] 
**CloudCover** | **decimal?** | Total cloud cover at timestamp | [optional] 
**Condition** | **string** | Current weather conditions. Unlike the numerical parameters, this field is not taken as-is from the raw data (because it does not exist), but is calculated from different fields in the raw data as a best effort. Not all values are available for all source types.  | [optional] 
**DewPoint** | **decimal?** | Dew point at timestamp, 2 m above ground | [optional] 
**Icon** | **string** | Icon alias suitable for the current weather conditions. Unlike the numerical parameters, this field is not taken as-is from the raw data (because it does not exist), but is calculated from different fields in the raw data as a best effort. Not all values are available for all source types.  | [optional] 
**Precipitation** | **decimal?** | Total precipitation during previous 60 minutes | [optional] 
**PrecipitationProbability** | **int?** | Probability of more than 0.1 mm of precipitation in the previous hour (only available in forecasts) | [optional] 
**PrecipitationProbability6h** | **int?** | Probability of more than 0.2 mm of precipitation in the previous 6 hours (only available in forecasts at 0:00, 6:00, 12:00, and 18:00 UTC) | [optional] 
**PressureMsl** | **decimal?** | Atmospheric pressure at timestamp, reduced to mean sea level | [optional] 
**RelativeHumidity** | **decimal?** | Relative humidity at timestamp | [optional] 
**Solar** | **decimal?** | Solar irradiation during previous 60 minutes | [optional] 
**Sunshine** | **decimal?** | Sunshine duration during previous 60 minutes | [optional] 
**Temperature** | **decimal?** | Air temperature at timestamp, 2 m above the ground | [optional] 
**Visibility** | **decimal?** | Visibility at timestamp | [optional] 
**WindDirection** | **decimal?** | Mean wind direction during previous hour, 10 m above the ground | [optional] 
**WindSpeed** | **decimal?** | Mean wind speed during previous hour, 10 m above the ground | [optional] 
**WindGustDirection** | **decimal?** | Direction of maximum wind gust during previous hour, 10 m above the ground | [optional] 
**WindGustSpeed** | **decimal?** | Speed of maximum wind gust during previous hour, 10 m above the ground | [optional] 
**FallbackSourceIds** | **Object** | Object mapping meteorological parameters to the source IDs of alternative sources that were used to fill up missing values in the main source | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

