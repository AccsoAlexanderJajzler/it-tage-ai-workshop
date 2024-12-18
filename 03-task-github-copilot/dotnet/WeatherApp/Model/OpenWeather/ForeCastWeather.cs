namespace WeatherApp.Model.OpenWeather;

public class ForeCastWeather
{
    public City city { get; set; }
    public string cod { get; set; }
    public double message { get; set; }
    public int cnt { get; set; }
    public List[] list { get; set; }
}

public class City
{
    public int id { get; set; }
    public string name { get; set; }
    public Coord coord { get; set; }
    public string country { get; set; }
    public int population { get; set; }
    public int timezone { get; set; }
}

public class Coord
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class List
{
    public int dt { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
    public Temp temp { get; set; }
    public Feels_like feels_like { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public Weather[] weather { get; set; }
    public double speed { get; set; }
    public int deg { get; set; }
    public double gust { get; set; }
    public int clouds { get; set; }
    public double pop { get; set; }
    public double rain { get; set; }
}

public class Temp
{
    public double day { get; set; }
    public double min { get; set; }
    public double max { get; set; }
    public double night { get; set; }
    public double eve { get; set; }
    public double morn { get; set; }
}

public class Feels_like
{
    public double day { get; set; }
    public double night { get; set; }
    public double eve { get; set; }
    public double morn { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

