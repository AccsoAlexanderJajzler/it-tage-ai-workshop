/*
 * Bright Sky
 *
 *  Bright Sky is a free and open-source weather API. It aims to provide an easy-to-use gateway to weather data that the [DWD](https://www.dwd.de/) – Germany's meteorological service – publishes on their [open data server](https://opendata.dwd.de/).  The public instance at `https://api.brightsky.dev/` is free-to-use for all purposes, **no API key required**! Please note that the [DWD's Terms of Use](https://www.dwd.de/EN/service/copyright/copyright_artikel.html) apply to all data you retrieve through the API.  > This documentation is generated from an OpenAPI specification. The current version is available from https://brightsky.dev/brightsky.yml.   ## Quickstart  * Check out [`/current_weather`](operations/getCurrentWeather) if you want to know what the weather's like _right now_. * Check out [`/weather`](operations/getWeather) for hourly weather observations and forecasts. * Check out [`/radar`](operations/getRadar) if you're looking for a high-resolution rain radar. * Check out [`/alerts`](operations/getAlerts) if you're interested in weather alerts.  ... or keep reading below for some background information.   ## Good to Know  * **Geographical coverage**: due to its nature as German meteorological service, the observations published by the DWD have a strong focus on Germany. The _forecasts_ cover the whole world, albeit at a much lower density outside of Germany. * **Historical coverage**: Bright Sky serves historical data going back to January 1st, 2010. If you need data that goes further back, check out our [infrastructure repository](https://github.com/jdemaeyer/brightsky-infrastructure) to easily set up your own instance of Bright Sky! * **Source IDs**: Bright Sky's _source IDs_ are a technical artifact and – unlike the [DWD station IDs](https://www.dwd.de/DE/leistungen/klimadatendeutschland/stationsliste.html) and [WMO station IDs](https://opendata.dwd.de/climate_environment/CDC/help/stations_list_CLIMAT_data.txt) – have no meaning in the real world. When making requests to Bright Sky, try to avoid them and supply lat/lon or station IDs instead.   ## Useful Links  * [Bright Sky source code and issue tracking](https://github.com/jdemaeyer/brightsky/) * [Bright Sky infrastructure configuration](https://github.com/jdemaeyer/brightsky-infrastructure/) * [DWD Open Data landing page](https://www.dwd.de/EN/ourservices/opendata/opendata.html) * [Additional explanation files for DWD Open Data](https://www.dwd.de/DE/leistungen/opendata/hilfe.html?nn=495490&lsbId=627548), including:     * [List of main observation stations](https://www.dwd.de/DE/leistungen/opendata/help/stationen/ha_messnetz.xls?__blob=publicationFile&v=1)     * [List of additional observation stations](https://www.dwd.de/DE/leistungen/opendata/help/stationen/na_messnetz.xlsx?__blob=publicationFile&v=10)     * [List of MOSMIX stations](https://www.dwd.de/DE/leistungen/met_verfahren_mosmix/mosmix_stationskatalog.cfg?view=nasPublication&nn=495490)     * [List of meteorological parameters](https://www.dwd.de/DE/leistungen/opendata/help/schluessel_datenformate/kml/mosmix_elemente_pdf.pdf?__blob=publicationFile&v=2) * [DWD Open Data FAQ (German)](https://www.dwd.de/DE/leistungen/opendata/faqs_opendata.html) * [DWD Copyright information](https://www.dwd.de/EN/service/copyright/copyright_artikel.html)   ## Data Sources  All data available through Bright Sky is taken or derived from data on the [DWD open data server](https://opendata.dwd.de/):  * **Current weather / SYNOP**:   * https://opendata.dwd.de/weather/weather_reports/synoptic/germany/json/ * **Hourly weather**:   * Historical: https://opendata.dwd.de/climate_environment/CDC/observations_germany/climate/   * Current day: https://opendata.dwd.de/weather/weather_reports/poi/   * Forecasts: https://opendata.dwd.de/weather/local_forecasts/mos/ * **Radar**:   * https://opendata.dwd.de/weather/radar/composite/rv/ * **Alerts**:   * https://opendata.dwd.de/weather/alerts/cap/COMMUNEUNION_DWD_STAT/ 
 *
 * The version of the OpenAPI document: 2.1.9
 * Contact: jakob@brightsky.dev
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Service.DWD.Model
{
    /// <summary>
    /// GetWeather200Response
    /// </summary>
    [DataContract(Name = "getWeather_200_response")]
    public partial class GetWeather200Response : IEquatable<GetWeather200Response>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWeather200Response" /> class.
        /// </summary>
        /// <param name="weather">weather.</param>
        /// <param name="sources">sources.</param>
        public GetWeather200Response(List<WeatherRecord> weather = default(List<WeatherRecord>), List<Source> sources = default(List<Source>))
        {
            Weather = weather;
            Sources = sources;
        }

        /// <summary>
        /// Gets or Sets Weather
        /// </summary>
        [DataMember(Name = "weather", EmitDefaultValue = false)]
        public List<WeatherRecord> Weather { get; set; }

        /// <summary>
        /// Gets or Sets Sources
        /// </summary>
        [DataMember(Name = "sources", EmitDefaultValue = false)]
        public List<Source> Sources { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GetWeather200Response {\n");
            sb.Append("  Weather: ").Append(Weather).Append("\n");
            sb.Append("  Sources: ").Append(Sources).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as GetWeather200Response);
        }

        /// <summary>
        /// Returns true if GetWeather200Response instances are equal
        /// </summary>
        /// <param name="input">Instance of GetWeather200Response to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetWeather200Response? input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    Weather == input.Weather ||
                    Weather != null &&
                    input.Weather != null &&
                    Weather.SequenceEqual(input.Weather)
                ) && 
                (
                    Sources == input.Sources ||
                    Sources != null &&
                    input.Sources != null &&
                    Sources.SequenceEqual(input.Sources)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (Weather != null)
                {
                    hashCode = (hashCode * 59) + Weather.GetHashCode();
                }
                if (Sources != null)
                {
                    hashCode = (hashCode * 59) + Sources.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
