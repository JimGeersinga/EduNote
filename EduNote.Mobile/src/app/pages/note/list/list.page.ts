import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { NoteService } from 'src/app/api/note.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public notes: Note[];

  constructor(
    private noteService: NoteService
  ) { }

  ngOnInit() {
    this.noteService.getNotes().subscribe((notes) => {
      this.notes = notes;
    });
  }
}
