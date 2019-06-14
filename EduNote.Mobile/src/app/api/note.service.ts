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

  getNotesBySection(id: number, searchText: string = ''): Observable<Note[]> {
    return this.http.get<Note[]>(`${environment.apiUrl}/sections/${id}/notes?search=${searchText}`)
      .pipe(
        tap(_ => this.log('fetched notes with searchfilter: ' + searchText)),
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

  post(note:Note) {
    console.log(note);
    return this.http.post<Note>(`${environment.apiUrl}/notes`, { 
      'Body': note.body, 
      'SectionId':note.sectionId, 
      'Title':note.title, 
      'CreatedById':note.createdById,
      'ModifiedById':note.createdById,
      'Id':note.id,
      'Created':note.created
    })
      .pipe(
        tap(_ => {
          this.log('posted note ');
        }),
        catchError(this.handleError('postNote'))
      );
  }

  put(note:Note) {
    return this.http.put<Note>(`${environment.apiUrl}/notes`, { 'Body': note.body, 
    'SectionId':note.sectionId, 
    'Title':note.title, 
    'CreatedById':note.createdById,
    'Id':note.id,
    'Created':note.created })
    .pipe(
        tap(_ => {this.log('putNote ')
        }),
        catchError(this.handleError('putNote'))
      );
  }

  private log(message: string) {
    console.log(message);
  }
}
