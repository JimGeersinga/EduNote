import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/core/domains/question';
import { QuestionService } from 'src/app/api/question.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { EditQuestionComponent } from '../edit/edit-question/edit-question.component';
import { DetailQuestionComponent } from '../detail/detail-question.page';
import { ResourceLoader } from '@angular/compiler';

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
    this.reload();
  }

  reload()
  {
    this.questionService.getQuestionsBySection(this.sectionId).subscribe((questions) => {
      this.questions = [];
      questions.forEach(question => {
        question.hasAnswers = question.answers.length > 0;
        this.questions.push(question);
      });
      console.log('questions pushed');
    });
  }



  async createQuestion()
  {
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
      this.reload();
    });
  }

  async editQuestion(id:number)
  {
    let m = await this.modalCtlr.create({
      component: EditQuestionComponent,
      componentProps:{
        'id': id,
        'isEdit': true,
        'section': this.sectionId
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.reload();
    });
  }


  async loadQuestion(id:number)
  {
    let m = await this.modalCtlr.create({
      component: DetailQuestionComponent,
      componentProps:{
        'id': id,
        'parent':this
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.reload();
    });
  }
}
