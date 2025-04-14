import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterOutlet, RouterLink, Router, RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WordComponent } from './word/word.component';
import { StatisticComponent } from './statistic/statistic.component';
import { ComparisionComponent } from './comparision/comparision.component';

@NgModule({
  declarations: [
    AppComponent,
    WordComponent,
    StatisticComponent,
    ComparisionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterOutlet,
    RouterLink,
 ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
