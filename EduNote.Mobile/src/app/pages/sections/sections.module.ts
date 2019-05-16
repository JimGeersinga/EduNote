import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { SectionsPage } from './sections.page';

const routes: Routes = [
  {
    path: '',
    component: SectionsPage,
    children: [
      {
        path: '', redirectTo: 'section', pathMatch: 'full'
      },
      {
        path: 'section',
        loadChildren: '../section/detail/detail.module#DetailPageModule'
      },
      {
        path: 'questions',
        loadChildren: '../question/list/list.module#ListPageModule'
      },
      {
        path: 'notes',
        loadChildren: '../note/list/list.module#ListPageModule'
      }
    ]
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes)
  ],
  declarations: [SectionsPage]
})
export class SectionsPageModule {}
