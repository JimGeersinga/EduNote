import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/api/user.service';
import { ToastController } from '@ionic/angular';

@Component({
  selector: 'app-account',
  templateUrl: './account.page.html',
  styleUrls: ['./account.page.scss'],
})
export class AccountPage implements OnInit {

  public id: number;
  public email: string;
  public firstName: string;
  public lastName: string;
  public password: string;

  constructor(public userService: UserService, public toastController: ToastController) {
  }

  ngOnInit() {
    this.userService.getCurrent().subscribe((user) => {
      this.id = user.id;
      this.email = user.email;
      this.firstName = user.firstName;
      this.lastName = user.lastName;
    });
  }

  async updatePassword() {
    this.userService.updatePassword(this.id, this.password).subscribe(async (user) => {
      this.password = "";
      const toast = await this.toastController.create({
        message: 'Uw wachtwoord is bijgewerkt',
        duration: 2000
      });
      toast.present();
    });

  }
}