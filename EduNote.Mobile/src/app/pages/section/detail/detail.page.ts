import { Component, OnInit } from '@angular/core';
import { Section } from 'src/app/core/domains/section';
import { Question } from 'src/app/core/domains/question';
import { Note } from 'src/app/core/domains/note';
import { ActivatedRoute } from '@angular/router';
import { SectionService } from 'src/app/api/section.service';
import { Question } from 'src/app/core/domains/question';
import { Note } from 'src/app/core/domains/note';

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
    const sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.sectionService.getSection(sectionId).subscribe((section) => {
      this.section = section;

      let nleng = this.section.notes.length;
      this.notes = section.notes.slice(0,nleng >= 5? 5 : nleng);
      if(this.notes == null)
      {
        this.notes = new Array();
      }

      let qleng = this.section.questions.length;
      this.questions = section.questions.slice(0,qleng >= 5? 5 : qleng);
      if(this.questions == null)
      {
        this.questions = new Array();
      }
      console.log(section);

    });
  }
}