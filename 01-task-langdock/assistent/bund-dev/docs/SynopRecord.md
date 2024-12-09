
# Org.OpenAPITools.Model.SynopRecord

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Timestamp** | **DateTime** | ISO 8601-formatted timestamp of this weather record | [optional] 
**SourceId** | **int** | Bright Sky source ID for this record | [optional] 
**CloudCover** | **decimal?** | Total cloud cover at timestamp | [optional] 
**Condition** | **string** | Current weather conditions. Unlike the numerical parameters, this field is not taken as-is from the raw data (because it does not exist), but is calculated from different fields in the raw data as a best effort. Not all values are available for all source types.  | [optional] 
**DewPoint** | **decimal?** | Dew point at timestamp, 2 m above ground | [optional] 
**Icon** | **string** | Icon alias suitable for the current weather conditions. Unlike the numerical parameters, this field is not taken as-is from the raw data (because it does not exist), but is calculated from different fields in the raw data as a best effort. Not all values are available for all source types.  | [optional] 
**Precipitation10** | **decimal?** | Total precipitation during previous 10 minutes | [optional] 
**Precipitation30** | **decimal?** | Total precipitation during previous 30 minutes | [optional] 
**Precipitation60** | **decimal?** | Total precipitation during previous 60 minutes | [optional] 
**PressureMsl** | **decimal?** | Atmospheric pressure at timestamp, reduced to mean sea level | [optional] 
**RelativeHumidity** | **int?** | Relative humidity at timestamp | [optional] 
**Solar10** | **decimal?** | Solar irradiation during previous 10 minutes | [optional] 
**Solar30** | **decimal?** | Solar irradiation during previous 30 minutes | [optional] 
**Solar60** | **decimal?** | Solar irradiation during previous 60 minutes | [optional] 
**Sunshine30** | **decimal?** | Sunshine duration during previous 30 minutes | [optional] 
**Sunshine60** | **decimal?** | Sunshine duration during previous 60 minutes | [optional] 
**Temperature** | **decimal?** | Air temperature at timestamp, 2 m above the ground | [optional] 
**Visibility** | **int?** | Visibility at timestamp | [optional] 
**WindDirection10** | **int?** | Mean wind direction during previous 10 minutes, 10 m above the ground | [optional] 
**WindDirection30** | **int?** | Mean wind direction during previous 30 minutes, 10 m above the ground | [optional] 
**WindDirection60** | **int?** | Mean wind direction during previous 60 minutes, 10 m above the ground | [optional] 
**WindSpeed10** | **decimal?** | Mean wind speed during previous previous 10 minutes, 10 m above the ground | [optional] 
**WindSpeed30** | **decimal?** | Mean wind speed during previous previous 30 minutes, 10 m above the ground | [optional] 
**WindSpeed60** | **decimal?** | Mean wind speed during previous previous 60 minutes, 10 m above the ground | [optional] 
**WindGustDirection10** | **int?** | Direction of maximum wind gust during previous 10 minutes, 10 m above the ground | [optional] 
**WindGustDirection30** | **int?** | Direction of maximum wind gust during previous 30 minutes, 10 m above the ground | [optional] 
**WindGustDirection60** | **int?** | Direction of maximum wind gust during previous 60 minutes, 10 m above the ground | [optional] 
**WindGustSpeed10** | **decimal?** | Speed of maximum wind gust during previous 10 minutes, 10 m above the ground | [optional] 
**WindGustSpeed30** | **decimal?** | Speed of maximum wind gust during previous 30 minutes, 10 m above the ground | [optional] 
**WindGustSpeed60** | **decimal?** | Speed of maximum wind gust during previous 60 minutes, 10 m above the ground | [optional] 
**Sunshine10** | **decimal?** | Sunshine duration during previous 10 minutes | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

