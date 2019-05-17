import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavController } from '@ionic/angular';
import { AuthService } from 'src/app/api/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  message: string;

  constructor(
    private navCtrl: NavController,
    private authService: AuthService
  ) { }

  ngOnInit() {
  }

  login(form: { value: { email: string; password: string; }; }) {
    this.message = null;
    this.authService.login(form.value.email, form.value.password)
      .subscribe(
        data => console.log('Login success => ', data),
        error => {
          console.log('Login failed => ', error);
          this.message = error.error.message;
        }
      );
  }
}
