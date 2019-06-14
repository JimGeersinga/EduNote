import { Component, OnInit } from '@angular/core';
import { Question } from 'src/app/core/domains/question';
import { QuestionService } from 'src/app/api/question.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { EditQuestionComponent } from '../edit/edit-question/edit-question.component';
import { DetailQuestionComponent } from '../detail/detail-question.page';
import { ResourceLoader } from '@angular/compiler';
import { UserService } from 'src/app/api/user.service';
import { User } from 'src/app/core/domains/user';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {
  public questions: Question[];
  public completeQuestions: Question[];
  onlyOwn:boolean;
  sectionId:number;
  search:string = '';
  currentUser:User;
  constructor(
    private activatedRoute: ActivatedRoute,
    private questionService: QuestionService,
    private userService: UserService,
    private modalCtlr: ModalController  
    ) { }
  async ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.sectionId = sectionId;
    await this.userService.getCurrent().subscribe(user=>{
      this.currentUser =user;
    });
    this.reload();
  }
  onChange()
  {
    if(this.search.length == 0)
    {
      this.questions = this.completeQuestions.filter(x=>x.createdById == this.currentUser.id || !this.onlyOwn);
    }else{
      this.questions = this.completeQuestions.filter(x=>(x.createdById == this.currentUser.id || !this.onlyOwn) && (x.title.toLowerCase().includes(this.search.toLowerCase()) || x.creatorName.toLowerCase().includes(this.search.toLowerCase())));
    }
  }
  reload()
  {
    this.questionService.getQuestionsBySection(this.sectionId).subscribe((questions) => {
      this.questions = [];
      this.completeQuestions = [];
      questions.forEach(question => {
        question.hasAnswers = question.answers != null && question.answers.length > 0;
        this.questions.push(question);
        this.completeQuestions.push(question);
      });
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
