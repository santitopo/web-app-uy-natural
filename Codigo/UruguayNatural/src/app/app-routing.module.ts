import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LodgingsSearchModule } from './lodgings-search/lodgings-search.module';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
