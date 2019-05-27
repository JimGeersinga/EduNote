import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Question } from '../core/domains/question';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(public http: HttpClient) {

  }

  getQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(`${environment.apiUrl}/questions`)
      .pipe(
        tap(_ => this.log('fetched questions ')),
        catchError(this.handleError('getQuestions', []))
      );
  }

  getQuestionsBySection(id: number): Observable<Question[]> {
    return this.http.get<Question[]>(`${environment.apiUrl}/sections/${id}/questions`)
      .pipe(
        tap(_ => this.log('fetched questions ')),
        catchError(this.handleError('getQuestionsBySection', null))
      );
  }
  post(question:Question) {
    console.log(question);
    return this.http.post<Question>(`${environment.apiUrl}/questions`, { 
      'Body': question.body, 
      'SectionId':question.sectionId, 
      'Title':question.title, 
      'CreatedById':question.createdById,
      'Id':question.id,
      'Created':question.created
    })
      .pipe(
        tap(_ => {this.log('posted question ')
        }),
        catchError(this.handleError('postQuestion'))
      );
  }

  put(question:Question) {
    return this.http.put<Question>(`${environment.apiUrl}/questions`, { 'Body': question.body, 
    'SectionId':question.sectionId, 
    'Title':question.title, 
    'CreatedById':question.createdById,
    'Id':question.id,
    'Created':question.created })
      .pipe(
        tap(_ => {this.log('putQuestion ')
        }),
        catchError(this.handleError('putQuestion'))
      );
  }


  getQuestion(id: number): Observable<Question> {
    return this.http.get<Question>(`${environment.apiUrl}/questions/${id}`)
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
