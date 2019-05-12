import { Component, NgZone } from '@angular/core';

import { Platform, NavController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { Observable, of } from 'rxjs';
import { SectionService } from './api/section.service';
import { Section } from './core/domains/section';
import { Navigation, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html'
})
export class AppComponent {
  public previousSectionId: number = null;
  public selectedSection: Section;
  public sections: Section[];
  public title: string;
  private activePage: string;

  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    private sectionService: SectionService,
    private navCtlr: NavController,
    private router: Router
  ) {
    this.initializeApp();
  }

  initializeApp() {
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });

    // Get the root sections
    this.loadSection(null);
  }

  loadSection(sectionId: number) {
    if (sectionId == null) {
      this.sectionService.getRootSections().subscribe((sections) => {
        this.selectedSection = null;
        this.sections = sections;

        this.navigate('section');
      });
    } else {
      this.sectionService.getSection(sectionId).subscribe((section) => {
        this.selectedSection = section;
        this.previousSectionId = section.parentId;
        this.sections = section.sections;
        this.sections.unshift(section);

        this.navigate('section');
      });
    }
  }

  navigate(page: string) {
    this.activePage = page;

    switch (page) {
      case 'section':
        if (this.selectedSection == null) {
          this.navCtlr.navigateRoot('/home');
        } else {
          this.navCtlr.navigateRoot(`/sections/${this.selectedSection.id}`);
        }
        break;
      case 'questions':
        if (this.selectedSection == null) {
          this.navCtlr.navigateRoot(`/questions/overview`);
        } else {
          this.navCtlr.navigateRoot(`/sections/${this.selectedSection.id}/questions`);
        }
        break;
      case 'notes':
        if (this.selectedSection == null) {
          this.navCtlr.navigateRoot(`/notes/overview`);
        } else {
          this.navCtlr.navigateRoot(`/sections/${this.selectedSection.id}/notes`);
        }
        break;
    }
  }

  loadQuestions() {
    this.navigate('questions');
  }

  loadNotes() {
    this.navigate('notes');
  }
}
