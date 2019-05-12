import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    loadChildren: './home/home.module#HomePageModule'
  },
  {
    path: 'sections/:sectionId',
    loadChildren: './section/detail/detail.module#DetailPageModule'
  },
  {
    path: 'sections/:sectionId/notes',
    loadChildren: './note/list/list.module#ListPageModule'
  },
  {
    path: 'sections/:sectionId/notes/:noteId',
    loadChildren: './note/detail/detail.module#DetailPageModule'
  },
  {
    path: 'sections/:sectionId/questions',
    loadChildren: './question/list/list.module#ListPageModule'
  },
  {
    path: 'sections/:sectionId/question/:questionId',
    loadChildren: './question/detail/detail.module#DetailPageModule'
  },
  {
    path: 'questions/overview',
    loadChildren: './question/overview/overview.module#OverviewPageModule'
  },
  {
    path: 'notes/overview',
    loadChildren: './note/overview/overview.module#OverviewPageModule'
  },
  {
    path: 'questions/:questionId',
    loadChildren: './question/detail/detail.module#DetailPageModule'
  },
  {
    path: 'notes/:noteId',
    loadChildren: './note/detail/detail.module#DetailPageModule'
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
