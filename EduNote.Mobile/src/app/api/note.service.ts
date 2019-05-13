import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Note } from '../core/domains/note';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  baseUrl = 'http://localhost:50900';

  constructor(public http: HttpClient) {

  }

  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(`${this.baseUrl}/api/notes`)
      .pipe(
        tap(_ => this.log('fetched root notes ')),
        catchError(this.handleError('getNotes', []))
      );
  }

  getNote(id: number): Observable<Note> {
    // return this.http.get<Section>(`${this.baseUrl}/api/sections/${id}`);
    return this.http.get<any>(`${this.baseUrl}/api/notes/${id}`)
      .pipe(
        tap(_ => this.log('fetched note ')),
        catchError(this.handleError('getNote', null))
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
