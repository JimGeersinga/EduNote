import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Section } from '../core/domains/section';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Answer } from '../core/domains/answer';

@Injectable({
  providedIn: 'root'
})
export class AnswerService {

  constructor(public http: HttpClient) {

  }
  post(answer:Answer) {
    console.log(answer);
    return this.http.post<Answer>(`${environment.apiUrl}/answers`, { 'Body': answer.body, 
    'QuestionId':answer.questionId, 
    'createdById':answer.createdBy,
    'Id':answer.id,
    'Created':answer.created })
      .pipe(
        tap(_ => {this.log('posted answer ')
        }),
        catchError(this.handleError('postanswer'))
      );
  }

  put(answer:Answer) {
    return this.http.put<Answer>(`${environment.apiUrl}/answers`, { 'Body': answer.body, 
    'QuestionId':answer.questionId, 
    'createdById':answer.createdBy,
    'Id':answer.id,
    'Created':answer.created })
      .pipe(
        tap(_ => {this.log('putanswer ')
        }),
        catchError(this.handleError('putanswer'))
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