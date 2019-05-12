import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Section } from '../core/domains/section';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SectionService {

  baseUrl = 'http://localhost:50900';

  constructor(public http: HttpClient) {

  }
  getRootSections(): Observable<Section[]> {
    return this.http.get<Section[]>(`${this.baseUrl}/api/sections/root`)
      .pipe(
        tap(_ => this.log('fetched root sections ')),
        catchError(this.handleError('getRootSections', []))
      );
  }

  getSection(id: number): Observable<Section> {
    // return this.http.get<Section>(`${this.baseUrl}/api/sections/${id}`);
    return this.http.get<any>(`${this.baseUrl}/api/sections/${id}`)
      .pipe(
        tap(_ => this.log('fetched section ')),
        catchError(this.handleError('getSection', null))
      );
  }

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

  private log(message: string) {
    console.log(message);
  }
}
