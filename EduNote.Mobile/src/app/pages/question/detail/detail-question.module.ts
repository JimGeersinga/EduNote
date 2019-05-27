import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { DetailQuestionComponent } from './detail-question.page';

const routes: Routes = [
  {
    path: '',
    component: DetailQuestionComponent
  }
];



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [DetailQuestionComponent]
})
export class DetailPageModule {}
