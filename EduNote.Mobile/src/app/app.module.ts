import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { IonicStorageModule } from '@ionic/storage';
import { AuthenticationTokenInterceptor } from './api/auth-token.interceptor';
import { EditNoteComponent } from './pages/note/edit/edit-note/edit-note.component';


import { FormsModule } from '@angular/forms';
import { EditQuestionComponent } from './pages/question/edit/edit-question/edit-question.component';
import { DetailQuestionComponent } from './pages/question/detail/detail-question.page';
import { DetailPage } from './pages/note/detail/detail.page';
import { DetailPageModule } from './pages/note/detail/detail.module';

@NgModule({
  declarations: [AppComponent, EditQuestionComponent, DetailQuestionComponent,EditNoteComponent,DetailPage],
  entryComponents: [EditQuestionComponent,DetailQuestionComponent,EditNoteComponent,DetailPage],
  imports: [
    BrowserModule,
    HttpClientModule,
    IonicModule.forRoot(),
    FormsModule,
    AppRoutingModule,
    IonicStorageModule.forRoot()
  ],
  providers: [
    StatusBar,
    SplashScreen,
    { provide: RouteReuseStrategy, useClass: IonicRouteStrategy },
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationTokenInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
