import { Component, OnInit, Input } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { NoteService } from 'src/app/api/note.service';
import { UserService } from 'src/app/api/user.service';
import { Note } from 'src/app/core/domains/note';
import { User } from 'src/app/core/domains/user';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss'],
})

export class EditNoteComponent implements OnInit {
  @Input() id: number;
  @Input() section: number;
  @Input() isEdit: boolean;
  noteService: NoteService;
  userService: UserService;
  note: Note;
  message: string;
  user: User;
  constructor(
    noteService: NoteService,
    userService: UserService,
    public viewCtrl: ModalController
  ) {
    this.noteService = noteService;
    this.userService = userService;
    this.note = new Note();
  }

  async ngOnInit() {
    await this.userService.getCurrent().subscribe(data => { this.user = data; });
    if (this.id > 0) {
      await this.noteService.getNote(this.id).subscribe(data => this.note = data);
      this.isEdit = true;
    } else {
      this.note = new Note();
    }
  }


  async send(form) {
    console.log(this.user);

    if (this.isEdit) {
      await this.noteService.put(this.note).subscribe(data => {
        console.log('putted');
        this.viewCtrl.dismiss();
        console.log('Dismissed');
      },
        error => {
          this.message = error.error.message;
        }
      );
    } else {
      this.note.sectionId = this.section;
      this.note.created = new Date(Date.now());
      this.note.id = 0;
      this.note.createdById = this.user.id;
      console.log(this.note);
      const ctrl = this.viewCtrl;
      await this.noteService.post(this.note).subscribe(data => {
        console.log('posted');
        this.viewCtrl.dismiss();
        console.log('Dismissed');
      },
        error => {
          this.message = error.error.message;
        });
    }

  }
}