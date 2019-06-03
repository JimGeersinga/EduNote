import { Component, OnInit, Input } from '@angular/core';
import { Answer } from 'src/app/core/domains/answer';
import { Question } from 'src/app/core/domains/question';
import { User } from 'src/app/core/domains/user';
import { QuestionService } from 'src/app/api/question.service';
import { UserService } from 'src/app/api/user.service';
import { AnswerService } from 'src/app/api/anwer.service';
import { ModalController } from '@ionic/angular';
import { ListPage } from '../list/list.page';

@Component({
  selector: 'app-detail',
  templateUrl: './detail-question.page.html',
  styleUrls: ['./detail-question.page.scss'],
})
export class DetailQuestionComponent implements OnInit {
  @Input() id:number;
  @Input() parent:any;
  answer:Answer;
  answers:Answer[]; 
  question:Question;
  user:User;
  questionService:QuestionService;
  userService:UserService;
  answerService: AnswerService;
  message:string;
  constructor(questionService:QuestionService,
    userService:UserService,
    answerService:AnswerService,
    public viewCtrl: ModalController) { 
      this.questionService = questionService;
      this.userService = userService;
      this.answerService = answerService;
      this.question = new Question();
      this.answer = new Answer();
      this.user = new User();

    }

  async ngOnInit() {
    await this.userService.getCurrent().subscribe(data=>{this.user = data});
    await this.questionService.getQuestion(this.id).subscribe(data=>{this.question = data;console.log(this.question);this.answers = this.question.answers;});
    console.log(this.question);
  }
  send(form){
    this.answer.created = new Date(Date.now());
    this.answer.id = 0;
    this.answer.createdBy = this.user.id;
    this.answer.questionId = this.question.id;
    let ctrl = this.viewCtrl;
    this.answerService.post(this.answer).subscribe(data=>{
      ctrl.dismiss();
    },
    error=>{
      this.message = error.error.message
    });
    console.log(this.answer);
    
  }

  loadForm(){
    console.log('to form');
    this.viewCtrl.dismiss();
    this.parent.editQuestion(this.question.id);

  }

}
