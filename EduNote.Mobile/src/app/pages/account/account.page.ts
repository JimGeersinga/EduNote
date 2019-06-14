import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/api/user.service';
import { ToastController } from '@ionic/angular';
import { User } from 'src/app/core/domains/user';

@Component({
  selector: 'app-account',
  templateUrl: './account.page.html',
  styleUrls: ['./account.page.scss'],
})
export class AccountPage implements OnInit {

  public user: User;
  public password: string;

  constructor(public userService: UserService, public toastController: ToastController) {
  }

  ngOnInit() {
    this.userService.getCurrent().subscribe((user) => {
      this.user = user;
    });
  }

  async updatePassword() {
    this.userService.updatePassword(this.user.id, this.password).subscribe(async (user) => {
      this.password = '';
      const toast = await this.toastController.create({
        message: 'Uw wachtwoord is bijgewerkt',
        duration: 2000
      });
      toast.present();
    });

  }
}