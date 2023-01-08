import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroesComponent } from './heroes/heroes.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { WeatherComponent } from './weather/weather.component';

import { PersonsComponent } from './persons/persons.component';
import { PersonDetailComponent } from './person-detail/person-detail.component';

import { EFormServiceStatusComponent } from './eform-service-status/eform-service-status.component';
import { EFormServiceRequestTypeStatusComponent } from './eform-service-request-type-status/eform-service-request-type-status.component';

import { WeatherForecastComponent } from './weather-forecast/weather-forecast.component';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'detail/:id', component: HeroDetailComponent },
  { path: 'heroes', component: HeroesComponent },
  { path: 'weather', component: WeatherComponent },
  { path: 'persons', component: PersonsComponent },
  { path: 'person-detail/:id', component: PersonDetailComponent },
  { path: 'eform-service-status', title: 'EFormService Status - Angular with Remote Dotnet WebApi', component: EFormServiceStatusComponent },
  { path: 'eform-service-request-type-status/:server', title: 'EFormService Request Type Status - Angular with Remote Dotnet WebApi', component: EFormServiceRequestTypeStatusComponent },
  { path: 'weather-forecast', title: 'Weather Forecast', component: WeatherForecastComponent },
  { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}