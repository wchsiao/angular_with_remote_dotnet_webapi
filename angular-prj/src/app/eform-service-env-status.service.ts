import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { EFormServiceEnvStatus } from './eform-service-env-status';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class EFormServiceEnvStatusService {

  private webapiUrl = 'http://localhost:5276/EFormServiceEnvStatus';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  constructor(
    private http: HttpClient,
    private messageService: MessageService ) { }

  /** GET EFormServiceStatus from the server */
  getEFormServiceEnvStatus(): Observable<EFormServiceEnvStatus> {
    return this.http.get<EFormServiceEnvStatus>(this.webapiUrl)
      .pipe(
        //tap(_ => this.log('fetched EFormServiceStatus')),
        catchError(this.handleError<EFormServiceEnvStatus>('getEFormServiceEnvStatus'))
      );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
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

  /** Log a EFormServiceStatusService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`EFormServiceStatusEnvService: ${message}`);
  }
}
