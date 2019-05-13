import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/core/domains/Question';
import { QuestionService } from 'src/app/api/question.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public questions: Question[];

  constructor(
    private questionService: QuestionService
  ) { }

  ngOnInit() {
    this.questionService.getQuestions().subscribe((questions) => {
      this.questions = questions;
    });
  }
}
