import { Component, OnInit, Input } from '@angular/core';
import { Question } from 'src/app/core/domains/question';
import { QuestionService } from 'src/app/api/question.service';
import { UserService } from 'src/app/api/user.service';
import { User } from 'src/app/core/domains/user';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-edit-question',
  templateUrl: './edit-question.component.html',
  styleUrls: ['./edit-question.component.scss'],
})
export class EditQuestionComponent implements OnInit {

  @Input() id:number;
  @Input() section:number;
  @Input() isEdit:boolean;
  questionService: QuestionService;
  userService: UserService;
  question:Question;
  message:string;
  user:User;
  constructor(
    questionService:QuestionService,
    userService:UserService,
    public viewCtrl: ModalController
  ) { 
    this.questionService = questionService;
    this.userService = userService;
    this.question = new Question();
  }

  async ngOnInit() {
    await this.userService.getCurrent().subscribe(data=>{this.user = data});
    if(this.id > 0){
      await this.questionService.getQuestion(this.id).subscribe(data=>this.question = data);
      this.isEdit = true;
    }else{
      this.question = new Question();
    }
  }

  async send(form){
    console.log(this.user);
    
    if(this.isEdit){
      await this.questionService.put(this.question).subscribe(data=>{
        console.log('putted');
        this.viewCtrl.dismiss();
        console.log('Dismissed');
      },
      error=>{
        this.message = error.error.message
      }
      );
    }else{
      this.question.sectionId = this.section;
      this.question.created = new Date(Date.now());
      this.question.id = 0;
      this.question.createdById = this.user.id;
      console.log(this.question);
      let ctrl = this.viewCtrl;
      await this.questionService.post(this.question).subscribe(data=>{
        console.log('posted');
        this.viewCtrl.dismiss();
        console.log('Dismissed');
      },
      error=>{
        this.message = error.error.message
      });
    }
    
    
    
  }

}
