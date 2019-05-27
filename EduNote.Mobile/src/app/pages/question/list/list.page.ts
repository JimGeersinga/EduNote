import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/core/domains/question';
import { QuestionService } from 'src/app/api/question.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NavController, ModalController } from '@ionic/angular';
import { EditQuestionComponent } from '../edit/edit-question/edit-question.component';
import { DetailQuestionComponent } from '../detail/detail-question.page';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public questions: Question[];
  sectionId:number;
  constructor(
    private activatedRoute: ActivatedRoute,
    private questionService: QuestionService,
    private modalCtlr: ModalController  
    ) { }

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.sectionId = sectionId;
    this.questionService.getQuestionsBySection(sectionId).subscribe((questions) => {
      this.questions = questions;
    });
  }
  async createQuestion()
  {
    console.log('open question');
    let m = await this.modalCtlr.create({
      component: EditQuestionComponent,
      componentProps:{
        'id': 0,
        'isEdit': false,
        'section': this.sectionId
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.questionService.getQuestionsBySection(this.sectionId).subscribe((questions) => {
        this.questions = [];
        questions.forEach(question => {
          this.questions.push(question);
        });
        console.log('questions pushed');
      });
    });
  }

  async loadQuestion(id:number)
  {
    let m = await this.modalCtlr.create({
      component: DetailQuestionComponent,
      componentProps:{
        'id': id
      }
    });
    m.onDidDismiss().then(()=>{
      this.questionService.getQuestionsBySection(this.sectionId).subscribe((questions) => {
        this.questions = [];
        questions.forEach(question => {
          this.questions.push(question);
        });
        console.log('questions pushed');
      });
    });
  }
}
