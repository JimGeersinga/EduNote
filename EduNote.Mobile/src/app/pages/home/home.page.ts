import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { Question } from 'src/app/core/domains/question';
import { UserService } from 'src/app/api/user.service';
import { NavController } from '@ionic/angular';
import { DetailQuestionComponent } from '../question/detail/detail-question.page';
import { EditQuestionComponent } from '../question/edit/edit-question/edit-question.component';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  public questions: Question[]; 
  public notes: Note[]; 

  constructor(public userService: UserService, private modalCtlr : ModalController, private navCtlr: NavController) 
  {  
  }

  ngOnInit() {
    this.userService.getCurrent().subscribe((user) => {
    this.questions = user.questions;
    this.notes = user.notes;
  });
  }

  async editQuestion(id:number)
  {
    let m = await this.modalCtlr.create({
      component: EditQuestionComponent,
      componentProps:{
        'id': id,
        'isEdit': true
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.userService.getCurrent().subscribe((user) => {
        let questions = user.questions;
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
        'id': id,
        'parent':this
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.userService.getCurrent().subscribe((user) => {
        let questions = user.questions;
        this.questions = [];
        questions.forEach(question => {
          this.questions.push(question);
        });
      });
    });
  }

  loadAccount(){
    this.navCtlr.navigateForward(`account`);
  }
}