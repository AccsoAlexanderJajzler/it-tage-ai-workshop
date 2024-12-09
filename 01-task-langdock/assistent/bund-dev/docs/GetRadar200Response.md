
# Org.OpenAPITools.Model.GetRadar200Response

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Radar** | [**List&lt;Radar&gt;**](Radar.md) |  | [optional] 
**Geometry** | **Object** | GeoJSON-formatted bounding box of returned radar data, i.e. lat/lon coordinates of the four corners. | [optional] 
**Bbox** | **List&lt;int&gt;** | Bounding box (top, left, bottom, right) calculated from the supplied position and distance. Only returned if you supplied &#x60;lat&#x60; and &#x60;lon&#x60;. | [optional] 
**LatlonPosition** | **Object** | Exact x-y-position of the supplied position. Only returned if you supplied &#x60;lat&#x60; and &#x60;lon&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

