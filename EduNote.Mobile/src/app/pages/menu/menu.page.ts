import { Component, OnInit } from '@angular/core';
import { Router, RouterEvent } from '@angular/router';
import { SectionService } from 'src/app/api/section.service';
import { Section } from 'src/app/core/domains/section';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.page.html',
  styleUrls: ['./menu.page.scss'],
})
export class MenuPage implements OnInit {
  selectedPath = '';
  selectedSection: Section;
  previousSectionId: number;
  sections: any;

  constructor(
    private router: Router,
    private navCtlr: NavController,
    private sectionService: SectionService
  ) {
    // this.router.events.subscribe((event: RouterEvent) => {
    //   if (event && event.url) {
    //     this.selectedPath = event.url;
    //   }
    // });
  }

  ngOnInit() {
    this.loadSection(null);
  }

  loadSection(sectionId: number) {
    if (sectionId == null) {
      this.sectionService.getRootSections().subscribe((sections) => {
        this.selectedSection = null;
        this.sections = sections;
        this.navCtlr.navigateRoot(`/home`);
      });
    } else {
      this.sectionService.getSection(sectionId).subscribe((section) => {
        this.selectedSection = section;
        this.previousSectionId = section.parentId;
        // Add own item aswell
        section.sections.unshift(section);
        this.sections = section.sections;
        this.navCtlr.navigateRoot(`/sections/${this.selectedSection.id}`);
      });
    }
  }
}
