import { Component, OnInit } from '@angular/core';
import { Section } from 'src/app/core/domains/section';
import { Question } from 'src/app/core/domains/question';
import { Note } from 'src/app/core/domains/note';
import { ActivatedRoute } from '@angular/router';
import { SectionService } from 'src/app/api/section.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss'],
})
export class DetailPage implements OnInit {

  section: Section;
  public questions: Question[]; 
  public notes: Note[]; 

  constructor(
    public activatedRoute: ActivatedRoute,
    public sectionService: SectionService
  ) { }

  ngOnInit() {
    // const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    // this.sectionService.getSection(sectionId).subscribe((section) => {
    //   this.section = section;
    // });
    this.section = new Section();
    this.section.title = "Mijn eerste sectie";
    this.section.description = "Hello world!";
    this.questions = [ new Question(), new Question(), new Question() ];
    this.questions[0].title = "Vraag 1"
    this.questions[1].title = "Vraag 2"
    this.questions[2].title = "Vraag 3"

    this.notes = [ new Note(), new Note(), new Note() ];
    this.notes[0].title = "Notitie 1"
    this.notes[1].title = "Notitie 2"
    this.notes[2].title = "Notitie 3"
  }

}
