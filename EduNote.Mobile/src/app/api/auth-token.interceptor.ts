import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, first, flatMap, catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationTokenInterceptor implements HttpInterceptor {
    constructor(
        private auth: AuthService
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (!request.url.includes('api/users/authenticate')) {
            console.log('auth request:' + request.method + '|' + request.url);
            return this.auth.authorizationHeader.pipe(
        filter((token) => token != null),
        first(),
        flatMap((header) => {
          console.log('add header: ' + header);
          return next
            .handle(request.clone({
              setHeaders: {
                Authorization: header
              }
            }) as HttpRequest<any>)
            .pipe(
              catchError((error) => {
                if (error.status === 401) {
                  console.log('refreshing token');
                  return this.auth.refresh().pipe(
                    first(),
                    flatMap((header2) => {
                      console.log('add refreshed header: ' + header2);
                      return next
                        .handle(request.clone({
                          setHeaders: {
                            Authorization: header2
                          }
                        }) as HttpRequest<any>)
                        .pipe(
                          catchError((error2) => {
                            return this.auth.logout().pipe(
                              first(),
                              flatMap(() => {
                                return throwError(error2);
                              })
                            );
                          })
                        );
                    })
                  );
                }
                return throwError(error);
              })
            );
        })
      );
    } else {
      return next.handle(request);
    }
  }
}
