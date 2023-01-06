import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroesComponent } from './heroes/heroes.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { WeatherComponent } from './weather/weather.component';
import { PersonsComponent } from './persons/persons.component';
import { EFormServiceEnvStatusComponent } from './eform-service-env-status/eform-service-env-status.component';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'detail/:id', component: HeroDetailComponent },
  { path: 'heroes', component: HeroesComponent },
  { path: 'weather', component: WeatherComponent },
  { path: 'persons', component: PersonsComponent },
  { path: 'eform-service-env-status', title: 'EFormService Env Status - Angular with Remote Dotnet WebApi', component: EFormServiceEnvStatusComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}