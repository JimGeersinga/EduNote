import { Component, OnInit, Input } from '@angular/core';
import { Question } from 'src/app/core/domains/question';
import { QuestionService } from 'src/app/api/question.service';

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
  question:Question;
  message:string;
  constructor(
    questionService:QuestionService
  ) { 
    this.questionService = questionService;
  }

  async ngOnInit() {
    if(this.id > 0){
      await this.questionService.getQuestion(this.id).subscribe(data=>this.question = data);
      this.isEdit = true;
    }else{
      this.question = new Question();
    }
  }

  send(form){
    console.log(this.question);
    if(this.isEdit){
      this.questionService.put(this.question).subscribe(data=>{
        console.log('putted');
      },
      error=>{
        this.message = error.error.message
      }
      );
    }else{
      this.question.sectionId = this.section;
      this.question.created = new Date(Date.now());
      this.question.id = 0;
      this.question.createdById = 1;
      this.questionService.post(this.question).subscribe(data=>{
        console.log('posted');
      },
      error=>{
        this.message = error.error.message
      });
    }
    
  }

}
