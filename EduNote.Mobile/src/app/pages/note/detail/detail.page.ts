import { Component, OnInit, Input } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { User } from 'src/app/core/domains/user';
import { NoteService } from 'src/app/api/note.service';
import { UserService } from 'src/app/api/user.service';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss'],
})

export class DetailPage implements OnInit {
  @Input() id:number;
  note:Note;
  user:User;
  noteService:NoteService;
  userService:UserService;
  message:string;
  constructor(noteService:NoteService,
    userService:UserService,
    public viewCtrl: ModalController) { 
      this.noteService = noteService;
      this.userService = userService;
      this.note = new Note();
    }

  async ngOnInit() {
    await this.userService.getCurrent().subscribe(data=>{this.user = data});
    await this.noteService.getNote(this.id).subscribe(data=>{this.note = data});
    console.log(this.note);
  }

  async clickedClose() {
    this.viewCtrl.dismiss();
  }
}