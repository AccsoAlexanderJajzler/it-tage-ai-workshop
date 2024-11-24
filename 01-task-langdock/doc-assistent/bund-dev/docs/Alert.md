
# Org.OpenAPITools.Model.Alert

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **int** | Bright Sky-internal ID for this alert | [optional] 
**AlertId** | **string** | Unique CAP message identifier | [optional] 
**Status** | **string** | Alert status | [optional] 
**Effective** | **DateTime** | Alert issue time | [optional] 
**Onset** | **DateTime** | Expected event begin time | [optional] 
**Expires** | **DateTime?** | Expected event end time | [optional] 
**Category** | **string** | Alert category, meteorological message (&#x60;met&#x60;) or public health related message (&#x60;health&#x60;) | [optional] 
**ResponseType** | **string** | Code denoting type of action recommended for target audience | [optional] 
**Urgency** | **string** | Alert time frame | [optional] 
**Severity** | **string** | Alert severity | [optional] 
**Certainty** | **string** | Alert certainty | [optional] 
**EventCode** | **int?** | DWD event code | [optional] 
**EventEn** | **string** | Label for DWD event code (English) | [optional] 
**EventDe** | **string** | Label for DWD event code (German) | [optional] 
**HeadlineEn** | **string** | Alert headline (English) | [optional] 
**HeadlineDe** | **string** | Alert headline (German) | [optional] 
**DescriptionEn** | **string** | Alert description (English) | [optional] 
**DescriptionDe** | **string** | Alert headline (German) | [optional] 
**InstructionEn** | **string** | Additional instructions and safety advice (English) | [optional] 
**InstructionDe** | **string** | Additional instructions and safety advice (German) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

