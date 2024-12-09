namespace WeatherApp.Model;

//https://github.com/lukes/ISO-3166-Countries-with-Regional-Codes/blob/master/all/all.json
public class CountryInformation
{
    public string name { get; set; }
    public string alpha_2 { get; set; }
    public string alpha_3 { get; set; }
    public string country_code { get; set; }
    public string iso_3166_2 { get; set; }
    public string region { get; set; }
    public string sub_region { get; set; }
    public string intermediate_region { get; set; }
    public string region_code { get; set; }
    public string sub_region_code { get; set; }
    public string intermediate_region_code { get; set; }
}