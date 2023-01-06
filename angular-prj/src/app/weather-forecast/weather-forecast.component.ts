import { Component, OnInit, Output, EventEmitter } from '@angular/core';

import { WeatherForecastServiceObj } from '../weather-forecast-service-obj';
import { WeatherForecastService } from '../weather-forecast.service';
import { WeatherObj } from '../weather-obj';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.css']
})
export class WeatherForecastComponent {

  @Output() backgroundChangeEvent = new EventEmitter<string>();

  currentWeather: WeatherObj = <WeatherObj>{};

  weatherForecast: WeatherObj[] = [];

  wmoCode = {

    0: "Clear Sky",
    1: "Mainly Clear",
    2: "Partly Cloudy",
    3: "Overcast",
    45: "Fog",
    48: "Depositing Rime Fog",

    51: "Light Drizzle",
    53: "Moderate Drizzle",
    55: "Dense Intensity Drizzle",

    56: "Light Freezing Drizzle",
    57: "Dense Intensity Freezing Drizzle",

    61: "Slight Rain",
    63: "Moderate Rain",
    65: "Heavy Intensity Rain",

    66: "Light Freezing Rain",
    67: "heavy Intensity Freezing Rain",

    71: "Slight Snow Fall",
    73: "Moderate Snow Fall",
    75: "Heavy Intensity Snow Fall",

    77: "Snow Grains",

    80: "Slight Rain Showers",
    81: "Moderate Rain Showers",
    82: "Violent Rain Showers",

    85: "Slight Snow Showers",
    86: "Heavy Snow Showers",

    95: "Thunderstorm",

    96: "Thunderstorm with Slight Hail",
    99: "Thunderstorm with Heavy Hail"

  };

  constructor(
    private weatherForecastService: WeatherForecastService
  ) {}

  ngOnInit(): void {
    this.getWeatherForecast();
  }

  getWeatherForecast(): void {
    this.weatherForecastService.getWeatherForecast()
      .subscribe((svcObj) => {
        this.currentWeather = svcObj.currentWeather;

        var wfs = [];
        for(var i=0;i<svcObj.daily.time.length;i++){
          var wf = <WeatherObj>{};
          wf.time = svcObj.daily.time[i];
          wf.weathercode = svcObj.daily.weathercode[i];
          var l = Math.trunc(wf.weathercode);
          wfs.push(wf);
        }
        this.weatherForecast = wfs;
        
        this.backgroundChangeEvent.emit('assets/weather/breeze.jpg');
      });
  }
}
