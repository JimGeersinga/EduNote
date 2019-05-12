import { Component, OnInit } from '@angular/core';
import { Section } from 'src/app/core/domains/section';
import { NavController, NavParams } from '@ionic/angular';
import { ActivatedRoute } from '@angular/router';
import { SectionService } from 'src/app/api/section.service';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.page.html',
  styleUrls: ['./detail.page.scss'],
})
export class DetailPage implements OnInit {

  section: Section;

  constructor(
    public activatedRoute: ActivatedRoute,
    public sectionService: SectionService
  ) { }

  ngOnInit() {
    // + causes a string to be converted to number
    const sectionId = +this.activatedRoute.snapshot.paramMap.get('id');
    this.sectionService.getSection(sectionId).subscribe((section) => {
      this.section = section;
    });
  }

}
