import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Platform, NavController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { SectionService } from './api/section.service';
import { Section } from './core/domains/section';
import { AuthService } from './api/auth.service';

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
    private authService: AuthService,
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

    this.authService.authenticationState.subscribe(state => {
      console.log('Program :: authenticationState => State: ', state);
      if (state) {
        this.router.navigate(['app']);
      } else {
        this.router.navigate(['login']);
      }
    });
  }
}
