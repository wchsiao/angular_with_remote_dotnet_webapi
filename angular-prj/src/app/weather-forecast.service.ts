import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { WeatherForecastServiceObj } from './weather-forecast-service-obj';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class WeatherForecastService {
  private apiUrl = 'https://api.open-meteo.com/v1/forecast?latitude=40.77&longitude=-73.78&hourly=temperature_2m&daily=weathercode,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,windspeed_10m_max,winddirection_10m_dominant&current_weather=true&temperature_unit=fahrenheit&windspeed_unit=mph&precipitation_unit=inch&timezone=America%2FNew_York';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }

  getWeatherForecast(): Observable<WeatherForecastServiceObj> {
    return this.http.get<WeatherForecastServiceObj>(this.apiUrl)
      .pipe(
        //tap(_ => this.log('fetched weathers')),
        catchError(this.handleError<WeatherForecastServiceObj>('getWeatherForecast', <WeatherForecastServiceObj>{}))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private log(message: string) {
    this.messageService.add(`WeatherforecastService: ${message}`);
  }
}
