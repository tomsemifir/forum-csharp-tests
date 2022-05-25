import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { SubjectComponent } from './pages/subject/subject.component';
import { DisplaySubjectComponent } from './components/display-subject/display-subject.component';
import { DisplayMessageComponent } from './components/display-message/display-message.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddSubjectComponent } from './components/add-subject/add-subject.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SubjectComponent,
    DisplaySubjectComponent,
    DisplayMessageComponent,
    AddSubjectComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
