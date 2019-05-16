import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Question } from '../core/domains/question';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  baseUrl = 'http://localhost:50900';

  constructor(public http: HttpClient) {

  }

  getQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(`${this.baseUrl}/api/questions`)
      .pipe(
        tap(_ => this.log('fetched questions ')),
        catchError(this.handleError('getQuestions', []))
      );
  }

  getQuestion(id: number): Observable<Question> {
    // return this.http.get<Question>(`${this.baseUrl}/api/questions/${id}`);
    return this.http.get<any>(`${this.baseUrl}/api/questions/${id}`)
      .pipe(
        tap(_ => this.log('fetched question ')),
        catchError(this.handleError('getQuestion', null))
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
