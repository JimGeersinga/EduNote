import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Note } from '../core/domains/note';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(public http: HttpClient) {

  }

  getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(`${environment.apiUrl}/notes`)
      .pipe(
        tap(_ => this.log('fetched root notes ')),
        catchError(this.handleError('getNotes', []))
      );
  }

  getNotesBySection(id: number): Observable<Note[]> {
    return this.http.get<Note[]>(`${environment.apiUrl}/sections/${id}/notes`)
      .pipe(
        tap(_ => this.log('fetched notes ')),
        catchError(this.handleError('getNotesBySection', null))
      );
  }

  getNote(id: number): Observable<Note> {
    // return this.http.get<Section>(`${this.baseUrl}/api/sections/${id}`);
    return this.http.get<any>(`${environment.apiUrl}/notes/${id}`)
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
