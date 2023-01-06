import { WeatherObj } from "./weather-obj";
import { WeatherForecastServiceObj_Daily } from "./weather-forecast-service-obj-daily";

export interface WeatherForecastServiceObj {
  currentWeather: WeatherObj;
  daily: WeatherForecastServiceObj_Daily;
}