import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-edit-note',
  templateUrl: './edit-note.component.html',
  styleUrls: ['./edit-note.component.scss'],
})
export class EditNoteComponent implements OnInit {

  constructor(private modalCtrl:ModalController) {   }

  ngOnInit() {}
  
  dismissModal() {
    this.modalCtrl.dismiss();
  }
}
