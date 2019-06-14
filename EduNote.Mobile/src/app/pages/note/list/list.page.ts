import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { NoteService } from 'src/app/api/note.service';
import { ActivatedRoute } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { EditNoteComponent } from '../edit/edit-note/edit-note.component';

import { UserService } from 'src/app/api/user.service';
import { User } from 'src/app/core/domains/user';

import { DetailPage } from '../detail/detail.page';


@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public notes: Note[];
  public userId: number;

  public searchText: string;

  private sectionId: number;

  constructor(
    private activatedRoute: ActivatedRoute,
    private noteService: NoteService,
    private modalCtrl: ModalController,
    public userService: UserService
  ) { }

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.sectionId = sectionId;
    this.noteService.getNotesBySection(sectionId).subscribe((notes) => {
      this.notes = notes;
    });
  }

  onSearchInput(ev: any) {
    this.searchText = ev.target.value;
    this.noteService.getNotesBySection(this.sectionId, this.searchText).subscribe((notes) => {
      this.notes = notes;
    });
  }

  onSearchCancel() {
    this.searchText = '';
    this.noteService.getNotesBySection(this.sectionId, this.searchText).subscribe((notes) => {
      this.notes = notes;
    });
  }

  async addNote() {
    const m = await this.modalCtrl.create({
      component: EditNoteComponent,
      componentProps: {
        id: 0,
        isEdit: false,
        section: this.sectionId
      }
    });
    m.onDidDismiss().then(() => {
      this.noteService.getNotesBySection(this.sectionId).subscribe((notes) => {
        this.notes = [];
        notes.forEach(note => {
          this.notes.push(note);
        });
      });
    });
    await m.present();
  }

  async loadNote(id: number) {
    console.log('yo');
    const modal = await this.modalCtrl.create({
      component: DetailPage,
      componentProps: {
        id
      }
    });

    await modal.present();
  }

  async filterNotesByUser() {
    const sectionId = + this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');

    this.userService.getCurrent().subscribe((user) => {
      this.userId = user.id;

      this.noteService.getNotesBySection(sectionId).subscribe((notes) => {
        this.notes = notes.filter(note => note.createdById === this.userId);
      });
    });
  }

  async removeFilters() {
    const sectionId = + this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.noteService.getNotesBySection(sectionId).subscribe((notes) => {
      this.notes = notes;
    });
  }
}
