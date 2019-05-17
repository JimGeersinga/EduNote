import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/core/domains/question';
import { QuestionService } from 'src/app/api/question.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public questions: Question[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private questionService: QuestionService
  ) { }

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.questionService.getQuestionsBySection(sectionId).subscribe((questions) => {
      this.questions = questions;
    });
  }
}
