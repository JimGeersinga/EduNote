import { Injectable } from '@angular/core';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';


const TOKEN_KEY = 'auth-token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authenticationState = new BehaviorSubject(false);

  constructor(
    private plt: Platform,
    private http: HttpClient,
    private storage: Storage
  ) {
    this.plt.ready().then(() => {
      this.checkToken();
    });
  }

  checkToken() {
    this.storage.get(TOKEN_KEY).then((res: any) => {
      if (res) {
        this.authenticationState.next(true);
      }
    });
  }

  login(email: string, password: string) {
    return this.http.post(`${environment.apiUrl}/users/authenticate`, { email, password })
      .pipe(
        tap(data => {
          this.storage.set(TOKEN_KEY, `Bearer ${data}`).then(() => {
            this.authenticationState.next(true);
          });
        }),
        catchError(this.handleError('Login'))
      );
  }

  async logout() {
    await this.storage.remove(TOKEN_KEY);
    this.authenticationState.next(false);
  }

  isAuthenticated() {
    console.log('Is Authenticated => ', this.authenticationState.value);
    return this.authenticationState.value;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      // return of(result as T);
      throw error;
    };
  }

  private log(message: string) {
    console.log(message);
  }
}
