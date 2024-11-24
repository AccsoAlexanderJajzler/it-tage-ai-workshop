using System.Text.Json;

namespace WeatherApp.Model.OpenWeather;
public class WeatherMaps
{
    public string ZoomLevel { get; set; }
    public string PossibleXY { get; set; }
    public string QuantityOfTiles { get; set; }
    public string AreaToRepresent { get; set; }

}