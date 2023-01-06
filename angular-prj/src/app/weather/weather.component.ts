import { Component, OnInit,Output, EventEmitter } from '@angular/core';

import { Weather } from '../weather';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  @Output() backgroundChangeEvent = new EventEmitter<string>();
  
  weathers: Weather[] = [];

  constructor(private weatherService: WeatherService) {}

  ngOnInit(): void {
    this.getWeathers();
  }

  getWeathers(): void {
    this.weatherService.getWeathers()
    .subscribe((weathers) => {
      this.weathers = weathers;
      this.backgroundChangeEvent.emit('assets/weather/breeze.jpg');
    });
  }
}