import { Component, OnInit } from '@angular/core';
import { Router, RouterEvent, ActivatedRoute } from '@angular/router';
import { SectionService } from 'src/app/api/section.service';
import { Section } from 'src/app/core/domains/section';
import { NavController } from '@ionic/angular';
import { AuthService } from 'src/app/api/auth.service';

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
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private navCtlr: NavController,
    private authService: AuthService,
    private sectionService: SectionService
  ) {}

  ngOnInit() {
    const sectionId = +this.activatedRoute.snapshot.paramMap.get('sectionId');
    this.loadSection(sectionId);
  }

  loadSection(sectionId: number) {
    if (sectionId === null || sectionId === 0) {
      this.sectionService.getRootSections().subscribe((sections) => {
        this.selectedSection = null;
        this.sections = sections;
        this.navCtlr.navigateRoot(`/app/home`);
        console.log('navigate root to /app/home');
      });
    } else {
      this.sectionService.getSection(sectionId).subscribe((section) => {
        this.selectedSection = section;
        this.previousSectionId = section.parentId;
        // Add own item aswell
        section.sections.unshift(section);
        this.sections = section.sections;
        this.navCtlr.navigateRoot(`/app/sections/${this.selectedSection.id}`);
        console.log(`navigate root to /app/sections/${this.selectedSection.id}`);
      });
    }
  }

  logout() {
    this.authService.logout();
  }
}
