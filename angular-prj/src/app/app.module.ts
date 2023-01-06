import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { HeroesComponent } from './heroes/heroes.component';
import { HeroSearchComponent } from './hero-search/hero-search.component';
import { MessagesComponent } from './messages/messages.component';
import { WeatherComponent } from './weather/weather.component';
import { EFormServiceEnvStatusComponent } from './eform-service-env-status/eform-service-env-status.component';
import { PersonsComponent } from './persons/persons.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,

    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    ///*
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, 
      { 
        dataEncapsulation: false, 
        passThruUnknownUrl: true 
      }
    )
    //*/
  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    HeroesComponent,
    HeroDetailComponent,
    MessagesComponent,
    HeroSearchComponent,
    WeatherComponent,
    EFormServiceEnvStatusComponent,
    PersonsComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }