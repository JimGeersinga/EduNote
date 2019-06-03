import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../core/domains/user';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(public http: HttpClient) {

  }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(`${environment.apiUrl}/Users/${id}`)
      .pipe(
        tap(_ => this.log('fetched User ')),
        catchError(this.handleError('getUser', null))
      );
  }

  getCurrent(): Observable<User> {
    return this.http.get<User>(`${environment.apiUrl}/Users/current`)
      .pipe(
        tap(_ => this.log('fetched User ')),
        catchError(this.handleError('getUser', null))
      );
  }

  updatePassword(id: number, password: string): Observable<User> {
    console.log('updating password');
    return this.http.post<User>(`${environment.apiUrl}/Users/${id}/updatepassword`, {
      'password': password
    })
      .pipe(
        tap(_ => this.log('updated password')),
        catchError(this.handleError('updatePassword', null))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(message);
  }
}
