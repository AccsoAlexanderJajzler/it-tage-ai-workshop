# Weather Inc. - Weather App

The WeatherInc. Weather App is a playground for AI assisted Software Engineering with .NET. It's a simple Razor Web App that displays various weather information and will soon be your favorite new weather app.

Your goal is to fix all `TODO`s in the code with the help of GitHub Copilot. If you have no Copilot account yet, have a look at the [Wiki](https://accso.atlassian.net/wiki/spaces/ACCAPP/pages/252969761/User+manual+GitHub+Copilot#Bestellung).

## 🧑‍💻 Setup

This demo project is intended to be used with [VS Code](https://code.visualstudio.com). After installing the editor, get the required extensions and open the project directory. The .NET 8 SDK is required to run the project and should be downloaded and installed automatically by the `C# Dev Kit` extension if required. You can also download it manually from the [official .NET website](https://dotnet.microsoft.com/download).

### ➕ Extensions

C# Dev Kit  
Id: ms-dotnettools.csdevkit  
VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit

GitHub Copilot  
Id: GitHub.copilot  
VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=GitHub.copilot

GitHub Copilot Chat  
Id: GitHub.copilot-chat  
VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=GitHub.copilot-chat

Todo Tree  
Id: Gruntfuggly.todo-tree  
VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=Gruntfuggly.todo-tree

### 🔧 Configuration

For a better experience there a couple of VS Code configuration you should take care of. Open the personal settings via `CMD + Shift + P` `Preferences: Open User Settings (JSON)` and add the following lines:

```json
"csharp.preview.improvedLaunchExperience": true
```

### 🚀 Starting the project

The project has two launch configuration `C#: WeatherApp Debug` and `C#: WeatherApp Watch`. You can select your launch configuration in the _Run & Debug_ tab in the sidebar or simply launch the project via `F5` or `CMD + Shift + P` `Debug: Start Debugging`.

The _Watch_ configuration uses [Hot Code Reload](https://learn.microsoft.com/en-us/aspnet/core/test/hot-reload?view=aspnetcore-8.0) to automatically reflect (mostly) all changes in you Code without restarting the application.

If this causes any trouble, you can fallback to the regular _Debug_ configuration.

## 🤖 Copilot Basics

After installing the Copilot and Copilot Chat extensions, you need to sign in with your Accso GitHub account.

Now autocompletion suggestions from Copilot should just work out of the box. For more information about the current status of Copilot, you can click the Copilot icon in the bottom right of the status bar.

Use `CMD + I` anywhere in the editor to open a Copilot inline Chat. You can also mark specific parts of your code before asking questions.

The Copilot Chat is available via the _Chat_ tab in the sidebar (speech bubble icon) or with `CMD + Shift + P` `Chat: Open Quick Chat` / `Chat: Open Chat in Side Bar`. When using the chat, you can use special commands like `/explain`, `fix` or `/test` to quickly tell Copilot what you need.

Sometimes code sections are marked with `\/ \/ \/ \/` and `/\ /\ /\ /\`. Mark selecting these sections before prompting Copilot for better results.

## 🎖️ Goals

There are several tasks marked with `TODO` in the code that can be used to test different abilities of you AI coding companion. Use the _TODOs_ tab in the sidebar (tree with checkmark icon) to get a quick overview. The TODOs have ranging difficulties:

- `TODO 🥉` These are fairly easy and can mostly be addressed with the Copilot inline prompt.
- `TODO 🥈` Medium challenges. Better use the Copilot Chat to solve these, because some some additional feedback or information to Copilot may be needed.
- `TODO 🥇` These are severe riddles that will take some time to solve.

For some easy tasks, start with the `TODO`s in `Home.razor`. For more advanced challenges, have a look at the `Bugfix` folder.

**PRO TIP**: When having a file open with multiple `TODO`s, try a prompt like `fix all the TOODs in the code`.

![Impatient customer demanding more features and less bugs](assets/customer.webp)
_Impatient customer demanding more features and less bugs_

## 💡 Tips, Tricks and Pitfalls

After adding tests to the `WeatherAppTest` project, you need to run `CMD + Shift + P` `.NET: Build` to make the tests appear in the `Testing` tab (test tube icon).

Sometimes, VS Code fails to close the process after debugging. This results in `port in use` errors when starting another debugging session. Execute these commands in the terminal to kill the orphaned process. For convenience they are also included as VS Code Tasks, you can run them using `CMD + Shift + P` `Run Task`.

VS Code Task _kill port 5002_

```bash
$ kill $(lsof -t -i:5002)
```

VS Code Task _kill dotnet process_

```bash
$ pkill -f dotnet
```




## ℹ️ Additional infos for the 🥇 challenges


### WeatherApi with OpenWeather
#### Quick Info
OpenWeather is a popular weather API that provides access to current weather data, forecasts, and historical weather data for locations worldwide. It offers a wide range of weather information, including temperature, humidity, wind speed, and more. OpenWeather requires an API key for authentication, which can be obtained by signing up on their website.

You an use following options for calls:
- [Weather.Net](https://github.com/WeatherInc/Weather.Net)
- SimpleOpenWeatherApiService
- or the advanced ApiClient in Services.OpenWeather.Client

#### Documentation for API Endpoints
All URIs are relative to *https://api.openweathermap.org*
|Class | Method | HTTP request | Description|
|------------ | ------------- | ------------- | -------------
|*DefaultApi* | [**GetCurrentWeather**](docs/DefaultApi.md#getcurrentweather) | **GET** /weather | Current weather
|*DefaultApi* | [**GetForecast**](docs/DefaultApi.md#getforecast) | **GET** /forecast | 5-day weather forecast
|*DefaultApi* | [**GetHistoricalWeather**](docs/DefaultApi.md#gethistoricalweather) | **GET** /onecall/timemachine | Historical weather data
|*DefaultApi* | [**GetWeatherByCityName**](docs/DefaultApi.md#getweatherbycityname) | **GET** /weather | Current weather by city name
|*DefaultApi* | [**GetWeatherByCoordinates**](docs/DefaultApi.md#getweatherbycoordinates) | **GET** /weather | Current weather by geographic coordinates
#### Documentation for Models
- [Model.CurrentWeather](docs/CurrentWeather.md)
- [Model.Forecast](docs/Forecast.md)
- [Model.HistoricalWeather](docs/HistoricalWeather.md)
#### Documentation for Authentication
All endpoints require an API key for authentication. The API key should be included in the request URL as a query parameter.
#### Useful Links
- [OpenWeather API documentation](https://openweathermap.org/api)
- [OpenWeather API key signup](https://home.openweathermap.org/users/sign_up)



### WeatherApi with BrightSky

#### Quick Info

Bright Sky is a free and open-source weather API. It aims to provide an easy-to-use gateway to weather data that the [DWD](https://www.dwd.de/) – Germany's meteorological service – publishes on their [open data server](https://opendata.dwd.de/).

The public instance at `https://api.brightsky.dev/` is free-to-use for all purposes, **no API key required**! Please note that the [DWD's Terms of Use](https://www.dwd.de/EN/service/copyright/copyright_artikel.html) apply to all data you retrieve through the API.

> This documentation is generated from an OpenAPI specification. The current version is available from https://brightsky.dev/brightsky.yml. (Don't use the openapi with DOTNET)

#### Documentation for API Endpoints

All URIs are relative to *https://api.brightsky.dev*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*DefaultApi* | [**GetAlerts**](docs/DefaultApi.md#getalerts) | **GET** /alerts | Alerts
*DefaultApi* | [**GetCurrentWeather**](docs/DefaultApi.md#getcurrentweather) | **GET** /current_weather | Current weather
*DefaultApi* | [**GetRadar**](docs/DefaultApi.md#getradar) | **GET** /radar | Radar
*DefaultApi* | [**GetWeather**](docs/DefaultApi.md#getweather) | **GET** /weather | Hourly weather (including forecasts)
*InternalsApi* | [**GetSources**](docs/InternalsApi.md#getsources) | **GET** /sources | Weather sources (stations)
*InternalsApi* | [**GetSynop**](docs/InternalsApi.md#getsynop) | **GET** /synop | Raw SYNOP observations

<a name="documentation-for-models"></a>

#### Documentation for Models

 - [Model.Alert](docs/Alert.md)
 - [Model.CurrentWeatherRecord](docs/CurrentWeatherRecord.md)
 - [Model.GetAlerts200Response](docs/GetAlerts200Response.md)
 - [Model.GetAlerts400Response](docs/GetAlerts400Response.md)
 - [Model.GetCurrentWeather200Response](docs/GetCurrentWeather200Response.md)
 - [Model.GetCurrentWeather200ResponseWeather](docs/GetCurrentWeather200ResponseWeather.md)
 - [Model.GetCurrentWeather200ResponseWeatherAllOf](docs/GetCurrentWeather200ResponseWeatherAllOf.md)
 - [Model.GetCurrentWeather400Response](docs/GetCurrentWeather400Response.md)
 - [Model.GetCurrentWeather404Response](docs/GetCurrentWeather404Response.md)
 - [Model.GetRadar200Response](docs/GetRadar200Response.md)
 - [Model.GetRadar400Response](docs/GetRadar400Response.md)
 - [Model.GetRadar404Response](docs/GetRadar404Response.md)
 - [Model.GetSources200Response](docs/GetSources200Response.md)
 - [Model.GetSynop200Response](docs/GetSynop200Response.md)
 - [Model.GetWeather200Response](docs/GetWeather200Response.md)
 - [Model.Location](docs/Location.md)
 - [Model.Radar](docs/Radar.md)
 - [Model.Source](docs/Source.md)
 - [Model.SynopRecord](docs/SynopRecord.md)
 - [Model.SynopRecordAllOf](docs/SynopRecordAllOf.md)
 - [Model.WeatherRecord](docs/WeatherRecord.md)

<a name="documentation-for-authorization"></a>

#### Documentation for Authorization

All endpoints do not require authorization.

#### Good to Know

* **Geographical coverage**: due to its nature as German meteorological service, the observations published by the DWD have a strong focus on Germany. The _forecasts_ cover the whole world, albeit at a much lower density outside of Germany.
* **Historical coverage**: Bright Sky serves historical data going back to January 1st, 2010. If you need data that goes further back, check out our [infrastructure repository](https://github.com/jdemaeyer/brightsky-infrastructure) to easily set up your own instance of Bright Sky!
* **Source IDs**: Bright Sky's _source IDs_ are a technical artifact and – unlike the [DWD station IDs](https://www.dwd.de/DE/leistungen/klimadatendeutschland/stationsliste.html) and [WMO station IDs](https://opendata.dwd.de/climate_environment/CDC/help/stations_list_CLIMAT_data.txt) – have no meaning in the real world. When making requests to Bright Sky, try to avoid them and supply lat/lon or station IDs instead.


#### Useful Links

* [Bright Sky source code and issue tracking](https://github.com/jdemaeyer/brightsky/)
* [Bright Sky infrastructure configuration](https://github.com/jdemaeyer/brightsky-infrastructure/)
* [DWD Open Data landing page](https://www.dwd.de/EN/ourservices/opendata/opendata.html)
* [Additional explanation files for DWD Open Data](https://www.dwd.de/DE/leistungen/opendata/hilfe.html?nn=495490&lsbId=627548), including:
    * [List of main observation stations](https://www.dwd.de/DE/leistungen/opendata/help/stationen/ha_messnetz.xls?__blob=publicationFile&v=1)
    * [List of additional observation stations](https://www.dwd.de/DE/leistungen/opendata/help/stationen/na_messnetz.xlsx?__blob=publicationFile&v=10)
    * [List of MOSMIX stations](https://www.dwd.de/DE/leistungen/met_verfahren_mosmix/mosmix_stationskatalog.cfg?view=nasPublication&nn=495490)
    * [List of meteorological parameters](https://www.dwd.de/DE/leistungen/opendata/help/schluessel_datenformate/kml/mosmix_elemente_pdf.pdf?__blob=publicationFile&v=2)
* [DWD Open Data FAQ (German)](https://www.dwd.de/DE/leistungen/opendata/faqs_opendata.html)
* [DWD Copyright information](https://www.dwd.de/EN/service/copyright/copyright_artikel.html)

#### Data Sources

All data available through Bright Sky is taken or derived from data on the [DWD open data server](https://opendata.dwd.de/):

* **Current weather / SYNOP**:
  * https://opendata.dwd.de/weather/weather_reports/synoptic/germany/json/
* **Hourly weather**:
  * Historical: https://opendata.dwd.de/climate_environment/CDC/observations_germany/climate/
  * Current day: https://opendata.dwd.de/weather/weather_reports/poi/
  * Forecasts: https://opendata.dwd.de/weather/local_forecasts/mos/
* **Radar**:
  * https://opendata.dwd.de/weather/radar/composite/rv/
* **Alerts**:
  * https://opendata.dwd.de/weather/alerts/cap/COMMUNEUNION_DWD_STAT/
