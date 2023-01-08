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

  private webapiUrl = 'http://localhost:5294/Person';  // URL to web api

  httpOptions: object = {
    header: new HttpHeaders({
      'Content-Type': 'application/json'
    })
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

  getPerson(id: number): Observable<Person> {
    const url = `${this.webapiUrl}/${id}`;
    return this.http.get<Person>(url).pipe(
      tap(_ => this.log(`fetched person id=${id}`)),
      catchError(this.handleError<Person>(`getPerson id=${id}`))
    );
  }

  deletePerson(id: number): Observable<Person> {
    const url = `${this.webapiUrl}/${id}`;
    
    return this.http.delete<Person>(url, this.httpOptions).pipe(
      tap(_=>this.log(`deleted person id=${id}`)),
      catchError(this.handleError<Person>('deletePerson'))
    );
  }

  updatePerson(person: Person): Observable<any> {
    const url = `${this.webapiUrl}/${person.personId}`;
    return this.http.put(url, person, this.httpOptions).pipe(
      tap(_ => this.log(`updated person id=${person.personId}`)),
      catchError(this.handleError<any>('updatePerson'))
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