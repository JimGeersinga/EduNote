import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/core/domains/note';
import { NoteService } from 'src/app/api/note.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list',
  templateUrl: './list.page.html',
  styleUrls: ['./list.page.scss'],
})
export class ListPage implements OnInit {

  public notes: Note[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private noteService: NoteService
  ) { }

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.noteService.getNotesBySection(sectionId).subscribe((notes) => {
      this.notes = notes;
    });
  }
}
