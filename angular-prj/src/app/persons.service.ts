import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Person } from './person';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  private webapiUrl = 'http://localhost:5007/Person';  // URL to web api

  httpOptions = {
    header: new HttpHeaders({ 'Content-Type': 'application/json'})
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }


  getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.webapiUrl)
      .pipe(
        tap(_ => this.log('fatched persons')),
        catchError(this.handleError<Person[]>('getPersons', []))
      );
  }

  private log(message: string) {
    this.messageService.add(`PersonService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}