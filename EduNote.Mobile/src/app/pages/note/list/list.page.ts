import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { NoteService } from 'src/app/api/note.service';
import { ActivatedRoute } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { EditNoteComponent } from '../edit/edit-note/edit-note.component';
import { DetailPage } from '../detail/detail.page';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public notes: Note[];

  private sectionId: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private noteService: NoteService,
    private modalCtrl: ModalController
  ) { }

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.sectionId = sectionId;
    this.noteService.getNotesBySection(sectionId).subscribe((notes) => {
      this.notes = notes;
    });
  }

  async addNote()
  {
    console.log('open question');
    let m = await this.modalCtrl.create({
      component: EditNoteComponent,
      componentProps:{
        'id': 0,
        'isEdit': false,
        'section': this.sectionId
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.noteService.getNotesBySection(this.sectionId).subscribe((notes) => {
        this.notes = [];
        notes.forEach(note => {
          this.notes.push(note);
        });
        console.log('notes pushed');
      });
    });
  }

  async loadNote(id:number)
  {
    console.log('yo');
    let m = await this.modalCtrl.create({
      component: DetailPage,
      componentProps:{
        'id': id
      }
    });
    m.present();
    m.onDidDismiss().then(()=>{
      this.noteService.getNotesBySection(this.sectionId).subscribe((notes) => {
        this.notes = [];
        notes.forEach(question => {
          this.notes.push(question);
        });
        console.log('questions pushed');
      });
    });
  }

}
