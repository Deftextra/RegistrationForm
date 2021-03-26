import {
  HttpClient,
  HttpErrorResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import {
  SaveRegistrationRequest
} from '../domain/Interfaces/create-registration-request';
import { RegistrationResponse } from '../domain/Interfaces/registration-response';

@Injectable({
  providedIn: 'root',
})
export class RegistrationClientService {
  constructor(private http: HttpClient) {}

  readonly apiEndpoint: string = 'https://localhost:5001/api/';

  public getAllRegistrations(): Observable<any> {
    return this.http
      .get<RegistrationResponse>(this.apiEndpoint + 'registrations')
      .pipe(catchError(this.handleError));
  }

  // We should immediagely get back our result by default.
  public getRegistration(id: string): Observable<any> {
    return this.http
      .get<RegistrationResponse>(this.apiEndpoint + 'registrations/' + id)
      .pipe(catchError(this.handleError));
  }

  public addRegistration(
    registration: SaveRegistrationRequest
  ): Observable<any> {
    return this.http
      .post(this.apiEndpoint + 'registrations', registration)
      .pipe(catchError(this.handleError));
  }

  public updateRegistration(
    id: string,
    updateRegistration: SaveRegistrationRequest
  ): Observable<any> {
    return this.http.put(
      this.apiEndpoint + 'registrations' + id,
      updateRegistration
    ).pipe(
      catchError(this.handleError)
    );
  }
  
  public deleteRegistration(id: string) {
    return this.http.delete<RegistrationResponse>(this.apiEndpoint + 'registrations' + id)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): Observable<any> {
    if (error.error instanceof ErrorEvent) {
      console.error('An error occurred:', error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.error}`
      );
    }
    return throwError('Something bad happened; please try again later.');
  }


  private extractData(res: Object): any {
    const body = res;
    return body || {};
  }
}
