import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRouteSnapshot, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
import { WordComponent } from './word/word.component';
import { StatisticComponent } from './statistic/statistic.component';
import { ComparisionComponent } from './comparision/comparision.component';

const routes: Routes = [
  { path: 'word', component: WordComponent },
  { path: 'statistic', component: StatisticComponent },
  { path: 'comparision', component: ComparisionComponent },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
