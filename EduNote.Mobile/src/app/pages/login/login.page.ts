import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(
    private navCtrl: NavController
  ) { }

  ngOnInit() {
  }

  login(form) {
    // this.authService.login(form.value).subscribe((res) => {
    //   this.router.navigateByUrl('home');
    // });
    this.navCtrl.navigateRoot('menu/home');
  }
}
