import { Injectable } from '@angular/core';
import { Platform } from '@ionic/angular';
import { Storage } from '@ionic/storage';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable, of, ReplaySubject } from 'rxjs';
import { tap, catchError, filter, map } from 'rxjs/operators';
import { AuthenticationToken } from '../core/domains/AuthenticationToken';
import { Router } from '@angular/router';


const TOKEN_KEY = 'auth-token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private authenticationState = new BehaviorSubject(false);
  private currentToken: AuthenticationToken = null;
  private tokenSubject: ReplaySubject<AuthenticationToken> = new ReplaySubject<AuthenticationToken>(1);

  private refreshing = false;
  private authenticated = false;


  public get isAuthenticated(): boolean {
    return this.authenticated;
  }

  public get authorizationHeader(): Observable<string> {
    return this.tokenSubject.pipe(
      filter((token) => !this.refreshing),
      map((token) => (token ? `Bearer ${token.token}` : null))
    );
  }

  constructor(
    private plt: Platform,
    private http: HttpClient,
    private storage: Storage,
    private router: Router
  ) {
    this.tokenSubject.subscribe((token) => {
      this.currentToken = token;
      this.authenticated = token ? true : false;
      if (token) {
        this.refreshing = false;
      }
    });

    this.plt.ready().then(() => {
      this.getToken();
    });
  }

  public login(email: string, password: string) {
    return this.http.post<AuthenticationToken>(`${environment.apiUrl}/users/authenticate`, { email, password })
      .pipe(
        tap(data => {
          this.setToken(data);
        }),
        catchError(this.handleError('Login'))
      );
  }

  public refresh(): Observable<string> {
    if (this.refreshing) {
    } else {
      this.refreshing = true;

      this.http
        .post<AuthenticationToken>('api/users/refresh', { refreshToken: this.currentToken.refreshToken, token: this.currentToken.token })
        .pipe(
          tap((token) => {
            this.setToken(token);
          }),
          catchError((error) => {
            this.setToken(null);
            return this.logout();
          })
        )
        .subscribe();
    }

    return this.authorizationHeader;
  }

  public logout(): Observable<void> {
    this.setToken(null);
    this.router.navigateByUrl('login');
    return of();
  }

  private getToken() {
    this.storage.get(TOKEN_KEY).then((res: any) => {
      if (res) {
        this.authenticationState.next(true);
        this.tokenSubject.next(res);
        return of(res);
      }
    });
  }

  private setToken(token: AuthenticationToken) {
    this.storage.set(TOKEN_KEY, token).then(() => {
      this.authenticationState.next(true);
      this.tokenSubject.next(token);
    });
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
