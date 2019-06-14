import { Component, OnInit } from '@angular/core';
import { Section } from 'src/app/core/domains/section';
import { Question } from 'src/app/core/domains/question';
import { Note } from 'src/app/core/domains/note';
import { ActivatedRoute } from '@angular/router';
import { SectionService } from 'src/app/api/section.service';
import { ModalController } from '@ionic/angular';
import { EditQuestionComponent } from '../../question/edit/edit-question/edit-question.component';
import { DetailQuestionComponent } from '../../question/detail/detail-question.page';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss'],
})
export class DetailPage implements OnInit {

  section: Section;
  sectionId: number;
  public questions: Question[];
  public notes: Note[];

  constructor(
    public activatedRoute: ActivatedRoute,
    public sectionService: SectionService,
    private modalCtlr: ModalController
  ) { }

  ngOnInit() {
    this.sectionId = +this.activatedRoute.snapshot.parent.parent.paramMap.get('sectionId');
    this.loadSection();
  }

  loadSection() {
    this.sectionService.getSection(this.sectionId).subscribe((section) => {
      this.section = section;
      const nleng = this.section.notes.length;
      this.notes = this.section.notes.slice(0, nleng >= 5 ? 5 : nleng);
      if (this.notes == null) {
        this.notes = new Array();
      }

      const qleng = this.section.questions.length;
      this.questions = this.section.questions.slice(0, qleng >= 5 ? 5 : qleng);
      if (this.questions == null) {
        this.questions = new Array();
      }
      console.log(this.section);
    });
  }



  async editQuestion(id: number) {
    const m = await this.modalCtlr.create({
      component: EditQuestionComponent,
      componentProps: {
        id,
        isEdit: true
      }
    });
    m.present();
    m.onDidDismiss().then(() => {
      this.loadSection();
    });
  }


  async loadQuestion(id: number) {
    const m = await this.modalCtlr.create({
      component: DetailQuestionComponent,
      componentProps: {
        id,
        parent: this
      }
    });
    m.present();
    m.onDidDismiss().then(() => {
      this.loadSection();
    });
  }
}