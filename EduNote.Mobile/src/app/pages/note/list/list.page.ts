import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { NoteService } from 'src/app/api/note.service';
import { ActivatedRoute } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { EditNoteComponent } from '../edit/edit-note/edit-note.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public notes: Note[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private noteService: NoteService,
    private modalCtrl: ModalController
  ) { }

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.noteService.getNotesBySection(sectionId).subscribe((notes) => {
      this.notes = notes;
    });
  }

  async addNote() {
    const modal = await this.modalCtrl.create({
      component: EditNoteComponent,
      componentProps: {
        'id': null,
        'isEdit': false
      }
    });
    await modal.present();
    //const data = await modal.onDidDismiss();
  }
}
